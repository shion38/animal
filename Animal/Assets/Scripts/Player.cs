using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //HP(拠点の体力)
    public int hp;

    //GOLD(所持金)
    public int gold;


    //指定の場所に弓の建設が出来る
    public void CreateBow(Transform t)
    {
        if (gold < 100) return;
        gold -= 100;
        selectBow = Instantiate(bowPrefab, t);
    }

    //選択中の弓のレベルアップが出来る
    public void LevelUpBow()
    {
        if (selectBow == null) return;  //何も選択されていない
        if (gold < 150) return; //所持金が足りない
        gold -= 150;
        //TODO goldを消費して、弓のレベルアップをする
    }

    //選択中の弓の売却が出来る
    public void SellBow()
    {
        if (selectBow == null) return;
        //TODO 本当はレベルに応じて金額が変わる
        gold += 50;
        Destroy(selectBow.gameObject);
        selectBow = null;
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            CreateBow(null);
        }

        if (Input.GetMouseButtonDown(1))
        {
            SellBow();
        }
    }
}