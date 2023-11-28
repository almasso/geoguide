using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _planetToOrbit;
    [SerializeField] private GameObject _rotationNode;
    private Transform _pTOTransform;
    [Header("Ajustes del avion")]
    [SerializeField] private float pitchSpeed = 0.01f;
    [SerializeField] private float yawSpeed = 0.5f;
    [SerializeField] private float diveSpeed = 0.01f;
    [SerializeField] private float maxRollTiltAngle;
    [SerializeField] private float maxPitchTiltAngle;
    [SerializeField] private float smoothRollTime = 0.25f;
    [SerializeField] private float smoothPitchTime = 0.25f;
    [SerializeField] private Vector3 _orbitOffset;
    [SerializeField] private float maximumHeight = 820;
    [SerializeField] private float minimumHeight = 700;
    [SerializeField] private Velocidades velocidadesAvion;
    private float velocidadObjetivo;
    private bool _canTiltDown, _canTiltUp;
    
    private float height;
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
        _planeTransform.position = _planetToOrbit.GetComponent<Transform>().position + new Vector3(0, (minimumHeight + maximumHeight)/2, 0) + _orbitOffset;
        _planeNodeTransform = _rotationNode.GetComponent<Transform>();
        velocidadObjetivo = velocidadesAvion.minima;
        _canTiltDown = _canTiltUp = true;
    }

    // Update is called once per frame
    void Update()
    {
        float targetPitch = Input.GetAxisRaw("Vertical") * maxPitchTiltAngle;
        //pitchAngle = Mathf.SmoothDampAngle(pitchAngle, -targetPitch, ref pitchSmoothV, smoothPitchTime);
        if(targetPitch < 0 && _canTiltDown || targetPitch > 0 && _canTiltUp)
        {
            pitchAngle = Mathf.Lerp(pitchAngle, -targetPitch, 7 * Time.deltaTime);
        }
        else
        {
            pitchAngle = Mathf.Lerp(pitchAngle, 0, 7 * Time.deltaTime);
        }

        float targetRoll = Input.GetAxisRaw("Horizontal") * maxRollTiltAngle;
        //rollAngle = Mathf.SmoothDampAngle(rollAngle, targetRoll, ref rollSmoothV, smoothRollTime);
        rollAngle = Mathf.Lerp(rollAngle, targetRoll, 7 * Time.deltaTime);

        // Input para el cambio de velocidad
        if (Input.GetKeyDown(KeyCode.Alpha1)) velocidadObjetivo = velocidadesAvion.minima;
        else if (Input.GetKeyDown(KeyCode.Alpha2)) velocidadObjetivo = velocidadesAvion.media;
        else if (Input.GetKeyDown(KeyCode.Alpha3)) velocidadObjetivo = velocidadesAvion.maxima;

        if (Mathf.Abs(pitchSpeed - velocidadObjetivo) >= 0.005) pitchSpeed = Mathf.Lerp(pitchSpeed, velocidadObjetivo, 2 * Time.deltaTime);
        else pitchSpeed = velocidadObjetivo;
        

        _planeTransform.localPosition += (new Vector3(0, Input.GetAxisRaw("Vertical") * diveSpeed, 0));

        //Debug.Log(_planeTransform.localPosition);
        if (_planeTransform.localPosition.y >= maximumHeight)
        {
            _planeTransform.localPosition = new Vector3(0, Mathf.Abs(maximumHeight), 0);
            _canTiltUp = false;
            _canTiltDown = true;
        }
        else if (_planeTransform.localPosition.y <= minimumHeight)
        {
            _planeTransform.localPosition = new Vector3(0, Mathf.Abs(minimumHeight), 0);
            _canTiltUp = true;
            _canTiltDown = false;
        }
        else
        {
            _canTiltDown = true;
            _canTiltUp = true;
        }

        _planeNodeTransform.Rotate(new Vector3(pitchSpeed, yawSpeed * Input.GetAxisRaw("Horizontal"), 0));
        _planeTransform.localEulerAngles = new Vector3(pitchAngle, 0, -rollAngle);
    }

    [System.Serializable]
    public struct Velocidades
    {
        public float minima;
        public float media;
        public float maxima;

        Velocidades(float minima, float media, float maxima)
        {
            this.minima = minima;
            this.media = media;
            this.maxima = maxima;
        }
    }
}
