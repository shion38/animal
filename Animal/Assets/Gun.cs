using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Gun : MonoBehaviour
{

    //プレイヤーオブジェクト
    //public GameObject Enemy;
    //弾のプレハブオブジェクト
    public GameObject tama;

    //public GameObject targetObj;


    //一秒ごとに弾を発射するためのもの
    private float targetTime = 1f;
    private float currentTime = 0;
    private GameObject target;

    // Update is called once per frame
    void FixedUpdate()
    {
        target = GameObject.FindWithTag("Player");

        if (Vector3.Distance(transform.position, target.transform.position) < 5f)
        {
            //一秒経つごとに弾を発射する
            currentTime += Time.deltaTime;
            if (targetTime < currentTime)
            {
                currentTime = 0;
                //銃の座標を変数posに保存
                var pos = this.gameObject.transform.position;
                //弾のプレハブを作成
                var t = Instantiate(tama) as GameObject;
                //弾のプレハブの位置を敵の位置にする
                t.transform.position = pos;
                //銃から敵に向かうベクトルをつくる
                //敵の位置から銃の位置（弾の位置）を引く
                Vector2 vec = (target.transform.position - pos) * 3;
                //弾のRigidBody2Dコンポネントのvelocityに先程求めたベクトルを入れて力を加える
                t.GetComponent<Rigidbody2D>().velocity = vec;
            }

        }

    }
}
