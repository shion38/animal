using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    //public Enemy targetEnemy;
    //private float speed = 10;
    //private GameObject target;

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            //このオブジェクトを破壊する
            Destroy(gameObject);

        }
    }
}
