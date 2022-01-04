using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    private const int maxHp = 10;  // 敵キャラのHP最大値を100とする
    private int currentHp;      // 現在のHP
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = maxHp;    // Sliderの最大値を敵キャラのHP最大値と合わせる
        currentHp = maxHp;      // 初期状態はHP満タン
        slider.value = currentHp;
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("bullet"))    // 弾とぶつかったとき
		{
			currentHp -= 5;        // 現在のHPを減らす
			slider.value = currentHp;   // Sliderに現在HPを適用
			Debug.Log("slider.value = " + slider.value);

			// HPが0になったら
			if (slider.value <= 0)
			{
				Destroy(gameObject);            // 物体を消去
				Destroy(GameObject.Find("Slider")); // Sliderも消去
			}
		}
	}
}
