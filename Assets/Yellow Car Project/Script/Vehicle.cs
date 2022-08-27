using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class Vehicle : MonoBehaviour
{
    //Whells
    public WheelCollider wheel_FR, wheel_FL;
    public WheelCollider wheel_BR, wheel_BL;
    
    //Vehicle settings
    public float motorForce;
    public float brakForce;
    public float wheelCurve;
    
    //Controller:
    float v;
    float h;
    bool brake;

    // Update is called once per frame
    void Update()
    {
            
            //Keyboard:
            v = Input.GetAxis("Vertical") * motorForce;
            h = Input.GetAxis("Horizontal") * wheelCurve;

            //Acceleration:
            wheel_BR.motorTorque = v * (1);
            wheel_BL.motorTorque = v * (1);
            
            //Curve:
            wheel_FR.steerAngle = h;
            wheel_FL.steerAngle = h;

            //Brake:
            if(Input.GetKeyDown(KeyCode.Space))
            {
                wheel_BR.brakeTorque = 0;
                wheel_BL.brakeTorque = 0;
                brake = false;
            }

            if(Input.GetKey(KeyCode.Space))
            {
                wheel_BR.brakeTorque = brakForce;
                wheel_BL.brakeTorque = brakForce;
                brake = true;
            }
            else if (Input.GetAxis("Vertical") != 0)
            {
                wheel_BR.brakeTorque = 0;
                wheel_BL.brakeTorque = 0;
                brake = false;
            }
            else
            {
                wheel_BR.brakeTorque = brakForce;
                wheel_BL.brakeTorque = brakForce;
                wheel_BR.motorTorque = 0;
                wheel_BL.motorTorque = 0;
            }
    }
}
