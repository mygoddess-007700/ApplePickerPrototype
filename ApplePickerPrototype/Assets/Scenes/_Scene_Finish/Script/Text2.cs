using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Text text2 = this.GetComponent<Text>();
        text2.text = "本次得分：" + Basket.score;
    }
}
