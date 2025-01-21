using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelctionBtn : MonoBehaviour
{
    public GameObject StageSelction;
    

    public void StageSelect()
    {
        StageSelction.SetActive(true);
    }
}
