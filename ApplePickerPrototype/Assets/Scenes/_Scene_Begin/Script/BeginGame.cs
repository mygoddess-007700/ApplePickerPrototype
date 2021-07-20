using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BeginGame : MonoBehaviour
{
    private void Start()
    {
        /*���Ұ�ť���������¼�(����¼�)*/
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    private void OnClick()
    {
        SceneManager.LoadScene("_Scene_Game");
    }
}
