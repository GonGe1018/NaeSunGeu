using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectManager : MonoBehaviour
{
    public Coroutine effectCo;
    [SerializeField] private Image fadeImg;

    private void Start()
    {
        InitEffect();
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void StartEffect(int effectId, float param = default, GameObject getGameObject = default)
    {
        if (param == -1)
        {
            print($"{effectId}번 이펙트의 파라미터가 없음");
        }
        switch (effectId)
        {
            case 1://fade in
                effectCo = StartCoroutine(FadeIn(param));
                break;
            case 2://fade out
                effectCo = StartCoroutine(FadeOut(param));
                break;
            case 3://zoom background
                effectCo = StartCoroutine(ZoomBackground(param, getGameObject));
                break;
        }
    }

    public void InitEffect()
    {
        fadeImg.color = new Color(0, 0, 0, 0);
    }
    
    public void StopEffect()
    {
        if (effectCo != null)
        {
            StopCoroutine(effectCo);
            effectCo = null;
        }
        
    }
    
    IEnumerator FadeIn(float time)
    {
        if (time == default) time = 3f;
        fadeImg.color = new Color(0, 0, 0, 1);
        while (fadeImg.color.a > 0.0f)
        {
            fadeImg.color = new Color(0, 0, 0, fadeImg.color.a - (Time.deltaTime / time));
            yield return null;
        }
        effectCo = null;
    }
    
    IEnumerator FadeOut(float time)
    {
        if (time == default) time = 3f;
        fadeImg.color = new Color(0, 0, 0, 0);
        while (fadeImg.color.a <= 1.0f)
        {
            fadeImg.color = new Color(0, 0, 0, fadeImg.color.a + (Time.deltaTime / time));
            yield return null;
        }
        effectCo = null;
    }

    IEnumerator ZoomBackground(float scale, GameObject getGameObject)
    {
        
        if (getGameObject == null ||getGameObject.GetComponent<RectTransform>() == null)
        {
            Debug.LogError("error");
            yield break;
        }
        RectTransform rectTransform = getGameObject.GetComponent<RectTransform>();
        if (getGameObject == default || scale == default)
        {
            yield break;
        }
        Vector3 originScale = rectTransform.localScale;
        float nowScale = 0;

        while (nowScale < scale)
        {
            rectTransform.localScale =
                new Vector3(originScale.x + nowScale, originScale.y + nowScale, originScale.z);
            nowScale += 2 * Time.deltaTime;
            yield return null;
        }
        effectCo = null;
    }
}
