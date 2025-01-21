using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelctionBtn : MonoBehaviour
{
    public GameObject GameBtn;
    public GameObject HobbyBtn;
    public GameObject StartBtn;


    private void Start()
    {

    }
    public void StageSelect()
    {
        GameBtn.SetActive(true);
        HobbyBtn.SetActive(true);
        StartBtn.SetActive(false);
    }

    public void SceneChange()
    {
        if (GameBtn != null)
        {
            SceneManager.LoadScene("GameScene");
        }
        else if (HobbyBtn != null)
        {
            SceneManager.LoadScene("HobbyScene");
        }
    }
}
