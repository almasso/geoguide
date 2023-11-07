using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
    [SerializeField] private float gravity = -9.8f;
    private Transform _earthTransform;
    private Rigidbody _earthRigidbody;

    void Start()
    {
        _earthRigidbody = GetComponent<Rigidbody>();
        _earthTransform = GetComponent<Transform>();
    }

    public Quaternion Attract(Transform playerTransform)
    {
        Vector3 gravityNormal = (playerTransform.position - _earthTransform.position).normalized;
        Vector3 playerUp = playerTransform.up;

        playerTransform.GetComponent<Rigidbody>().AddForce(gravityNormal * gravity);

        Quaternion targetRotation = Quaternion.FromToRotation(playerUp, gravityNormal) * playerTransform.rotation;
        Quaternion tmp = Quaternion.Slerp(playerTransform.rotation, targetRotation, 50f * Time.deltaTime);
        playerTransform.rotation = tmp;
        return tmp;
    }
}
