using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject successUI;
    public GameObject failUI;

    // Start is called before the first frame update
    void Start()
    {
        successUI.SetActive(false);
        failUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
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
