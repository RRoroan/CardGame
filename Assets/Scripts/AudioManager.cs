using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    AudioSource audioSource1;
    public AudioClip Background;
    public AudioClip ButtonClip;
    public GameObject StartBtn;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource1 = GetComponent<AudioSource>();
        audioSource1.clip = this.Background;
        audioSource1.Play();
    }

    public void ButtonPress()
    {
        Input.GetMouseButtonDown(0);
        audioSource1.PlayOneShot(ButtonClip);
    }
    
}
