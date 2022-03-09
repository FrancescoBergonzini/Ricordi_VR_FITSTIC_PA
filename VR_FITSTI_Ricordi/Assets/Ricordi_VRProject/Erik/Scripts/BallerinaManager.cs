using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;



namespace BNG
{
    public class BallerinaManager : MonoBehaviour
    {
        [SerializeField] Transform midAirPoint;
        [SerializeField] Transform[] pezziPos;

        private void OnTriggerEnter(Collider other)
        {
            // l'oggetto per un attimo cade, sistemare questa cosa
            if (other.GetComponent<Grabbable>() != null)
            {
                Grabbable obj = other.GetComponent<Grabbable>();
                Rigidbody obj_rb= other.gameObject.GetComponent<Rigidbody>();
                if (obj.BeingHeld)
                {
                    Debug.Log("Devi mollare obj");
                    return;
                }
                else
                {
                    Debug.Log("Parte il tween");
                    obj_rb.isKinematic = true;
                    pezziPos[0].transform.GetChild(0).transform.DOMove(midAirPoint.transform.position, 4f).OnComplete(() =>
                    pezziPos[0].transform.GetChild(0).transform.DOLocalMove(Vector3.zero, 4f));
                }
                
            }
        }

    }
}
