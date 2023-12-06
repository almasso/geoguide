using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompassController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject _northPole;
    [SerializeField] private GameObject _southPole;
    [SerializeField] private GameObject _planeNode;
    [SerializeField] private GameObject _planeModel;

    private Transform NpoleTransform, SpoleTransform, compassTransform, planeNodeTransform, planeModelTransform;
    void Start()
    {
        NpoleTransform = _northPole.transform;
        SpoleTransform = _southPole.transform;
        compassTransform = this.transform;
        planeNodeTransform = _planeNode.transform;
        planeModelTransform = _planeModel.transform;
    }

    void FixedUpdate()
    {
        Vector3 planeForward = planeModelTransform.forward;
        Vector3 northDirection = Quaternion.Euler(-90, 0, 0) * Vector3.forward;

        float angle = Vector3.SignedAngle(northDirection, planeForward, Vector3.up);
        compassTransform.localEulerAngles = new Vector3(0, 0, angle);
    }
}
