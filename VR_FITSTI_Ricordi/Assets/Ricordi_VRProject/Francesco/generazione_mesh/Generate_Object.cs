using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Generate_Object : MonoBehaviour
{
    [SerializeField] Material[] diss_material;
    [SerializeField] VideoPlayer playerManager;
    [SerializeField] int indiceScenaNext;
    float delay = 5f;

    const string cutfloat = "_CutoffHeight";

    private void Start()
    {
        //inizia a 20s
        //ne appare uno ogni 10
        playerManager.EnableAudioTrack(0, false);

        foreach(Material mat in diss_material)
        {
            mat.SetFloat(cutfloat, -1f);
        }

        GenerateMaterial(delay);
        StartCoroutine(CaricaScena());
    }

    void GenerateMaterial(float delay)
    {
        IEnumerator _generateMaterial(float delay)
        {
            foreach(Material mat in diss_material)
            {
                yield return new WaitForSeconds(delay);

                Debug.Log("Inizio generate");

                StartCoroutine(_incrementMatCut(mat));

                delay = 13f;
            }   
            
        }

        IEnumerator _incrementMatCut(Material mat)
        {
            float fadeHeight = 0;
            float incrementHeight = 0.025f;
            int count = 0;
            //finchè cut float è < 3
            while (mat.GetFloat(cutfloat) < 3)
            {
                fadeHeight += incrementHeight;
                mat.SetFloat(cutfloat, fadeHeight);
                yield return new WaitForSeconds(0.05f);
                count++;
                Debug.Log("Aumento");

                if (count > 5000)
                {
                    break;
                }
            }

           //aumenta il cut float e aspetta un attimo

        }
        StartCoroutine(_generateMaterial(delay));
    }


    IEnumerator CaricaScena()
    {
        yield return new WaitForSeconds(2);
        while (playerManager.isPlaying)
        {
            yield return null;
            Debug.Log("Sta girando");
        }
        
        CambiaScena(indiceScenaNext);
    }

    private void CambiaScena(int i)
    {
        SceneManager.LoadScene(i);
    }
}
