using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy1 : MonoBehaviour
{
    public int hp;
    public float speed;
    public int gold;
    public Route route;
    private int pointIndex;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = route.points[0].transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        var v = route.points[pointIndex + 1].transform.position - route.points[pointIndex].transform.position;
        transform.position += v.normalized * speed * Time.deltaTime;
        var pv = transform.position - route.points[pointIndex].transform.position;
        if (pv.magnitude >= v.magnitude)
        {
            pointIndex++;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {

            //このオブジェクトを非表示にする破壊
            Destroy(gameObject);

        }
    }
}
