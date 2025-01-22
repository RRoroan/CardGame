using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEffect : MonoBehaviour
{
    public GameObject main;
    public GameObject btn;
    public float lerpTime;

    private void Awake()
    {
        lerpTime = 0.1f;
        main.transform.localScale = Vector3.one * 0.4f;
        btn.transform.localScale = Vector3.one * 0.4f;
    }

    private void OnEnable()
    {
        StartCoroutine(EffectCo());
    }

    private IEnumerator EffectCo()
    {
        Transform characterTr = main.transform;
        Transform btnTr = btn.transform;

        float time = 0f;

        Vector3 origin = Vector3.one * 0.4f;
        Vector3 firstScale = Vector3.one * 1.2f;
        while (time < lerpTime)
        {
            Vector3 scale = Vector3.Lerp(origin, firstScale, time / lerpTime);
            characterTr.transform.localScale = scale;
            btnTr.transform.localScale = scale;
            time += Time.unscaledDeltaTime;
            yield return null;
        }

        time = 0f;
        while (time < lerpTime)
        {
            Vector3 scale = Vector3.Lerp(firstScale, Vector3.one, time / lerpTime);
            characterTr.transform.localScale = scale;
            btnTr.transform.localScale = scale;
            time += Time.unscaledDeltaTime;
            yield return null;
        }

        characterTr.localScale = Vector3.one;
        btnTr.localScale = Vector3.one;
    }
}
