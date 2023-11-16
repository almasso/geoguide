using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _planetToOrbit;
    [SerializeField] private GameObject _rotationNode;
    private Transform _pTOTransform;
    [Header("Ajustes del avion")]
    [SerializeField] private float rollSpeed = 0.01f;
    [SerializeField] private float yawSpeed;
    [SerializeField] private Vector3 _orbitOffset;

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
        //_planeTransform.position = _planetTransform.position + new Vector3(0, 350, 0);
        _planeNodeTransform.Rotate(new Vector3(rollSpeed, 0, 0));
    }
}
