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
        //�������������ƻ��
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }
        //����һ������
        //��ȡbasketList�����һ����������
        int basketIndex = basketList.Count - 1;
        //ȡ�öԸ����������
        GameObject tBasketGO = basketList[basketIndex];
        //���б������ٸ��������ٸ���Ϸ����
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);

        //���û������ʣ��
        if(basketList.Count == 0)
        {
            SceneManager.LoadScene("_Scene_Finish");
        }
    }
}