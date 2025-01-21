using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //public GameObject successUI;
    //public GameObject failUI;

    float time = 30f;
    public Text timeTxt;

    public Card firstCard, secondCard;
    public int cardCount;

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        { instance = this; }
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        //successUI.SetActive(false);
        //failUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            time = 0;
            ShowFailUI();
            Time.timeScale = 0f;
        }
        timeTxt.text = time.ToString("N2");
    }

    public void Matched()
    {
        if (firstCard.idx == secondCard.idx && firstCard.cdx + secondCard.cdx != 3)
        {
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;
            if (cardCount == 0)
            {
                ShowSuccessUI();
                Time.timeScale = 0f;
            }
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }
        firstCard = secondCard = null;
    }

    void ShowSuccessUI()
    {
        //successUI.SetActive(true);
    }

    void ShowFailUI()
    {
        //failUI.SetActive(true);
    }
}
