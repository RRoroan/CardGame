using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelctionBtn : MonoBehaviour
{
    public GameObject StageSelction;
    public AudioClip ButtonClick;
    AudioSource audioSource;
    public void StageSelect()
    {
        if (StageSelction != null)
        {
            StageSelction.SetActive(true);
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(ButtonClick);
        }
        

    }
}
