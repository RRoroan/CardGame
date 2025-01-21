using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource1;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        audioSource1 = GetComponent<AudioSource>();
        audioSource1.clip = this.clip;
        audioSource1.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
