using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompassController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject _planeNose;
    [SerializeField] private GameObject _northPole;
    [SerializeField] private GameObject _planeCenter;

    private Transform noseTransform, NpoleTransform, centerTransform, compassTransform;
    void Start()
    {
        noseTransform = _planeNose.transform;
        NpoleTransform = _northPole.transform;
        centerTransform = _planeCenter.transform;
        compassTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 northPoleToPlaneCenter = (NpoleTransform.position - centerTransform.position).normalized;
        Vector3 planeCenterToPlaneNose = (centerTransform.position - noseTransform.position).normalized;

        float angle = Vector3.SignedAngle(northPoleToPlaneCenter, planeCenterToPlaneNose, Vector3.forward);

        //Debug.Log(angle);
        compassTransform.eulerAngles = new Vector3(0, 0, -angle);
    }
}
