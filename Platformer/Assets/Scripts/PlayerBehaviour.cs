using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerBehaviour : MonoBehaviour
{
    [System.Serializable]
    public class MoveSettings
    {
        public float runVelocity = 12f;
        public float jumpVelocity = 25f;
        public float rotateVelocity = 100f;
        public float distanceToGround = 1.1f;
        public LayerMask ground;
    }

    [System.Serializable]
    public class InputSettings
    {
        public string FORWARD_AXIS = "Vertical";
        public string SIDEWAYS_AXIS = "Horizontal";
        public string TURN_AXIS = "Mouse X";
        public string JUMP_AXIS = "Jump";
    }

    [System.Serializable]
    public class PhysSettings
    {
        public float downAccel = 1f;
    }

    public MoveSettings moveSettings = new MoveSettings();
    public InputSettings inputSettings = new InputSettings();
    public PhysSettings physSettings = new PhysSettings();

    private Rigidbody playerRigidbody;
    private Vector3 velocity;
    private Quaternion targetRot;
    private float forwardInput, sidewaysInput, turnInput, jumpInput;

    private void Awake()
    {
        velocity = Vector3.zero;
        forwardInput = sidewaysInput = turnInput = jumpInput = 0;
        targetRot = transform.rotation;

        playerRigidbody = GetComponent<Rigidbody>();
    }

    //called every frame
    private void Update()
    {
        GetInput();
        Turn();
    }

    //called every 0.2s
    private void FixedUpdate()
    {
        Run();
        Jump();

        playerRigidbody.velocity = transform.TransformDirection(velocity);
    }

    bool Grounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, moveSettings.distanceToGround, moveSettings.ground);
    }

    void GetInput()
    {
        if (inputSettings.FORWARD_AXIS != "")
        {
            forwardInput = Input.GetAxis(inputSettings.FORWARD_AXIS);
        }
        if (inputSettings.SIDEWAYS_AXIS != "")
        {
            sidewaysInput = Input.GetAxis(inputSettings.SIDEWAYS_AXIS);
        }
        if (inputSettings.TURN_AXIS != "")
        {
            turnInput = Input.GetAxis(inputSettings.TURN_AXIS);
        }
        if (inputSettings.JUMP_AXIS != "")
        {
            jumpInput = Input.GetAxis(inputSettings.JUMP_AXIS);
        }
    }

    void Run()
    {
        velocity.z = forwardInput * moveSettings.runVelocity;
        velocity.x = sidewaysInput * moveSettings.runVelocity;
    }

    void Jump()
    {
        if (jumpInput != 0 && Grounded())
        {
            velocity.y = moveSettings.jumpVelocity;
        } else if (jumpInput == 0 && Grounded())
        {
            velocity.y = 0;
        }
        else
        {
            velocity.y -= physSettings.downAccel;
        }
    }

    void Turn()
    {
        if (Math.Abs(turnInput) > 0)
        {
            targetRot *= Quaternion.AngleAxis(moveSettings.rotateVelocity * turnInput * Time.deltaTime, Vector3.up);
        }

        transform.rotation = targetRot;
    }
}
