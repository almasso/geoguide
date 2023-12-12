using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneColliderCheck : MonoBehaviour
{
    [SerializeField] private GameObject _apManGO;
    [SerializeField] private GameObject _obstacleGenGO;
    [SerializeField] private float _notDetectObstacleTime;
    [SerializeField] private GameObject _compassGO;
    private AirportManager _apMan;
    private ObstacleGenerator _obstacleGenerator;
    private CompassController _compassController;
    private bool _isAffected = false;
    private float _elapsedTime = 0.0f;
    private GameObject _currentVisitedCountry;

    // Start is called before the first frame update

    public GameObject getCurrentCountry() { return _currentVisitedCountry; }   

    private void Start()
    {
        _apMan = _apManGO.GetComponent<AirportManager>();
        _obstacleGenerator = _obstacleGenGO.GetComponent<ObstacleGenerator>();
        _compassController = _compassGO.GetComponent<CompassController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _currentVisitedCountry = other.gameObject;
        if(_obstacleGenerator.checkForObstacle(other.gameObject) && !_isAffected)
        {
            _isAffected = true;
            int rand = Random.Range(0, 3);
            switch(rand)
            {
                case 0:
                    {
                        _compassController.setMalfunction();
                    }
                    break;
                case 1:
                    {
                        //L�gica para minimapa
                    }
                    break;
                case 2:
                    {
                        //L�gica para motores
                    }
                    break;
            }


        }
        else _apMan.Aterrizar(other.gameObject);
    }
    private void OnTriggerStay(Collider other)
    {
        _currentVisitedCountry = other.gameObject;
        if (_obstacleGenerator.checkForObstacle(other.gameObject) && !_isAffected)
        {
            _isAffected = true;
            int rand = Random.Range(0, 3);
            switch (rand)
            {
                case 0: break;
                case 1: break;
                case 2: break;
            }
        }
        else _apMan.Aterrizar(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        _currentVisitedCountry = null;
    }

    private void Update()
    {
        if (_isAffected) _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= _notDetectObstacleTime)
        {
            _isAffected = false;
            _elapsedTime = 0.0f;
        }
    }
}