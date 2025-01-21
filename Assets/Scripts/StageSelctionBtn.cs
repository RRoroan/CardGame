using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelctionBtn : MonoBehaviour
{
    public GameObject GameBtn;
    public GameObject HobbyBtn;

    public AudioClip ButtonClick;
    AudioSource audioSource2;

    public void StageSelect()
    {
        if (GameBtn != null)
        {
            GameBtn.SetActive(true);
            HobbyBtn.SetActive(true);
            audioSource2 = GetComponent<AudioSource>();
            audioSource2.PlayOneShot(ButtonClick);


        }

        gameObject.SetActive(false);
    }

    public void SceneChage()
    {
        audioSource2 = GetComponent<AudioSource>();
        audioSource2.PlayOneShot(ButtonClick);
        SceneManager.LoadScene("MainScene");
    }
}
