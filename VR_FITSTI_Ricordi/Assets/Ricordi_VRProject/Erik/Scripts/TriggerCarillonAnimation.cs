using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TriggerCarillonAnimation : MonoBehaviour
{
    [SerializeField] Transform coperchioCarillon;
    [SerializeField] float angle;
    [SerializeField] float duration;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            InitCarillon();
           
        }
    }

    void InitCarillon()
    {
        coperchioCarillon.DOLocalRotate(new Vector3(angle, 0, 0), duration);
        gameObject.SetActive(false);
    }
}
