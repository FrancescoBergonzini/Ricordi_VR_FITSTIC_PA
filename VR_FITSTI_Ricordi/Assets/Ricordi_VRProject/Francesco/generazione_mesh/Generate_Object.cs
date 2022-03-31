using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate_Object : MonoBehaviour
{
    [SerializeField] Material[] diss_material;
    float delay = 5f;

    private void Start()
    {
        //inizia a 20s
        //ne appare uno ogni 10
        GenerateMaterial(delay);
       
    }

    void GenerateMaterial(float delay)
    {
        IEnumerator _generateMaterial(float delay)
        {
            foreach(Material mat in diss_material)
            {
                yield return new WaitForSeconds(delay);
                mat.SetFloat("_CutoffHeight", -0.5f);

                delay = 10;
            }         
        }
        StartCoroutine(_generateMaterial(delay));
    }
}
