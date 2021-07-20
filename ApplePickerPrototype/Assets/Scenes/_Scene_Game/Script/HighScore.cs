using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighScore : MonoBehaviour
{
    static public int score = 1000;

    private void Awake()
    {
        //如果PlayerPrefs HighScore已经存在，则读取其值
        if(PlayerPrefs.HasKey("HighScore"))
        {
            score = PlayerPrefs.GetInt("HighScore");
        }
        //将最高分赋给HighScore
        PlayerPrefs.SetInt("HighScore", score);
        PlayerPrefs.SetInt("ScoreLastMax", score);
    }

    void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "最高分: " + score;
        //如有必要，则更新PlayerPrefs HighScore
        if(score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
