using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public enum WheelType 
    { 
        Front,
        Rear
    }
    [Serializable]

    public class Wheel
    {
        public GameObject wheelModel;
        public WheelCollider wheelCollider;
        public WheelType type;
    }

    public float MaxSpeed => maxSpeed;
    [SerializeField] float maxSpeed = 120f;

    public float CurSpeed => carRb.velocity.magnitude * 3.6f;

    [SerializeField] float maxAcceleration = 1000f;
    [SerializeField] float brakeAcceleration = 25000f;

    [SerializeField] float turnSensitivity = 1f;
    [SerializeField] float maxSteerAngle = 35f;

    [SerializeField] Vector3 centerOfMass;
    [SerializeField] Wheel[] wheels;

    [SerializeField] private KeyCode brakeKey = KeyCode.Space;

    

    
   

    private float moveInput;
    private float steerInput;

    private Rigidbody carRb;

    private bool blockMovement = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        carRb = GetComponent<Rigidbody>();
        carRb.centerOfMass = centerOfMass;

      
    }

    public void BlockMovement (bool IsNowBlocked) 
    { 
        blockMovement = IsNowBlocked;
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();
        AnimateWheels();
      
    }
    private void FixedUpdate()
    {
        if (blockMovement) 
        {
            return;
        }
        Move();
        Steer();
        Brake();
    }

    void GetInputs() 
    { 
        moveInput=Input.GetAxis("Vertical");
        steerInput = Input.GetAxis("Horizontal");
    }

    private void Move()
    {
        foreach (Wheel wheel in wheels)
        {
            if (CurSpeed < maxSpeed)
            {
                wheel.wheelCollider.motorTorque = moveInput * maxAcceleration;
            }
            else
            {
                wheel.wheelCollider.motorTorque = 0f;
            }
        }
    }
    private void Steer()
    {
        foreach (Wheel wheel in wheels)
        {
            if (wheel.type == WheelType.Front)
            {
                float steerAngle = steerInput * turnSensitivity * maxSteerAngle;
                wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, steerAngle, 0.6f);
            }
        }
    }
    private void Brake()
    {
        if (Input.GetKey(brakeKey) || moveInput == 0)
        {
            foreach (Wheel wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = brakeAcceleration;
            }
        }
        else
        {
            foreach (Wheel wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 0;
            }
        }
    }

    private void AnimateWheels()
    {
        foreach (Wheel wheel in wheels)
        {
            wheel.wheelCollider.GetWorldPose(out Vector3 pos, out Quaternion rot);
            wheel.wheelModel.transform.rotation = rot;
        }
    }

    




}
