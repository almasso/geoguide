using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CameraController;

public class MinimapController : MonoBehaviour
{
    [SerializeField] private GameObject _plane;
    [SerializeField] private Camera _minimapCamera;
    [SerializeField] private GameObject _noiseGO;
    [SerializeField] private float heightOffset;
    [SerializeField] float _malfunctioningTime;
    private Quaternion initialRotation;
    private Transform _planeTransform;
    private float _elapsedTime = 0.0f;
    private bool _malfunctioning = false;

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

    public void setMalfunction()
    {
        _malfunctioning = true;
        _noiseGO.SetActive(true);
    }

    private void Update()
    {
        if (_malfunctioning) _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= _malfunctioningTime)
        {
            _noiseGO.SetActive(false);
            _malfunctioning = false;
            _elapsedTime = 0.0f;
        }
    }
}
