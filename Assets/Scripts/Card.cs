using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int idx = 0, cdx = 0;
    string name;
    public SpriteRenderer frontImage;
    public GameObject front, back;

    public Animator anim;

    AudioSource audioSource;
    public AudioClip clip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { audioSource = GetComponent<AudioSource>(); }

    public void Setting(int num, string sceneName)
    {
        idx = num/4;
        cdx = num%4;
        if(sceneName=="MainScene")
        { name = "Game"; }
        else
        { name = "Hobby"; }
        frontImage.sprite = Resources.Load<Sprite>($"FrontImages\\{name}\\{idx}\\{cdx}");
        frontImage.material = Resources.Load<Material>($"FrontEdges\\Edge{idx}");
    }

    //public void OpenCard()
    //{
    //    if (GameManager.instance.secondCard == null)
    //    {
    //        audioSource.PlayOneShot(clip);
    //        anim.SetBool("isOpen", true);

    //        if (GameManager.instance.firstCard == null)
    //        { GameManager.instance.firstCard = this; }
    //        else
    //        {
    //            GameManager.instance.secondCard = this;
    //            GameManager.instance.Matched();
    //        }
    //    }
    //}

    public void DestroyCard() { Destroy(gameObject, 1f); }

    public void CloseCard()
    {
        anim.SetBool("isOpen", false);
        Invoke("CardFlip", 1f);
    }
    void CardFlip()
    {
        front.SetActive(!front.activeSelf);
        back.SetActive(!back.activeSelf);
    }
}
