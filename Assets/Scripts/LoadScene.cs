using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void ReturnScene()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void RetryScene()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

    public void ClickSound()
    {
        AudioManager.instance.ButtonPress();
    }
}
