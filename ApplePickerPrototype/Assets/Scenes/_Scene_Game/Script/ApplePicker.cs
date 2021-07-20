using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")] 
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 3f;
    public List<GameObject> basketList;

    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate(basketPrefab) as GameObject;
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    public void AppleDestroyed()
    {
        //销毁所有下落的苹果
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }
        //销毁一个篮筐
        //获取basketList中最后一个篮筐的序号
        int basketIndex = basketList.Count - 1;
        //取得对该篮筐的引用
        GameObject tBasketGO = basketList[basketIndex];
        //从列表中销毁该篮筐并销毁该游戏对象
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);

        //如果没有篮筐剩余
        if(basketList.Count == 0)
        {
            SceneManager.LoadScene("_Scene_Finish");
        }
    }
}