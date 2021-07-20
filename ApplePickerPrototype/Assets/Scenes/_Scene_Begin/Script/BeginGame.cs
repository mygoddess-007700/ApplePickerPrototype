using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BeginGame : MonoBehaviour
{
    private void Start()
    {
        /*查找按钮组件并添加事件(点击事件)*/
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    private void OnClick()
    {
        SceneManager.LoadScene("_Scene_Game");
    }
}
