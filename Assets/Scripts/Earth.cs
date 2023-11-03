using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
    public float gravity = -9.8f;
    private Transform _myTransform;
    private Rigidbody _myRigidbody;

    void Start()
    {
        _myRigidbody = GetComponent<Rigidbody>();
        _myTransform = GetComponent<Transform>();
    }

    public void Attract(Transform playerTransform)
    {
        Vector3 gravityUp = (playerTransform.position - _myTransform.position).normalized;
        Vector3 localUp = playerTransform.up;

        playerTransform.GetComponent<Rigidbody>().AddForce(gravityUp * gravity);

        Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * playerTransform.rotation;
        playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, 50f * Time.deltaTime);
    }
}
