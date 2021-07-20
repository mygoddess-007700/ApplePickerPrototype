using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Record : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject textT = GameObject.Find("TextT");
        if (HighScore.score <= PlayerPrefs.GetInt("ScoreLastMax"))
            textT.GetComponent<TMP_Text>().text = "Please Keeping Trying";
        else
            textT.GetComponent<TMP_Text>().text = "You make a new recode";
    }
}
