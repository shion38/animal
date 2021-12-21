using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Route route;
    private int pointIndex;

    public Slider slider;
    public int maxEnemyHP = 10;
    public int enemyHP;

    public GameObject targetObj;

    MeshRenderer targetMesh;
    MeshRenderer thisObjMesh;

    Coroutine coroutine;

    float x_Abs;
    float y_Abs;
    float z_Abs;

    [SerializeField]
    float speedParameter = 10;

    // Start is called before the first frame update
    void Start()
    {
        targetMesh = targetObj.GetComponent<MeshRenderer>();
        thisObjMesh = this.gameObject.GetComponent<MeshRenderer>();
        transform.position = route.points[0].transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        x_Abs = Mathf.Abs(this.gameObject.transform.position.x - targetObj.transform.position.x);
        y_Abs = Mathf.Abs(this.gameObject.transform.position.y - targetObj.transform.position.y);
        z_Abs = Mathf.Abs(this.gameObject.transform.position.z - targetObj.transform.position.z);

        if (coroutine == null)
        {
            coroutine = StartCoroutine(MoveCoroutine());
        }

        var v = route.points[pointIndex + 1].transform.position - route.points[pointIndex].transform.position;
        transform.position += v.normalized * speed * Time.deltaTime;

        var pv = transform.position - route.points[pointIndex].transform.position;

        if (pv.magnitude >= v.magnitude)
        {
            pointIndex++; //次のPointへ
        }

        if (Goal.goal)
        {
            Destroy(gameObject);
        }

        slider.maxValue = maxEnemyHP;
        slider.value = enemyHP;
    }

    //追いかける動き
    IEnumerator MoveCoroutine()
    {
        if (Vector3.Distance(transform.position, targetObj.transform.position) < 3f)
        {
            float speed = speedParameter * Time.deltaTime;

            while (x_Abs > 0 || y_Abs > 0 || z_Abs > 0)
            {

                yield return new WaitForEndOfFrame();
                this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, targetObj.transform.position, speed);
            }
        }
           
    }

   
}
