using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    public Earth attractorPlanet;
    private Transform playerTransform;
    private Transform _myTransform;
    private Rigidbody _myRigidbody;

    void Start()
    {
        _myRigidbody = GetComponent<Rigidbody>();
        _myRigidbody.useGravity = false;
        _myRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        _myTransform = GetComponent<Transform>();

        playerTransform = _myTransform;


    }

    void FixedUpdate()
    {
        if (attractorPlanet != null)
        {
            attractorPlanet.Attract(playerTransform);
        }
    }
}
