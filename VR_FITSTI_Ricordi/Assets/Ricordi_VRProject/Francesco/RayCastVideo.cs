using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastVideo : MonoBehaviour
{
    [SerializeField] LayerMask myLayer;
    [SerializeField] List<MeshRenderer> pannelli;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit infoHit;
        if (Physics.Raycast(transform.position, fwd,out infoHit, Mathf.Infinity, myLayer))
        {
            GameObject hitted = infoHit.collider.gameObject;
            print("There is something in front of the object!\n" + hitted.name);
            foreach(var pan in pannelli)
            {
                if (pan.gameObject.name != hitted.name)
                    pan.enabled = false;
            }
            hitted.GetComponent<MeshRenderer>().enabled = true;

        }
    }
}
