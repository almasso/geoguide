using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Vector3 moveDirection;
    private Rigidbody _myRigidbody;
    private Transform _myTransform;
    private void Start()
    {
        _myRigidbody = GetComponent<Rigidbody>();
        _myTransform = GetComponent<Transform>();
    }
    void Update()
    {
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
    }

    private void FixedUpdate()
    {
        _myRigidbody.MovePosition(_myRigidbody.position + _myTransform.TransformDirection(moveDirection));
    }
}
