using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeAudio : MonoBehaviour
{
    
    Slider soundSlider;
    public float nowVo = 0.05f;

    //GameObject 

    // Start is called before the first frame update
    void Start()
    {

        soundSlider = GetComponent<Slider>();

        float maxVo = 0.5f;
        
        


        //スライダーの最大値の設定
        soundSlider.maxValue = maxVo;

        //スライダーの現在値の設定
        soundSlider.value = nowVo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Method()
    {
         nowVo = soundSlider.value;

    }
}
