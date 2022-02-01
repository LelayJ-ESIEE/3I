using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kryz.Tweening;
using System;
using Random = UnityEngine.Random;

public class TestCoroutines : MonoBehaviour
{
    [SerializeField] AudioSource m_AudioSource;

    IEnumerator m_MultiTransCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(MyFirstCoroutine(2));
        //StartCoroutine(MyUpdateCoroutine());

        //StartCoroutine(TranslationCoroutine(
        //    transform.position, transform.position + Random.onUnitSphere * 5, 4,EasingFunctions.InOutElastic, 
        //    ()=> { m_AudioSource.pitch = 0.5f; m_AudioSource.Play(); MyTools.ChangeColorRandom(gameObject); },
        //    () => { m_AudioSource.pitch = 1f; m_AudioSource.Play(); MyTools.ChangeColorRandom(gameObject); }));

        //StartCoroutine(ScaleCoroutine(transform.localScale, transform.localScale * 3, 5));

        
    }

    IEnumerator MyFirstCoroutine(float waitDuration)
    {
        MyTools.Log("MyFirstCoroutine START");

        yield return new WaitForSeconds(waitDuration);
        //yield return null;

        MyTools.Log("MyFirstCoroutine END");
    }

    IEnumerator MyUpdateCoroutine()
    {
        MyTools.Log("MyUpdateCoroutine START");

        while (true)
        {
            MyTools.Log("MyUpdateCoroutine UPDATE");
            transform.Rotate(Vector3.up, Time.deltaTime*10);
            yield return null;
        }

        MyTools.Log("MyUpdateCoroutine END");
    }

    IEnumerator MultiTranslationsCoroutine(int nTranslations)
    {
        for (int i = 0; i < nTranslations; i++)
        {
            yield return StartCoroutine(TranslationCoroutine(
                transform.position, transform.position + Random.onUnitSphere * 5, 1, EasingFunctions.InOutElastic,
                () => { m_AudioSource.pitch = 0.5f; m_AudioSource.Play(); MyTools.ChangeColorRandom(gameObject); },
                () => { m_AudioSource.pitch = 1f; m_AudioSource.Play(); MyTools.ChangeColorRandom(gameObject); }));
        }
    }

    IEnumerator TranslationCoroutine(Vector3 startPos,Vector3 endPos, float duration,
        EasingFunctions.EasingFunctionsDelegate easingFunc, Action startAction,Action endAction)
    {
        if (startAction != null) startAction();

        float elapsedTime = 0;
        while(elapsedTime<duration)
        {
            // dernière rentrée dans la boucle .... elapsedTime proche de duration ... mais <  .... 99,9% de duration
            float k = elapsedTime / duration;
            transform.position = Vector3.Lerp(startPos, endPos, easingFunc(k));

            elapsedTime += Time.deltaTime;
            if (k > 0.5f) yield break; // on sort de la coroutine manu militari
            yield return null;
        }

        transform.position = endPos;

        if (endAction != null) endAction();
    }

    IEnumerator ScaleCoroutine(Vector3 startScale, Vector3 endScale, float duration)
    {
        float elapsedTime = 0;
        while (elapsedTime < duration)
        {
            // dernière rentrée dans la boucle .... elapsedTime proche de duration ... mais <  .... 99,9% de duration
            float k = elapsedTime / duration;
            transform.localScale = Vector3.Lerp(startScale, endScale, 1-(0.5f*(Mathf.Sin(k*Mathf.PI*2*4 + Mathf.PI / 2) +1)));

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = startScale;
    }

    private void OnGUI()
    {
        if(GUI.Button(new Rect(10,10,250,50),"STOP ALL COROUTINES"))
        {
            StopAllCoroutines();
        }

        if (GUI.Button(new Rect(10, 70, 250, 50), "START MultiTranslationsCoroutine"))
        {
            m_MultiTransCoroutine = MultiTranslationsCoroutine(10);
            StartCoroutine(m_MultiTransCoroutine);
        }
        if (GUI.Button(new Rect(10, 120, 250, 50), "STOP MultiTranslationsCoroutine"))
        {
            StopCoroutine(m_MultiTransCoroutine);
            m_MultiTransCoroutine = null;
        }
    }


}
