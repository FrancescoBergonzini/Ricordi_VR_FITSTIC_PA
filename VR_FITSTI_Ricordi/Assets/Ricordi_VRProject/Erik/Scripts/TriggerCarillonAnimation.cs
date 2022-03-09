using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TriggerCarillonAnimation : MonoBehaviour
{
    [SerializeField] Transform coperchioCarillon;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            InitCarillon();
           
        }
    }

    void InitCarillon()
    {
        coperchioCarillon.DOLocalRotate(new Vector3(90, 0, 0), 4f);
        gameObject.SetActive(false);
    }
}
