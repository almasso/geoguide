using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CameraController;

public class MinimapController : MonoBehaviour
{
    [SerializeField] private GameObject _plane;
    [SerializeField] private Camera _minimapCamera;
    [SerializeField] private float heightOffset;
    private Quaternion initialRotation;
    private Transform _planeTransform;


    // Start is called before the first frame update
    void Start()
    {
        initialRotation = _minimapCamera.GetComponent<Transform>().localRotation;
        _planeTransform = _plane.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetPosition = _planeTransform.position + _planeTransform.position.normalized * heightOffset;
        transform.position = targetPosition;
        _minimapCamera.transform.LookAt(_planeTransform.position);
    }
}
