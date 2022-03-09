using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManager : MonoBehaviour
{
    
    const string cutoffHeight = "_CutoffHeight";
   
    [Range(0.0f,0.017f)]
    [SerializeField] float incrementHeight;
    [Range(0.0f, 0.04f)]
    [SerializeField] float timeBetweenUpdates;
    [SerializeField] Material[] matArray;
    float delay;
    [SerializeField] float timeinSecondAudio;

    //audio MariaV 2.18 = 138 sec.
    // arraymat.lengh
    //valore base delay = 138/arraymat.lengh
  
    void Start()
    {
        delay = timeinSecondAudio / matArray.Length;
        var delayinitialvalue = delay;

        foreach(Material mat in matArray)
        {
            mat.SetFloat(cutoffHeight, -0.5f);
            delay += delayinitialvalue; //aumento il dalay ogni volta che ho un nuovo materiale 
                TestFade(mat, delay);           
        }
    }



    void TestFade(Material matToFade,float delay)
    {       
        Coroutine fadeCoroutine = null;

        if(fadeCoroutine == null)
        {
            IEnumerator _testfade()
            {
                yield return new WaitForSeconds(delay);

                Debug.Log($"Start fade on {matToFade.name}");
                float fadeHeight = 0;
                int testcont = 0;
                while (fadeHeight < 10)
                {
                    //Debug.Log(fadeHeight);
                    fadeHeight += incrementHeight;
                    matToFade.SetFloat(cutoffHeight, fadeHeight);
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
