using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Board : MonoBehaviour
{

    public GameObject card;
    string sceneName;
    //public RectTransform canvers;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        int[] arr = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };
        arr = arr.OrderBy(x => Random.Range(0f, 7f)).ToArray();
        for (int i = 0; i < 20; i++)
        {
            GameObject go = Instantiate(card, this.transform);
            float x = (i % 4) * 1.4f - 2.1f;
            float y = (i / 4) * 1.4f - 4.0f;
            go.transform.position = new Vector2(x, y);

            go.GetComponent<Card>().Setting(arr[i], sceneName);
        }

        //transform.localScale = canvers.;

        GameManager.instance.cardCount = arr.Length;
    }
}
