using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Save_Load;

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
    private GameObject _gameObj;
    private GameDisplay _game;
    [SerializeField]
    private GameObject[] _ClueObj;

    [SerializeField]
    public GameObject _pauseUIObj;
    [SerializeField]
    public GameObject _gameUIObj;
   

    [SerializeField]
    private GameObject _HandObj;
    private HandWave _hand;

    [SerializeField]
    private GameObject _player;
    private PlaneTrail _planeTrail;
    private PlayerController _planeController;

    [SerializeField]
    public int intentos = 0;
    public int cliente = 0;
    [SerializeField]
    private GameObject[] _countries;
    [SerializeField]
    private GameObject _introObj;
    private IntroductoryLevels _introductoryLevel;

    Color red = new Color32(255, 0, 0, 94);
    Color green = new Color32(0, 255, 0, 94);
    void Start()
    {
        SoundManager.Instance.changeMusic();
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "IntroductoryLevels")
        {
            _introductoryLevel = _introObj.GetComponent<IntroductoryLevels>();
        }

        _planeController = _player.GetComponent<PlayerController>();
        _planeTrail = _player.GetComponent<PlaneTrail>();
        _game = _gameObj.GetComponent<GameDisplay>();
        _hand = _HandObj.GetComponent<HandWave>();
        _planeTrail.Activate(true);
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "IntroductoryLevels")
            GameSceneInfo.setObjectiveCountry(_game.myIntroLevelList.IntroLevel[IndexController._index / 5].Country1);
        //Debug.Log("Hola: " +GameSceneInfo.getObjectiveCountry());
        updateCountryObject(GameSceneInfo.getObjectiveCountry());
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "IntroductoryLevels" && IndexController._index != 0) changeCountryColor(green);
    }

    public void ChangeClient()
    {
        if (_game.HasMoreClients())
        {
            _game.nextClient();
            for (int i = 0; i < 3; ++i)
            {
                _ClueObj[i].GetComponent<ButtonClue>().hasChangedClient();
            }
            _hand.InstanciateHand();
            _planeTrail.Activate(true);
            cliente++;
        }
        else
        {
            fail();
        }
    }

    public void fail()
    {
        UI_Manager.Instance.EndGameHUD(intentos < 3);
        _planeController.DeactivatePlayer();
        _planeTrail.Activate(false);
    }

    public void updateIntroCountry(string country)
    {
        changeCountryColor(red);
        if (country == _game.myIntroLevelList.IntroLevel[IndexController._index / 5].Country1) GameSceneInfo.setObjectiveCountry(_game.myIntroLevelList.IntroLevel[IndexController._index / 5].Country2);
        else if (country == _game.myIntroLevelList.IntroLevel[IndexController._index / 5].Country2) GameSceneInfo.setObjectiveCountry(_game.myIntroLevelList.IntroLevel[IndexController._index / 5].Country3);
        else {
            if (IndexController._index == 0) UI_Manager.Instance.endLoreUI();
            else { intentos = 0; UI_Manager.Instance.EndGameHUD(true); }
        }

        updateCountryObject(GameSceneInfo.getObjectiveCountry());
        changeCountryColor(green);

        _game.updateIntroObjective();
    }

    public void updateCountryObject(string country)
    {
        for (int i = 0; i < _countries.Length; i++)
        {
            //Debug.Log(_countries[i].name + " " + country);
            if (_countries[i].name == country) {
                actualCountryObject = _countries[i].gameObject; 
            }
        }
    }

    public void changeCountryColor(Color c)
    {
        actualCountryObject.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material.color = c;
    }

   public void WrongCountry() { 
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "GameScene")
        {
            ++intentos;
            int i = 0;
            bool encontrado = false;
            while(!encontrado && i < _ClueObj.Length)
            {
                if (!_ClueObj[i].GetComponent<ButtonClue>().isActive())
                {
                    encontrado = true;
                    _ClueObj[i].GetComponent<ButtonClue>().setMaximumElapsedTime();
                }
                ++i;
            }
        }
    }
    public bool hasMoreClients() { return _game.HasMoreClients(); }
    public void DeactivateTrails()
    {
        _planeTrail.Activate(false);
    }
    public int GetTries(){ return intentos; }
    public void PauseState() {
        _pauseUIObj.SetActive(true);
        _gameUIObj.SetActive(false);
    }
    public void ActivateStartButtonIntro() { UI_Manager.Instance.ActivateStartButton(); }
    public void ActivateIntro() { if(IndexController._index == 0) _introductoryLevel.actiavteIntro(); }
    public void returnToGame() {
        _pauseUIObj.SetActive(false);
        _gameUIObj.SetActive(true);
    }
   
    #endregion
}



