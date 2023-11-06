using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float maxRollAngle = -35;
    [SerializeField] private float maxPitchAngle = -35;
    private float rollAngle;
    private float pitchAngle;
    private float moveSpeed = 0.1f;
    private float horizontalSpeed;
    private Vector3 moveDirection;
    private Rigidbody _myRigidbody;
    private Transform _myTransform;
    private float worldRadius;
    private float smoothedTurnSpeed;
    [SerializeField] private float turnSpeed = 50;
    [SerializeField] private float turnSmoothTime = 0.25f;
    [SerializeField] private float smoothRollTime = 0.25f;
    [SerializeField] private float smoothPitchTime = 0.25f;
    private float turnSmoothV;
    private float rollSmoothV;
    private float pitchSmoothV;
    private float totalTurnAngle;


    void Start()
    {
        _myRigidbody = GetComponent<Rigidbody>();
        _myTransform = GetComponent<Transform>();
        worldRadius = 370;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) moveSpeed = 0.1f;
        else if (Input.GetKeyDown(KeyCode.Alpha2)) moveSpeed = 0.5f;
        else if (Input.GetKeyDown(KeyCode.Alpha3)) moveSpeed = 1f;

        horizontalSpeed = Time.deltaTime * Input.GetAxisRaw("Horizontal") * 100;

        moveDirection = new Vector3(horizontalSpeed, 0, moveSpeed);
    }

    private void FixedUpdate()
    {
        _myRigidbody.MovePosition(_myRigidbody.position + _myTransform.TransformDirection(moveDirection));
        smoothedTurnSpeed = Mathf.SmoothDamp(smoothedTurnSpeed, Input.GetAxisRaw("Horizontal") * turnSpeed, ref turnSmoothV, turnSmoothTime);
        float turnAmount = smoothedTurnSpeed * Time.deltaTime;
        totalTurnAngle += turnAmount;
        updateRotation(turnAmount);
    }

    private void updateRotation(float turnAmount)
    {
        Vector3 gravityUp = transform.position.normalized;
        transform.RotateAround(transform.position, gravityUp, turnAmount);
        transform.LookAt((transform.position + transform.forward * 10).normalized * (worldRadius), gravityUp);
        transform.rotation = Quaternion.FromToRotation(transform.up, gravityUp) * transform.rotation;
        //_myTransform.localEulerAngles = new Vector3(pitchAngle, 0, rollAngle);
    }
}