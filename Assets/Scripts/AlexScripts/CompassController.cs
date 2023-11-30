using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompassController : MonoBehaviour
{

    [SerializeField] private GameObject _avionNariz;
    [SerializeField] private GameObject _northPole;

    private Transform _myTransform, _avionNarizTransform;
    // Start is called before the first frame update
    void Start()
    {
        _myTransform = this.GetComponent<Transform>();
        _avionNarizTransform = _avionNariz.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = (_avionNarizTransform.position - _northPole.transform.position).normalized;
        Quaternion targetRot = Quaternion.LookRotation(dir, Vector3.up);
        _myTransform.Rotate(0,0,targetRot.y);
    }
}
