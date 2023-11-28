using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassController : MonoBehaviour
{

    [SerializeField] private GameObject _avion;

    private Transform _myTransform, _avionTransform;
    // Start is called before the first frame update
    void Start()
    {
        _myTransform = this.GetComponent<Transform>();
        _avionTransform = _avion.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
