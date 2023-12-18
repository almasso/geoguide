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
    [SerializeField] private float _malfunctioningTime;
    private bool normalFunctioning = true;
    private float _elapsedTime = 0.0f;


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
        if (normalFunctioning)
        {
            Vector3 planeForward = planeModelTransform.forward;
            Vector3 toNorthPole = NpoleTransform.position - planeModelTransform.position;
            Vector3 toSouthPole = SpoleTransform.position - planeModelTransform.position;

            float angleToNorth = Vector3.SignedAngle(planeForward, toNorthPole, planeModelTransform.up);
            float angleToSouth = Vector3.SignedAngle(planeForward, toSouthPole, planeModelTransform.up);
            if(Mathf.Abs(angleToNorth) < Mathf.Abs(angleToSouth))
            {
                //
            }
            else
            {
                //sur
            }
        }
        else
        {
            compassTransform.Rotate(0, 0, Random.Range(0, 3));
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
}

