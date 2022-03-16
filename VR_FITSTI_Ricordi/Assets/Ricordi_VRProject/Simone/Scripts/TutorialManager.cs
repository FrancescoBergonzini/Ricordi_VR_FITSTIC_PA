using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using TMPro;
using DG.Tweening;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject porta;
    [SerializeField] Light luceMovimento;
    [SerializeField] TMP_Text testoSX;
    [SerializeField] TMP_Text testoDX;
    bool luceCheSiSpegne = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (porta.transform.rotation.z > 0.10f && !luceCheSiSpegne)
        {
            luceCheSiSpegne = true;
            luceMovimento.DOIntensity(0, 1).OnComplete(()=> {
                StartCoroutine(SceneManagerScript.ChangeScene(1));
            });
            //StartCoroutine(SpegniLuceGradualmente());
        }
        if (InputBridge.Instance.LeftThumbstickAxis != Vector2.zero)
        {
            testoSX.gameObject.SetActive(false);
        }
        if (InputBridge.Instance.RightThumbstickAxis.x != 0)
        {
            testoDX.gameObject.SetActive(false);
        }
    }

    IEnumerator SpegniLuceGradualmente()
    {
        while (luceMovimento.intensity > 0)
        {
            luceMovimento.intensity -= 1.5f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
