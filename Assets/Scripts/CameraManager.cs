using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraManager : MonoBehaviour
{
    [Header("Opciones de la camara")]
    [SerializeField] Ajustes _ajustesCamara;


    private PlayerMovement _player;
    private Transform _playerTransform;
    private Camera _camera;


    [System.Serializable]
    public struct Ajustes {
        public Vector3 offset;
        public Vector3 targetOffset;

        public Ajustes(Vector3 o, Vector3 tO)
        {
            offset = o;
            targetOffset = tO;
        }
    };

    void ActualizarPosicionCamara(Ajustes a)
    {
        Vector3 newPos = _playerTransform.position + _playerTransform.forward * a.offset.z + _playerTransform.position * a.offset.y;
        
        Vector3 lookTarget = _playerTransform.position;
        lookTarget += _playerTransform.right * a.targetOffset.x;
        lookTarget += _playerTransform.up * a.targetOffset.y;
        lookTarget += _playerTransform.forward * a.targetOffset.z;

        transform.position = newPos;
        transform.LookAt(lookTarget, _playerTransform.position);
    }

    void Start()
    {
        _camera = Camera.main; //Obtenemos la cámara
        _player = GameObject.Find("Plane").GetComponent<PlayerMovement>();
        _playerTransform = _player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        ActualizarPosicionCamara(_ajustesCamara);
    }
}
