using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IsClear : MonoBehaviour
{
    public static IsClear instance;

    public bool isGame = false;
    public bool isHobby = false;
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

    private void Start()
    {
    }
    public void clear()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "GameScene")
        {
            isGame = true;
        }
        else if (sceneName == "HobbyScene")
        {
            isHobby = true;
        }
    }

}
