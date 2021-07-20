using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;
    static public int score = 0;

    private void Start()
    {
        score = 0;
        //查找ScoreCounter游戏对象
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        //获取该游戏对象的GUIText组件
        scoreGT = scoreGO.GetComponent<Text>();
        //将初始分数设置为0
        scoreGT.text = "0";
    }
    void Update()
    {
        //从Input中获取鼠标在屏幕中的当前位置
        Vector3 mousePos2D = Input.mousePosition;
        
        //摄像机的z坐标决定在三维空间中将鼠标沿z轴向前移动多远
        mousePos2D.z = -Camera.main.transform.position.z;
        
        //将该点从二维屏幕空间转换成三维游戏世界空间
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        
        //将篮筐的x位置移动到鼠标处的x位置处
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }
    
    //下面是实现接住苹果功能
    void OnCollisionEnter(Collision coll)
    {
        //检查与篮筐碰撞的是什么对象
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Apple"))
        {
            Destroy(collidedWith);
        }

        //将scoreGT转换为整数值
        score = int.Parse(scoreGT.text);
        //每次接住苹果就为玩家加分
        score += 100;
        //将分数转换成字符串显示在屏幕上
        scoreGT.text = score.ToString();
        //监视最高分
        if(score>HighScore.score)
        {
            HighScore.score = score;
        }
    }
}