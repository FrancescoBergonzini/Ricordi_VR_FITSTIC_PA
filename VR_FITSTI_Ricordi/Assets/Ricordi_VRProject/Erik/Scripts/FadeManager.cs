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
    [SerializeField] Material[] matArray;
  
    void Start()
    {
        Debug.Log(prova.GetFloat(fadePos));
        foreach(Material mat in matArray)
        {
            mat.SetFloat(fadePos, 0);
        }

        TestFade(matArray[0]);
        TestFade(matArray[1]);

    }

     void TestFade(Material matToFade)
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
                    matToFade.SetFloat(fadePos, fadeHeight);
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
