using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneColliderCheck : MonoBehaviour
{
    [SerializeField] private GameObject _apManGO;
    [SerializeField] private GameObject _obstacleGenGO;
    [SerializeField] private float _notDetectObstacleTime;
    [SerializeField] private GameObject _compassGO;
    [SerializeField] private GameObject _minimapGO;
    [SerializeField] private GameObject _plane;
    [SerializeField] private GameObject _walkieGO;
    private AirportManager _apMan;
    private ObstacleGenerator _obstacleGenerator;
    private CompassController _compassController;
    private MinimapController _minimapController;
    private PlayerController _playerController;
    private WalkieController _walkieController;
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
        _minimapController = _minimapGO.GetComponent<MinimapController>();
        _playerController = _plane.GetComponent<PlayerController>();
        _walkieController = _walkieGO.GetComponent<WalkieController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _currentVisitedCountry = other.gameObject;
        if (_obstacleGenerator.checkForObstacle(other.gameObject) && !_isAffected)
        {
            SoundManager.Instance.PlaySFX(SoundManager.Instance.staticSound);
            _isAffected = true;
            int rand = Random.Range(0, 3);
            switch (rand)
            {
                case 0:
                    {
                        SpeechBubbleController.setBrokenGadgetString("brújula");
                        SpeechBubbleController.setShowString(SpeechBubbleController.Frases.GADGET_BROKEN);
                        _walkieController.showWalkie();
                        _compassController.setMalfunction();
                    }
                    break;
                case 1:
                    {
                        SpeechBubbleController.setBrokenGadgetString("minimapa");
                        SpeechBubbleController.setShowString(SpeechBubbleController.Frases.GADGET_BROKEN);
                        _walkieController.showWalkie();
                        _minimapController.setMalfunction();
                    }
                    break;
                case 2:
                    {
                        SpeechBubbleController.setBrokenGadgetString("motor");
                        SpeechBubbleController.setShowString(SpeechBubbleController.Frases.GADGET_BROKEN);
                        _walkieController.showWalkie();
                        _playerController.setMalfunction();
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
                case 0:
                    {
                        SpeechBubbleController.setBrokenGadgetString("brújula");
                        SpeechBubbleController.setShowString(SpeechBubbleController.Frases.GADGET_BROKEN);
                        _walkieController.showWalkie();
                        _compassController.setMalfunction();
                    }
                    break;
                case 1:
                    {
                        SpeechBubbleController.setBrokenGadgetString("minimapa");
                        SpeechBubbleController.setShowString(SpeechBubbleController.Frases.GADGET_BROKEN);
                        _walkieController.showWalkie();
                        _minimapController.setMalfunction();
                    }
                    break;
                case 2:
                    {
                        SpeechBubbleController.setBrokenGadgetString("motor");
                        SpeechBubbleController.setShowString(SpeechBubbleController.Frases.GADGET_BROKEN);
                        _walkieController.showWalkie();
                        _playerController.setMalfunction();
                    }
                    break;
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
