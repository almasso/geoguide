using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CameraController;

public class MinimapController : MonoBehaviour
{
    [SerializeField] private GameObject _plane;
    [SerializeField] private Camera _minimapCamera;
    private Transform _playerTransform;


    // Start is called before the first frame update
    void Start()
    {
        _playerTransform = _plane.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _minimapCamera.GetComponent<Transform>().position = _playerTransform.position;

        Vector3 lookTarget = _playerTransform.position;
        lookTarget += _playerTransform.right;
        lookTarget += _playerTransform.up;
        lookTarget += _playerTransform.forward;
        _minimapCamera.GetComponent<Transform>().LookAt(lookTarget, _playerTransform.position);
    }
}
