using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcolaDistanzaScript : MonoBehaviour
{
    [SerializeField]Transform oggettoADistanza;
    [SerializeField] List<GameObject> oggettiDaAttivare;
    [SerializeField] float distanza;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Distanza: " + Vector3.Distance(this.transform.position, oggettoADistanza.position));
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(this.transform.position, oggettoADistanza.position) < distanza)
        {
            foreach(var obj  in oggettiDaAttivare)
            {
                obj.SetActive(true);
            }
        }
    }
}
