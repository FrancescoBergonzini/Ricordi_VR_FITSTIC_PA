using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuceMovimentoScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Light>().intensity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        StartCoroutine(AumentaIntensita());
    }

    IEnumerator AumentaIntensita()
    {
        while (GetComponent<Light>().intensity < 26)
        {
            GetComponent<Light>().intensity += 0.5f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
