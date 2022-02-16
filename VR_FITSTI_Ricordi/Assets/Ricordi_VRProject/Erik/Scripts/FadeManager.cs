using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManager : MonoBehaviour
{
    [SerializeField] Material prova;
    const string fadePos = "FadePos";
    [SerializeField] float fadeHeight=0;
    [Range(0.0f,0.017f)]
    [SerializeField] float incrementHeight;
    [Range(0.0f, 0.04f)]
    [SerializeField] float timeBetweenUpdates;
  
    void Start()
    {
        Debug.Log(prova.GetFloat(fadePos));
        Testfade();

    }

     void Testfade()
    {
        
        Coroutine fadeCoroutine = null;
        if(fadeCoroutine == null)
        {
            IEnumerator _testfade()
            {
                int testcont = 0;
                while (fadeHeight < 10)
                {
                    Debug.Log(fadeHeight);
                    fadeHeight += incrementHeight;
                    prova.SetFloat(fadePos, fadeHeight);
                    yield return new WaitForSeconds(timeBetweenUpdates);
                    testcont++;

                    if (testcont > 500)
                    {
                        Debug.Log("fade completed and stopped");
                        break;
                    }
                        
                }
                
            }

            fadeCoroutine = StartCoroutine(_testfade());
        }
        
    }

    
}
