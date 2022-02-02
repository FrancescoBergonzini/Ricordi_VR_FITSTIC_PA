using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Test_Input_Debugger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        foreach (string controllerName in Input.GetJoystickNames())
        {
            Debug.Log(controllerName);
        }
    }
}
