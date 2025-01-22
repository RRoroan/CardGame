using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public AudioClip clip;
    public void ReturnScene()
    {
        AudioManager.instance.ButtonPress(clip);
        SceneManager.LoadScene("StartScene");
    }
    public void RetryScene()
    {
        AudioManager.instance.ButtonPress(clip);
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
    public void HiddenScene()
    {
        AudioManager.instance.ButtonPress(clip);
        SceneManager.LoadScene("HiddenScene");
    }
}
