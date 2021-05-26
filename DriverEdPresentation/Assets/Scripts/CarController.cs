//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Author : Shantel Williams
/// Date : 5/3/2021
/// File Name : CarController.cs
/// Description:
/// 
/// This file ws create to check if player Stops Completely at the posted stop signs. If the player succeds they will recieve one point toward the final score. If the fail to stop
/// They will not recieve any points on their score. This Class borrows functions and valuse from the CarController.cs file. 
///
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    /// <summary>
    /// Variables for this class
    /// </summary>
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float CurrentbreakForce;
    private bool isBreaking;
    private float currentSteerAngle;

    [SerializeField] private WheelCollider FrontLeftWheel;
    [SerializeField] private WheelCollider FrontRightWheel;
    [SerializeField] private WheelCollider RearLeftWheel;
    [SerializeField] private WheelCollider RearRightWheel;

    [SerializeField] private Transform FrontLeftWheelTransform;
    [SerializeField] private Transform FrontRightWheelTransform;
    [SerializeField] private Transform RearLeftWheelTransform;
    [SerializeField] private Transform RearRightWheelTransform;



    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteeringAngle;

    //public Text Speed;
    public Rigidbody rb;
    StopSignHandler playerCar;
    StopSignHandler2 playerCar2;
    public string MovingToString;

    /// <summary>
    /// Setting object from StopSignHandler Class
    /// </summary>
    private void Awake()
    {
        
        playerCar = GameObject.FindObjectOfType<StopSignHandler>();
        playerCar2 = GameObject.FindObjectOfType<StopSignHandler2>();
    }


    /// <summary>
    /// getting the cars rigidbody
    /// </summary>
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Updates the velocity and passes it to the fucntion TheyStopped in the StopSignHanlder Class.
    /// </summary>
    void Update()
    {
        //Speed.text = rb.velocity.ToString();  // used to check velocity
        playerCar.TheyStopped(Moving());
        playerCar2.TheyStopped(Moving());

    }

    /// <summary>
    /// Returns a string value for if the Driver stopped or not. I used the velocity to check for this.
    /// </summary>
    private string Moving()
    {
        if (rb.velocity == new Vector3(0, 0, 0))
        {
            MovingToString = "true";
            return MovingToString;
        }
        else
            MovingToString = "false";
            return MovingToString;
    }


    /// <summary>
    /// Keeps track of the player movement and controls the car
    /// </summary>
    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }


    /// <summary>
    /// Checks for input from the keyboard
    /// </summary>
    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);
    }
    private void HandleMotor()
    {
        FrontLeftWheel.motorTorque = verticalInput * motorForce;
        FrontRightWheel.motorTorque = verticalInput * motorForce;
        CurrentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    
    }

    private void ApplyBreaking()
    {
        FrontRightWheel.brakeTorque = CurrentbreakForce;
        FrontLeftWheel.brakeTorque = CurrentbreakForce;
        RearLeftWheel.brakeTorque = CurrentbreakForce;
        RearRightWheel.brakeTorque = CurrentbreakForce;
    }
    private void HandleSteering()
    {
        currentSteerAngle = maxSteeringAngle * horizontalInput;
        FrontLeftWheel.steerAngle = currentSteerAngle;
        FrontRightWheel.steerAngle = currentSteerAngle;
    }
    private void UpdateWheels()
    {
        UpdateSingleWheel(FrontLeftWheel, FrontLeftWheelTransform);
        UpdateSingleWheel(FrontRightWheel, FrontRightWheelTransform);
        UpdateSingleWheel(RearLeftWheel, RearLeftWheelTransform);
        UpdateSingleWheel(RearRightWheel, RearRightWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform WheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        WheelTransform.rotation = rot;
        WheelTransform.position = pos;
    }
}
