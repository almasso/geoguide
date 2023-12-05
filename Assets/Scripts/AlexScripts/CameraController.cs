using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject _plane;
    [Header("Opciones de la camara")]
    [SerializeField] private AjustesCamara _ajustes;

    private Camera _mainCamera;
    private Transform _playerTransform;


    [System.Serializable]
    public struct AjustesCamara {
        public Vector3 offset;
        public Vector3 lookAtOffset;
        public AjustesCamara(Vector3 offset, Vector3 lookAtOffset)
        {
            this.offset = offset;
            this.lookAtOffset = lookAtOffset;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
        _playerTransform = _plane.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _mainCamera.GetComponent<Transform>().position = Vector3.Lerp(_mainCamera.GetComponent<Transform>().position, _playerTransform.position + _playerTransform.forward * _ajustes.offset.z + _playerTransform.position * _ajustes.offset.y, 7 * Time.deltaTime);

        Vector3 lookTarget = _playerTransform.position;
        lookTarget += _playerTransform.right * _ajustes.lookAtOffset.x;
        lookTarget += _playerTransform.up * _ajustes.lookAtOffset.y;
        lookTarget += _playerTransform.forward * _ajustes.lookAtOffset.z;
        _mainCamera.GetComponent<Transform>().LookAt(lookTarget, _playerTransform.position);
    }
}
