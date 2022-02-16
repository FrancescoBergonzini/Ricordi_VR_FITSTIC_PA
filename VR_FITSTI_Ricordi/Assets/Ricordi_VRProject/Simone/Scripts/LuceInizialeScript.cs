using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuceInizialeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AumentaIntensita());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator AumentaIntensita()
    {
        while (GetComponent<Light>().intensity < 40)
        {
            GetComponent<Light>().intensity += 1;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
