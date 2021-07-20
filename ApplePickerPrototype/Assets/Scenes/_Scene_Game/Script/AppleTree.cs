//收获：不要忘了说明是MonoBehaviour的子类，否则，例如Invoke，Instantia都无法使用
//时间：2021.6.17
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    //用来初始化苹果实例的预设
    public GameObject applePrefab;
    
    //苹果树移动的速度
    public float speed = 10f;
    
    //苹果树的活动区域，到达边界时则改变方向
    public float leftAndRightEdge = 20f;
    
    //苹果树改变方向的概率
    public double chanceToChangeDirections = 0.00001;

    //苹果出现的时间间隔
    public float[] secondsBetweenAppleDrops;

    public int appleDropstimes = 0; //不能使用静态变量

    void Start()
    {
        secondsBetweenAppleDrops = new float[5] { 1f, 0.8f, 0.6f, 0.4f, 0.2f};
        //每秒掉落一个苹果
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        appleDropstimes++;
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        if(appleDropstimes <= 10)
            Invoke("DropApple", secondsBetweenAppleDrops[0]);
        else if(appleDropstimes > 10 && appleDropstimes <= 20)
        {
            apple.GetComponent<Rigidbody>().AddForce(Vector3.down * 9.81f * apple.GetComponent<Rigidbody>().mass * 50);
            Invoke("DropApple", secondsBetweenAppleDrops[1]);
        }
        else if(appleDropstimes > 20 && appleDropstimes <= 30)
        {
            apple.GetComponent<Rigidbody>().AddForce(Vector3.down * 9.81f * apple.GetComponent<Rigidbody>().mass * 100);
            Invoke("DropApple", secondsBetweenAppleDrops[2]);
        }
        else if(appleDropstimes > 30 && appleDropstimes <= 50)
        {
            apple.GetComponent<Rigidbody>().AddForce(Vector3.down * 9.81f * apple.GetComponent<Rigidbody>().mass * 200);
            Invoke("DropApple", secondsBetweenAppleDrops[3]);
        }
        else
        {
            apple.GetComponent<Rigidbody>().AddForce(Vector3.down * 9.81f * apple.GetComponent<Rigidbody>().mass * 300);
            Invoke("DropApple", secondsBetweenAppleDrops[4]);
        }
    }
    
    void Update()
    {
        //基本运动（让游戏中的运动基于时间，即帧率改变，游戏运动每秒位移不改变）
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime; //deltaTime从上一帧到现在的秒数
        transform.position = pos;
        //改变方向
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); //向右运动
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); //向左运动
        }
    }

    private void FixedUpdate() //50 * 0.02 = 1
    {
        //随机改变运动方向
        if (Random.value < chanceToChangeDirections) //value包括0和1
        {
            speed *= -1; //改变方向
        }
    }
}