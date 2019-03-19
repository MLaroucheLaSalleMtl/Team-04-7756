using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    private string currentButton;
    private string currentAxis;
    private float axisInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        getAxis();
        //getButton();
    }

    //private void getButton()
    //{
    //    throw new NotImplementedException();
    //}

    private void getAxis()
    {
        if (Input.GetAxisRaw("Right Stick Horizontal Turn") > 0.3f || Input.GetAxisRaw("Right Stick Horizontal Turn") < -0.3f)
        {
            currentAxis = "Right Stick Horizontal Turn";
            axisInput = Input.GetAxisRaw("Right Stick Horizontal Turn");
        }
        if (Input.GetAxisRaw("Right Stick Vertical Turn") > 0.3f || Input.GetAxisRaw("Right Stick Vertical Turn") < -0.3f)
        {
            currentAxis = "Right Stick Vertical Turn";
            axisInput = Input.GetAxisRaw("Right Stick Vertical Turn");
        }

    }
}
