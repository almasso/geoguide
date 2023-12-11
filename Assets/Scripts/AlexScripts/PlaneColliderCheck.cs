using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneColliderCheck : MonoBehaviour
{
    [SerializeField] private GameObject _apManGO;
    [SerializeField] private GameObject _obstacleGenGO;
    private AirportManager _apMan;
    private ObstacleGenerator _obstacleGenerator;
    // Start is called before the first frame update

    private void Start()
    {
        _apMan = _apManGO.GetComponent<AirportManager>();
        _obstacleGenerator = _obstacleGenGO.GetComponent<ObstacleGenerator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(_obstacleGenerator.checkForObstacle(other.gameObject))
        {
            Debug.Log("Oh no!");
        }
        else _apMan.Aterrizar(other.gameObject);
    }
    private void OnTriggerStay(Collider other)
    {
        if (_obstacleGenerator.checkForObstacle(other.gameObject))
        {
            Debug.Log("Oh no!");
        }
        else _apMan.Aterrizar(other.gameObject);
    }
}
