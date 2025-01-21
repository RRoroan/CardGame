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

    public void SceneChange()
    {
        if (GameBtn != null)
        {
            AudioManager.instance.ButtonPress(clip);
            SceneManager.LoadScene("GameScene");
        }
        else if (HobbyBtn != null)
        {
            AudioManager.instance.ButtonPress(clip);
            SceneManager.LoadScene("HobbyScene");
        }
    }
}
