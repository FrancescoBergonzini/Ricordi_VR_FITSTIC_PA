using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccendiLuceScript : MonoBehaviour
{
    [SerializeField] Light luceMovimento;
    [SerializeField] GameObject lampadinaDaSpegnere;
    [SerializeField] List<GameObject> oggettiDaSpegnere;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PallaTutorial")
        {
            luceMovimento.gameObject.SetActive(true);
            lampadinaDaSpegnere.GetComponent<AudioSource>().Play();
            foreach(var obj in oggettiDaSpegnere)
            {
                obj.SetActive(false);
            }
        }
    }
}
