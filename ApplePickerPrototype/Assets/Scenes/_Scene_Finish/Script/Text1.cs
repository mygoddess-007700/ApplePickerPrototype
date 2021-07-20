using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Text text1 = this.GetComponent<Text>();
        text1.text = "历史最高得分：" + PlayerPrefs.GetInt("ScoreLastMax");
    }
}
