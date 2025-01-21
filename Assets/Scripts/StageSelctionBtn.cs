using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelctionBtn : MonoBehaviour
{
    public GameObject StageSelction;
    public AudioClip ButtonClick;
    AudioSource audioSource2;
    public void StageSelect()
    {
        if (StageSelction != null)
        {
            StageSelction.SetActive(true);
            audioSource2 = GetComponent<AudioSource>();
            audioSource2.PlayOneShot(ButtonClick);
        }
        

    }
}
