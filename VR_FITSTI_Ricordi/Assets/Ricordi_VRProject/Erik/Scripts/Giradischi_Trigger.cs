using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giradischi_Trigger : MonoBehaviour
{
    bool isRemoved;
    private void Awake()
    {
        isRemoved = false;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Bambola" && !isRemoved)
        {
            Debug.LogError("GAMBA TOLTA");
            isRemoved = true;
        }
    }
}
