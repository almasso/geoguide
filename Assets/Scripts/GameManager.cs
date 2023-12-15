using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region references
    static private GameManager _instance;
    static public GameManager Instance
    {
        get
        {
            return _instance;
        }
    }
    #endregion

    #region methods
    private void Awake()
    {
        _instance = this;
    }
    [SerializeField]
    private GameObject _gameUIObj;
    private GameDisplay _gameUI;

    [SerializeField]
    private GameObject _endUIObj;

    [SerializeField]
    private GameObject[] _ClueObj;

    [SerializeField]
    private GameObject _HandObj;
    private HandWave _hand;

    [SerializeField]
    private GameObject _player;
    private PlaneTrail _planeTrail;
    private PlayerController _planeController;

    [SerializeField]
    public int intentos = 0;
    public bool help = false;
    void Start()
    {
        _gameUI = _gameUIObj.GetComponentInChildren<GameDisplay>();
        _planeController = _player.GetComponent<PlayerController>();
        _planeTrail = _player.GetComponent<PlaneTrail>();
        Debug.Log(_gameUI);
        _gameUIObj.SetActive(true);
        _endUIObj.SetActive(false);
        _hand = _HandObj.GetComponent<HandWave>();
        UI_Manager.Instance.StartGameHUD();
        _planeTrail.Activate(true);
    }

    private void Update()
    {
        if (help)
        {
            help = false;
        }
    }
    public void ChangeClient()
    {
        Debug.Log(_gameUI);
        if (_gameUI.HasMoreClients())
        {
            _gameUI.nextClient();
            for (int i = 0; i < 3; ++i) _ClueObj[i].GetComponent<ButtonClue>().hasChangedClient();
            _hand.InstanciateHand();
            _planeTrail.Activate(true);
        }
        else
        {
            UI_Manager.Instance.EndGameHUD(intentos < 3);
            _gameUIObj.SetActive(false);
            _endUIObj.SetActive(true);
            _planeController.DeactivatePlayer();
            _planeTrail.Activate(false);
        }

    }

   public void WrongCountry() { ++intentos; Debug.Log(intentos); if(intentos >= 2) help = true; }
    public bool hasMoreClients() { return _gameUI.HasMoreClients(); }
    public void DeactivateTrails()
    {
        _planeTrail.Activate(false);
    }
    public int GetTries(){ return intentos; }
    #endregion
}



