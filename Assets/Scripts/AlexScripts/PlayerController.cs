using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _planetToOrbit;
    [SerializeField] private GameObject _rotationNode;
    [SerializeField] private GameObject _planeModel;
    [SerializeField] private GameObject _levelChanger;
    [Header("Ajustes del avion")]
    [SerializeField] private float pitchSpeed = 0.01f;
    [SerializeField] private float yawSpeed = 0.5f;
    [SerializeField] private float diveSpeed = 0.01f;
    [SerializeField] private float maxRollTiltAngle;
    [SerializeField] private float maxPitchTiltAngle;
    [SerializeField] private float pitchLerpSpeed;
    [SerializeField] private float rollLerpSpeed;
    [SerializeField] private Vector3 _orbitOffset;
    [SerializeField] private float maximumHeight = 820;
    [SerializeField] private float minimumHeight = 700;
    [SerializeField] private float animMinimumHeight = 650;
    [SerializeField] private Velocidades velocidadesAvion;
    [Header("Ajustes del castigo por imprevisto")]
    [SerializeField] private float _malfunctioningTime = 6.0f;
    [SerializeField] private float betweenClients = 10.0f;

    private float velocidadObjetivo;
    private bool _canTiltDown, _canTiltUp;
    private float pitchAngle;
    private float rollAngle;
    private bool detectInput = true;
    private bool descendAnim = false;
    private bool moving = true;
    private float _elapsedTime = 0.0f;
    private bool _malfunctioning = false;
    private float _time = 0.0f;
    private bool landingPlane = false;
    private float iniminimumHeight;

    private Transform _planeTransform;
    private Transform _playerTransform;
    private Transform _planeNodeTransform;

    private LevelChanger _lvlChngr;

    public bool isMinimumSpeed()
    {
        return velocidadObjetivo == velocidadesAvion.minima;
    }
    public bool isMediumSpeed()
    {
        return velocidadObjetivo == velocidadesAvion.media;
    }
    public bool isMaximumSpeed()
    {
        return velocidadObjetivo == velocidadesAvion.maxima;
    }

    public bool isMalfunctioning()
    {
        return _malfunctioning;
    }

    public bool isInputEnabled()
    {
        return detectInput;
    }

    public float GetCurrentSpeed()
    {
        return pitchSpeed;
    }

    public void setMalfunction()
    {
        _malfunctioning = true;
        velocidadObjetivo = velocidadesAvion.minima;
    }

    // Start is called before the first frame update
    void Start()
    {
        _playerTransform = this.GetComponent<Transform>();
        _planeTransform = this._planeModel.GetComponent<Transform>();
        _playerTransform.position = _planetToOrbit.GetComponent<Transform>().position + new Vector3(0, (minimumHeight + maximumHeight)/2, 0) + _orbitOffset;
        _planeNodeTransform = _rotationNode.GetComponent<Transform>();
        velocidadObjetivo = velocidadesAvion.minima;
        _canTiltDown = _canTiltUp = true;
        _lvlChngr = _levelChanger.GetComponent<LevelChanger>();
        iniminimumHeight = minimumHeight;
        _planeNodeTransform.rotation = Quaternion.Euler(-47.027f, 128.629f, -24.238f);
    }

    void FixedUpdate()
    {
        float targetPitch = descendAnim ? maxPitchTiltAngle * Time.fixedDeltaTime * -30 : detectInput ? Input.GetAxisRaw("Vertical") * maxPitchTiltAngle : 0;

        if (targetPitch < 0 && _canTiltDown || targetPitch > 0 && _canTiltUp || descendAnim) pitchAngle = Mathf.Lerp(pitchAngle, -targetPitch, 7 * Time.fixedDeltaTime);
        else if(!descendAnim) pitchAngle = Mathf.Lerp(pitchAngle, 0, 7 * Time.fixedDeltaTime);

        float targetRoll = detectInput ? Input.GetAxisRaw("Horizontal") * maxRollTiltAngle : 0;
        rollAngle = Mathf.Lerp(rollAngle, targetRoll, 7 * Time.fixedDeltaTime);

        if (Mathf.Abs(pitchSpeed - velocidadObjetivo) >= 0.005) pitchSpeed = Mathf.Lerp(pitchSpeed, velocidadObjetivo, 2 * Time.fixedDeltaTime);
        else pitchSpeed = velocidadObjetivo;

        _playerTransform.localPosition += (new Vector3(0, descendAnim ? -diveSpeed/2 : (detectInput ? Input.GetAxisRaw("Vertical") : 0) * diveSpeed, 0) * Time.fixedDeltaTime);

        if (_playerTransform.localPosition.y >= maximumHeight) _playerTransform.localPosition = new Vector3(0, Mathf.Abs(maximumHeight), 0);
        else if (_playerTransform.localPosition.y <= minimumHeight) _playerTransform.localPosition = new Vector3(0, Mathf.Abs(minimumHeight), 0);

        if (_playerTransform.localPosition.y >= maximumHeight - 0.05f)
        {
            _canTiltUp = false;
            _canTiltDown = true;
        }
        else if (_playerTransform.localPosition.y <= minimumHeight + 0.05f)
        {
            _canTiltUp = true;
            _canTiltDown = false;
        }
        else
        {
            _canTiltDown = true;
            _canTiltUp = true;
        }

        _planeNodeTransform.Rotate(new Vector3(moving ? pitchSpeed : 0, yawSpeed * (detectInput ? Input.GetAxisRaw("Horizontal") : 0), 0) * Time.fixedDeltaTime);

        Vector3 rot = new Vector3(pitchAngle, 0, -rollAngle);
        _planeTransform.localEulerAngles = rot;
    }

    public void SecuenciaAterrizaje()
    {
        detectInput = false;
        descendAnim = true;
        moving = false;
        velocidadObjetivo = velocidadesAvion.minima;
        minimumHeight = animMinimumHeight;
        _lvlChngr.FadeScreen();
        landingPlane = true;
        _time = 0.0f;
        GameManager.Instance.DeactivateTrails();
    }

    private void InicializePlane()
    {
        //_playerTransform.localPosition = _planetToOrbit.GetComponent<Transform>().position + new Vector3(0, (minimumHeight + maximumHeight) / 2, 0) + _orbitOffset;
        //_planeNodeTransform = _rotationNode.GetComponent<Transform>();
        velocidadObjetivo = velocidadesAvion.minima;
        _canTiltDown = _canTiltUp = true;
        minimumHeight = iniminimumHeight;
        detectInput = true;
        descendAnim = false;
        moving = true;
    }

    public void DeactivatePlayer()
    {
        detectInput = false;
        moving = false;
        velocidadObjetivo = velocidadesAvion.minima;
        GameManager.Instance.DeactivateTrails();
    }

    // Update is called once per frame
    void Update()
    {

        if (_malfunctioning) _elapsedTime += Time.deltaTime;
        if (landingPlane) { _time += Time.deltaTime; }

        if (_elapsedTime >= _malfunctioningTime)
        {
            _malfunctioning = false;
            _elapsedTime = 0.0f;
        }
        if (landingPlane && _time >= betweenClients)
        {
            InicializePlane();
            GameManager.Instance.ChangeClient();
            _lvlChngr.FadeInScreen();
            landingPlane = false;
        }

        // Input para el cambio de velocidad
        if (Input.GetKeyDown(KeyCode.Alpha1) && detectInput && !_malfunctioning) { velocidadObjetivo = velocidadesAvion.minima; SoundManager.Instance.ChangePlaneSpeedSound(1); }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && detectInput && !_malfunctioning) { velocidadObjetivo = velocidadesAvion.media; SoundManager.Instance.ChangePlaneSpeedSound(2); }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && detectInput && !_malfunctioning) { velocidadObjetivo = velocidadesAvion.maxima; SoundManager.Instance.ChangePlaneSpeedSound(3); }
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
