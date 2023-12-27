using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompassController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject _northPole;
    [SerializeField] private GameObject _plane;
    [SerializeField] private float _malfunctioningTime;
    private bool normalFunctioning = true;
    private float _elapsedTime = 0.0f;


    private Transform NpoleTransform, compassTransform, planeTransform;
    void Start()
    {
        NpoleTransform = _northPole.transform;
        compassTransform = this.transform;
        planeTransform = _plane.transform;
    }

    void FixedUpdate()
    {
        if (normalFunctioning)
        {
            Vector3 northDir = CalculateNorth(planeTransform.position);
            float angle = Vector3.SignedAngle(planeTransform.forward, northDir, -planeTransform.up);
            compassTransform.eulerAngles = Vector3.forward * (angle);
        }
        else
        {
            compassTransform.eulerAngles = Vector3.forward * Random.Range(1.0f, 360.0f);
        }
    }

    public void setMalfunction() { normalFunctioning = false; }

    private void Update()
    {
        if(!normalFunctioning) _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= _malfunctioningTime)
        {
            normalFunctioning = true;
            _elapsedTime = 0.0f;
        }
    }


    private Vector3 CalculateNorth(Vector3 pos)
    {
        pos = pos.normalized;
        Vector3 posNorth = NpoleTransform.position;
        Vector3 greatCircleNormal = Vector3.Cross(posNorth, pos);
        return Vector3.Cross(pos, greatCircleNormal).normalized;
    }
}

