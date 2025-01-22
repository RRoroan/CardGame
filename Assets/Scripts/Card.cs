using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int idx = 0, cdx = 0;
    string fName;
    public SpriteRenderer frontImage;
    public GameObject front, back;

    public Animator anim;

    AudioSource audioSource;
    public AudioClip clip;

    public Button btn;
    public Vector2 pos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { audioSource = GetComponent<AudioSource>(); }

    public void Setting(int num, string sceneName)
    {
        idx = num / 4;
        cdx = num % 4;
        if (sceneName == "GameScene")
        { fName = "Game"; }
        else
        { fName = "Hobby"; }
        frontImage.sprite = Resources.Load<Sprite>($"FrontImages\\{fName}\\{idx}\\{cdx}");
        frontImage.material = Resources.Load<Material>($"FrontEdges\\Edge{idx}");
    }

    public void OpenCard()
    {
        if (GameManager.instance.secondCard == null)
        {
            audioSource.PlayOneShot(clip);
            CardFlip();

            if (GameManager.instance.firstCard == null)
            { GameManager.instance.firstCard = this; }
            else
            {
                GameManager.instance.secondCard = this;
                GameManager.instance.Matched();
            }
        }
    }

    public void DestroyCard() { Destroy(gameObject, 1f); }

    public void CloseCard()
    {
        Invoke("CardFlip", 1f);
    }
    void CardFlip()
    {
        anim.SetBool("isOpen", !anim.GetBool("isOpen"));
        front.SetActive(!front.activeSelf);
        back.SetActive(!back.activeSelf);
    }
}
