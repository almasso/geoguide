using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _planetToOrbit;
    [SerializeField] private GameObject _rotationNode;
    private Transform _pTOTransform;
    [Header("Ajustes del avion")]
    [SerializeField] private float pitchSpeed = 0.01f;
    [SerializeField] private float yawSpeed = 0.01f;
    [SerializeField] private float diveSpeed = 0.01f;
    [SerializeField] private float maxRollTiltAngle;
    [SerializeField] private float maxPitchTiltAngle;
    [SerializeField] private float smoothRollTime = 0.25f;
    [SerializeField] private float smoothPitchTime = 0.25f;
    [SerializeField] private Vector3 _orbitOffset;
    private float pitchAngle;
    private float rollAngle;
    private float rollSmoothV;
    private float pitchSmoothV;

    private Transform _planeTransform;
    private Transform _planeNodeTransform;

    // Start is called before the first frame update
    void Start()
    {
        _pTOTransform = _planetToOrbit.GetComponent<Transform>();
        _planeTransform = this.GetComponent<Transform>();
        _planeTransform.position = _planetToOrbit.GetComponent<Transform>().position + new Vector3(0, _pTOTransform.localScale.y / 2, 0) + _orbitOffset;
        _planeNodeTransform = _rotationNode.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Input para el cambio de velocidad
        if (Input.GetKeyDown(KeyCode.Alpha1)) pitchSpeed = 0.01f;
        else if (Input.GetKeyDown(KeyCode.Alpha2)) pitchSpeed = 0.05f;
        else if (Input.GetKeyDown(KeyCode.Alpha3)) pitchSpeed = 0.1f;

        _planeTransform.position += new Vector3(0, Input.GetAxisRaw("Vertical") * diveSpeed, 0);

        _planeNodeTransform.Rotate(new Vector3(pitchSpeed, yawSpeed * Input.GetAxisRaw("Horizontal"), 0));
        _planeTransform.localEulerAngles = new Vector3(-pitchAngle, 0, -rollAngle);
    }

    private void FixedUpdate()
    {
        float targetPitch = Input.GetAxisRaw("Vertical") * maxPitchTiltAngle;
        pitchAngle = Mathf.SmoothDampAngle(pitchAngle, targetPitch, ref pitchSmoothV, smoothPitchTime);

        float targetRoll = Input.GetAxisRaw("Horizontal") * maxRollTiltAngle;
        rollAngle = Mathf.SmoothDampAngle(rollAngle, targetRoll, ref rollSmoothV, smoothRollTime);
    }
}
