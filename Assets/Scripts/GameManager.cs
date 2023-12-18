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

    //private string actualCountry;
    private GameObject actualCountryObject;

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
    private GameObject _pauseUIObj;

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
    [SerializeField]
    private GameObject[] _countries;

    Color red = new Color32(255, 0, 0, 94);
    Color green = new Color32(0, 255, 0, 94);
    void Start()
    {
        _gameUI = _gameUIObj.GetComponentInChildren<GameDisplay>();
        _planeController = _player.GetComponent<PlayerController>();
        _planeTrail = _player.GetComponent<PlaneTrail>();
        Debug.Log(_gameUI);
        _gameUIObj.SetActive(true);
        _endUIObj.SetActive(false);
        _pauseUIObj.SetActive(false);
        _hand = _HandObj.GetComponent<HandWave>();
        UI_Manager.Instance.StartGameHUD();
        _planeTrail.Activate(true);
        GameSceneInfo.setObjectiveCountry(_gameUI.myIntroLevelList.IntroLevel[_gameUI.introIndex].Country1);
        updateCountryObject(GameSceneInfo.getObjectiveCountry());
        if(SceneManager.GetActiveScene().name == "IntroductoryLevels") changeCountryColor(green);
    }

    public void ChangeClient()
    {
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

    public void updateIntroCountry(string country)
    {
        changeCountryColor(red);
        if (country == _gameUI.myIntroLevelList.IntroLevel[_gameUI.introIndex].Country1) GameSceneInfo.setObjectiveCountry(_gameUI.myIntroLevelList.IntroLevel[_gameUI.introIndex].Country2);
        else if (country == _gameUI.myIntroLevelList.IntroLevel[_gameUI.introIndex].Country2) GameSceneInfo.setObjectiveCountry(_gameUI.myIntroLevelList.IntroLevel[_gameUI.introIndex].Country3);
        else Debug.Log("ultimo");

        updateCountryObject(GameSceneInfo.getObjectiveCountry());
        changeCountryColor(green);

        _gameUI.updateIntroObjective();
    }

    void updateCountryObject(string country)
    {
        for (int i = 0; i < _countries.Length; i++)
        {
            if (_countries[i].name == country) {
                actualCountryObject = _countries[i].gameObject; 
            }
        }
    }

    void changeCountryColor(Color c)
    {
        actualCountryObject.GetComponent<MeshRenderer>().material.color = c;
    }

   public void WrongCountry() { 
        ++intentos;
        for (int i = 0; i < 3; ++i) _ClueObj[i].GetComponent<ButtonClue>().intentoFallido(intentos);
    }
    public bool hasMoreClients() { return _gameUI.HasMoreClients(); }
    public void DeactivateTrails()
    {
        _planeTrail.Activate(false);
    }
    public int GetTries(){ return intentos; }

    public void PauseState() {
        _pauseUIObj.SetActive(true);
        _gameUIObj.SetActive(false);
    }

    public void returnToGame() { 
        _pauseUIObj.SetActive(false);
        _gameUIObj.SetActive(true);
    }
    #endregion
}



