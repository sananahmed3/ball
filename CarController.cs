using UnityEngine;

public class CarController : MonoBehaviour
{
    public WheelCollider frontLeftWheel;
    public WheelCollider frontRightWheel;
    public WheelCollider rearLeftWheel;
    public WheelCollider rearRightWheel;

    public float motorTorque = 1000f;
    public float maxSteeringAngle = 30f;

   

    void FixedUpdate()
    {


        

        // Get input from the horizontal and vertical axes
        float motorInput = Input.GetAxis("Vertical");
        float steeringInput = Input.GetAxis("Horizontal");

        // Apply motor torque to the rear wheels
        rearLeftWheel.motorTorque = motorInput * motorTorque;
        rearRightWheel.motorTorque = motorInput * motorTorque;

        // Apply steering angle to the front wheels
        frontLeftWheel.steerAngle = steeringInput * maxSteeringAngle;
        frontRightWheel.steerAngle = steeringInput * maxSteeringAngle;
    }
}
