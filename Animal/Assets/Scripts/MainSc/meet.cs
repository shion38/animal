using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meet : MonoBehaviour
{
    
    private Vector3 screenPoint;
    private Vector3 offset;
    private Enemy enemy;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.enabled = false;
            
            //当たったら動物の動きを1秒停止
            Invoke("StopOff", 1.0f);
            //このオブジェクトを非表示にする
            gameObject.SetActive(false);

        }
    }

    void Update()
    {
        Transform myTransform = this.transform;
    }

    void StopOff()
    {
       enemy.enabled = true;
       
    }

    
    void OnMouseDown()
    {
        this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        this.offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
    // 追加
    void OnMouseDrag()
    {
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + this.offset;
        transform.position = currentPosition;
    }

  
}