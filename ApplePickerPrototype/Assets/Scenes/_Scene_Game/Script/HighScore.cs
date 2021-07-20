using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighScore : MonoBehaviour
{
    static public int score = 1000;

    private void Awake()
    {
        //���PlayerPrefs HighScore�Ѿ����ڣ����ȡ��ֵ
        if(PlayerPrefs.HasKey("HighScore"))
        {
            score = PlayerPrefs.GetInt("HighScore");
        }
        //����߷ָ���HighScore
        PlayerPrefs.SetInt("HighScore", score);
        PlayerPrefs.SetInt("ScoreLastMax", score);
    }

    void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "��߷�: " + score;
        //���б�Ҫ�������PlayerPrefs HighScore
        if(score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
