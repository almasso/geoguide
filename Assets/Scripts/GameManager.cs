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
    private GameObject _gameObj;
    private GameDisplay _game;

    [SerializeField]
    private GameObject[] _ClueObj;

    [SerializeField]
    private GameObject _HandObj;
    private HandWave _hand;
    
    [SerializeField]
    public int intentos = 0;
    void Start()
    {
        _game = _gameObj.GetComponent<GameDisplay>();
        _hand = _HandObj.GetComponent<HandWave>();
        UI_Manager.Instance.StartGameHUD();
    }

    public void ChangeClient()
    {
        if (_game.HasMoreClients())
        {
            _game.nextClient();
            for (int i = 0; i < 3; ++i) _ClueObj[i].GetComponent<ButtonClue>().hasChangedClient();
            _hand.InstanciateHand();
        }
        else
        {
            UI_Manager.Instance.EndGameHUD(intentos <= 3);
        }

    }

  
    #endregion
}



