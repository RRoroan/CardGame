using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Board : MonoBehaviour
{

    public GameObject card;
    string sceneName;

    List<GameObject> cardObjs = new List<GameObject>();

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
            go.transform.position = Vector2.down;

            Card goCard = go.GetComponent<Card>();
            goCard.pos = new Vector2(x, y);
            goCard.btn.enabled = false;
            goCard.GetComponent<Animator>().enabled = false;

            go.GetComponent<Card>().Setting(arr[i], sceneName);

            cardObjs.Add(go);
        }

        GameManager.instance.cardCount = arr.Length;


        StartCoroutine(ArrangeCo());
    }

    IEnumerator ArrangeCo()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < cardObjs.Count; i++)
        {
            float lerpValue = 0.1f;
            float time = 0f;
            GameObject card = cardObjs[i];
            Vector2 originPos = cardObjs[i].transform.position;
            Vector2 arrangePos = card.GetComponent<Card>().pos;

            AudioManager.instance.FlipSound();
            while (time < lerpValue)
            {
                card.transform.position = Vector2.Lerp(originPos, arrangePos, time / lerpValue);
                time += Time.deltaTime;
                yield return null;
            }

            if (time >= lerpValue)
                card.transform.position = card.GetComponent<Card>().pos;
        }

        CardActive();
        GameManager.instance.isArrangeComplete = true;
    }

    private void CardActive()
    {
        for (int i = 0; i < cardObjs.Count; i++)
        {
            cardObjs[i].GetComponent<Card>().btn.enabled = true;
            cardObjs[i].GetComponent<Animator>().enabled = true;
        }
    }
}
