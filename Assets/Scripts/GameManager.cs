using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject successUI;
    public GameObject failUI;

    float time = 45.00f;
    public GameObject timeObj;

    public Card firstCard, secondCard;
    public int cardCount;

    public static GameManager instance;
    AudioSource audioSource;
    public AudioClip clipMatch, clipNotMatch;

    bool timeIn10 = false;
    public bool isArrangeComplete;

    private void Awake()
    {
        if (instance == null)
        { instance = this; }
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;

        isArrangeComplete = false;

        audioSource = GetComponent<AudioSource>();
        successUI.SetActive(false);
        failUI.SetActive(false);
        SetTimerBasedOnScene();
    }

    private void SetTimerBasedOnScene()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "GameSceneE")
        {
            time = 45.00f;
        }
        else if (sceneName == "GameSceneH")
        {
            time = 25.00f;
        }
        else if (sceneName == "HobbyScene")
        {
            time = 45.00f;
        }
        else if (sceneName == "HobbySceneH")
        {
            time = 25.00f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isArrangeComplete)
            return;

        time -= Time.deltaTime;
        if (time < 10 && !timeIn10 && AudioManager.instance != null)
        {
            AudioManager.instance.SetMusicSpeed(1.5f);
            timeIn10 = true;
        }
        if (time <= 0)
        {
            time = 0;
            ShowFailUI();
            if (AudioManager.instance != null)
            { AudioManager.instance.SetMusicSpeed(1f); }
            Time.timeScale = 0f;
        }

        TimeTextSet();
    }

    public void Matched()
    {
        if (firstCard.idx == secondCard.idx && firstCard.cdx + secondCard.cdx != 3)
        {
            audioSource.PlayOneShot(clipMatch);
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;
            if (cardCount == 0)
            {
                if (AudioManager.instance != null)
                { AudioManager.instance.SetMusicSpeed(1f); }
                ShowSuccessUI();
                Time.timeScale = 0f;
            }
        }
        else
        {
            audioSource.PlayOneShot(clipNotMatch);
            firstCard.CloseCard();
            secondCard.CloseCard();
        }
        firstCard = secondCard = null;
    }
    private void TimeTextSet()
    {
        Text second = timeObj.transform.GetChild(0).GetComponent<Text>();
        Text miniSecond = timeObj.transform.GetChild(2).GetComponent<Text>();

        string secondString = Mathf.Floor(time).ToString();
        second.text = secondString.Length <= 1 ? "0" + secondString : secondString;

        string timeToString = time.ToString("N2");
        string miniSecondString = timeToString[timeToString.Length - 2].ToString() + timeToString[timeToString.Length - 1].ToString();
        miniSecond.text = miniSecondString;
    }

    void ShowSuccessUI()
    {
        successUI.SetActive(true);
    }

    void ShowFailUI()
    {
        failUI.SetActive(true);
    }
}
