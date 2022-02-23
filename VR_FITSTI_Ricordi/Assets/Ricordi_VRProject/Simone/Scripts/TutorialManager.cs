using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject porta;
    [SerializeField] Light luceMovimento;
    bool luceCheSiSpegne = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (porta.transform.rotation.z > 0.26f && !luceCheSiSpegne)
        {
            luceCheSiSpegne = true;
            StartCoroutine(SpegniLuceGradualmente());
        }
    }

    IEnumerator SpegniLuceGradualmente()
    {
        while (luceMovimento.intensity > 0)
        {
            luceMovimento.intensity -= 0.8f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
