using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompassController : MonoBehaviour
{

    [SerializeField] private GameObject _avion;
    [SerializeField] private GameObject _northPole;
    [SerializeField] private GameObject _southPole;

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
