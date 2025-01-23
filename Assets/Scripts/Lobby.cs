using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelctionBtn : MonoBehaviour
{
    public GameObject GameBtn;
    public GameObject HobbyBtn;
    public GameObject StartBtn;
    public AudioClip clip;
    public GameObject EasyBtn1;
    public GameObject HardBtn1;
    public GameObject HardBtn2;
    public GameObject EasyBtn2;
    public GameObject HardBtnL;
    public GameObject HardBtnR;

    private void Start()
    {
        Time.timeScale = 1.0f;
    }

    public void StageSelect()
    {
        AudioManager.instance.ButtonPress(clip);
        GameBtn.SetActive(true);
        HobbyBtn.SetActive(true);
        StartBtn.SetActive(false);
    }


    public void GameModeSelect()
    {
        AudioManager.instance.ButtonPress(clip);
        GameBtn.SetActive(false);
        HobbyBtn.SetActive(false);
        EasyBtn1.SetActive(true);
        HardBtnL.SetActive(true);
        if (IsClear.instance.isGame)
        {
            HardBtn1.SetActive(true);
            HardBtnL.SetActive(false);
        }
    }

    public void HobbyModeSelect()
    {
        AudioManager.instance.ButtonPress(clip);
        GameBtn.SetActive(false);
        HobbyBtn.SetActive(false);
        EasyBtn2.SetActive(true);
        HardBtnR.SetActive(true);
        if (IsClear.instance.isHobby)
        {
            HardBtn2.SetActive(true);
            HardBtnR.SetActive(false);
        }
    }
    public void SceneChange()
    {
        if (EasyBtn1 != null)
        {
            AudioManager.instance.ButtonPress(clip);
            SceneManager.LoadScene("GameScene");
        }
        else if (HardBtn1 != null)
        {
            AudioManager.instance.ButtonPress(clip);
            SceneManager.LoadScene("GameSceneH");
        }
        else if (HardBtn2 != null)
        {
            AudioManager.instance.ButtonPress(clip);
            SceneManager.LoadScene("HobbySceneH");
        }
        else if (EasyBtn2 != null)
        {
            AudioManager.instance.ButtonPress(clip);
            SceneManager.LoadScene("HobbyScene");
        }
    }
}
