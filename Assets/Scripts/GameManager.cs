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
    public int intentos = 0;
    public bool help = false;
    void Start()
    {
        _gameUI = _gameUIObj.GetComponentInChildren<GameDisplay>();
        Debug.Log(_gameUI);
        _gameUIObj.SetActive(true);
        _endUIObj.SetActive(false);
        _hand = _HandObj.GetComponent<HandWave>();
        UI_Manager.Instance.StartGameHUD();
    }

    private void Update()
    {
        if (help)
        {
            Debug.Log("Necesitas ayuda bb <3 o-o");
            help = false;
        }
    }
    public void ChangeClient()
    {
        Debug.Log(_gameUI);
        if (_gameUI.HasMoreClients())
        {
            Debug.Log("Cambiando de cliente desde el Manager");
            _gameUI.nextClient();
            for (int i = 0; i < 3; ++i) _ClueObj[i].GetComponent<ButtonClue>().hasChangedClient();
            _hand.InstanciateHand();
        }
        else
        {
            UI_Manager.Instance.EndGameHUD(intentos <= 3);
            _gameUIObj.SetActive(false);
            _endUIObj.SetActive(true);
        }

    }

   public void WrongCountry() { ++intentos; Debug.Log("Pais incorrecto"); if (intentos >= 3) help = true; }
    public bool hasMoreClients() { return _gameUI.HasMoreClients(); }
    #endregion
}



