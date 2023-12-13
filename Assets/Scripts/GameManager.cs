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
    private GameObject _gameObj;
    private GameDisplay _game;

    [SerializeField]
    private GameObject[] _ClueObj;

    [SerializeField]
    private GameObject _HandObj;
    private HandWave _hand;
    
    [SerializeField]
    public int intentos = 0;

    [SerializeField]
    private GameObject[] _countries;

    void Start()
    {
        _game = _gameObj.GetComponent<GameDisplay>();
        GameSceneInfo.setObjectiveCountry(_game.myIntroLevelList.IntroLevel[_game.introIndex].Country1);
        _hand = _HandObj.GetComponent<HandWave>();
        //UI_Manager.Instance.StartGameHUD();
        updateCountryObject(GameSceneInfo.getObjectiveCountry());
        changeCountryColor(Color.green);
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

    public void updateIntroCountry(string country)
    {
        changeCountryColor(Color.red);
        if (country == _game.myIntroLevelList.IntroLevel[_game.introIndex].Country1) GameSceneInfo.setObjectiveCountry(_game.myIntroLevelList.IntroLevel[_game.introIndex].Country2);
        else if (country == _game.myIntroLevelList.IntroLevel[_game.introIndex].Country2) GameSceneInfo.setObjectiveCountry(_game.myIntroLevelList.IntroLevel[_game.introIndex].Country3);
        else Debug.Log("ultimo");

        updateCountryObject(GameSceneInfo.getObjectiveCountry());
        changeCountryColor(Color.green);

        _game.updateIntroObjective();
    }

    void updateCountryObject(string country)
    {
        for (int i = 0; i < _countries.Length; i++)
        {
            //Debug.Log(_countries[i].name);
            //Debug.Log(country);
            if (_countries[i].name == country) {
                actualCountryObject = _countries[i].transform.GetChild(0).gameObject; 
            }
        }
    }

    void changeCountryColor(Color c)
    {
        actualCountryObject.GetComponent<MeshRenderer>().material.color = c;
    }

  
    #endregion
}



