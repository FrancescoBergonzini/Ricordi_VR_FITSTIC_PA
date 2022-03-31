using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TriggerCarillonAnimation : MonoBehaviour
{
    [SerializeField] Transform coperchioCarillon;
    [SerializeField] float angle;
    [SerializeField] float duration;

    bool triggered;

    private void Start()
    {
        triggered = false; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !triggered)
        {            
            InitCarillon();
            triggered = true;
        }
    }

    void InitCarillon()
    {
        coperchioCarillon.DOLocalRotate(new Vector3(angle, 0, 0), duration);
        gameObject.SetActive(false);
        AudioManager.Instance.PlayAudioSource(1, 0f);
    }
}
