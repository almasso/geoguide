using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float maxTurnDegree = 10;
    private float moveSpeed = 0.1f;
    private float horizontalSpeed;
    private Vector3 moveDirection;
    private Rigidbody _myRigidbody;
    private Transform _myTransform;
    
    void Start()
    {
        _myRigidbody = GetComponent<Rigidbody>();
        _myTransform = GetComponent<Transform>();
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
        _myTransform.rotation.z = Mathf.Lerp(_myTransform.rotation.z, -Input.GetAxisRaw("Horizontal") * maxTurnDegree, 0.9f);
    }
}
