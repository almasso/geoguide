using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform _planetTransform;
    private Transform _planeTransform;
    private Transform _planeNodeTransform;
    private SphereCollider _planetaCollider;
    private Camera _mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
        _planetTransform = GameObject.Find("Planeta").GetComponent<Transform>();
        _planetaCollider = GameObject.Find("Planeta").GetComponent<SphereCollider>();
        _planeNodeTransform = GameObject.Find("PlayerNode").GetComponent<Transform>();

        _planeTransform = this.GetComponent<Transform>();
        _planeTransform.position = _planetTransform.position + new Vector3(0, 350, 0);
        _mainCamera.GetComponent<Transform>().position = _planeTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //_planeTransform.position = _planetTransform.position + new Vector3(0, 350, 0);
        _planeNodeTransform.Rotate(new Vector3(1, 0, 0));
        _mainCamera.GetComponent<Transform>().position = _planeTransform.position;
    }
}
