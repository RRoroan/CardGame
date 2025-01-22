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


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        { Destroy(gameObject); }
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource1 = GetComponent<AudioSource>();
        audioSource1.clip = this.Background;
        audioSource1.Play();
    }

    public void ButtonPress(AudioClip clip)
    {
        audioSource1.PlayOneShot(ButtonClip);
    }
    
    public void SetMusicSpeed(float speed)
    { audioSource1.pitch = speed; }
}
