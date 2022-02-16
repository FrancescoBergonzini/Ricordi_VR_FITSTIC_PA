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
  
    void Start()
    {
       
        foreach(Material mat in matArray)
        {
            mat.SetFloat(cutoffHeight, -0.5f);
            if (mat != matArray[0])
            {
                TestFade(mat, Random.Range(1, 15f));
            }
            else
            {
                TestFade(mat, 0.5f);
            }
           
        }

       // TestFade(matArray[0], 1);
        //TestFade(matArray[1], 6);
        //TestFade(matArray[1]);

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
