using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    #region references
    [SerializeField]
    private GameObject _loreUIObj;
    [SerializeField]
    private GameObject _endloreUIObj;
    [SerializeField]
    public GameObject _endPrimeroUIObj;
    [SerializeField]
    public GameObject _endNormalUIObj;

    [SerializeField]
    public GameObject _winHUD;
    [SerializeField]
    public GameObject _looseHUD;
    [SerializeField]
    public GameObject _endUIObj;

    [SerializeField]
    private GameObject _gameObjetivoUI;
    [SerializeField]
    private GameObject _gameObjetivoBackgroundUI;
    [SerializeField]
    private GameObject _airportsUI;
    [SerializeField]
    private GameObject _startButton;

    Color green = new Color32(0, 255, 0, 94);

    static private UI_Manager _instance;
    static public UI_Manager Instance
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
    private void Start()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "GameScene":
                StartGameHUD();
                GameManager.Instance._gameUIObj.SetActive(true);
                _endUIObj.SetActive(false);
                GameManager.Instance._pauseUIObj.SetActive(false);
                break;
            case "LevelScene":; break;
            case "MainMenuScene":; break;
            case "MenuTarjetas":; break;
            case "SettingsScene":; break;
            case "IntroductoryLevels":
                _endloreUIObj.SetActive(false);
                _loreUIObj.SetActive(false);
                _winHUD.SetActive(false);
                _startButton.SetActive(false);
                if (IndexController._index == 0)
                {
                    _gameObjetivoUI.SetActive(false);
                    _airportsUI.SetActive(false);
                    _gameObjetivoBackgroundUI.SetActive(false);
                    LoreHUD();
                }
                break;
            default: break;
        }
    }
    public void endLoreUI()
    {
        _loreUIObj.SetActive(false);
        _endloreUIObj.SetActive(true);
        GameManager.Instance._gameUIObj.SetActive(false);
        _airportsUI.SetActive(false);
    }
    public void ActivateAirportsIntroductory()
    {
        _airportsUI.SetActive(true);
        _gameObjetivoUI.SetActive(true);
        _gameObjetivoBackgroundUI.SetActive(true);
    }
    public void ActivateStartButton()
    {
        _startButton.SetActive(true);
    }
    public void StartGameHUD()
    {
        _winHUD.SetActive(false);
        _looseHUD.SetActive(false);
    }
    public void LoreHUD()
    {
        _loreUIObj.SetActive(true);
        GameManager.Instance._gameUIObj.SetActive(false);
    } 
    public void StartIntroductoryLevel()
    {
        GameManager.Instance._gameUIObj.SetActive(true);
        if(IndexController._index == 0)
        {
            _loreUIObj.SetActive(false);
            GameManager.Instance.ActivateIntro();
        }
        GameManager.Instance.changeCountryColor(green);

    }

    public void BackToPauseSettings()
    {
        Scene_Manager.Instance.BackToPauseSettings();

    }
    public void StartGame()
    {
        Scene_Manager.Instance.StartGame();
    }
    public void BackToMainMenu()
    {
        Scene_Manager.Instance.BackToMainMenu();
    }
    public void QuitGame()
    {
        Scene_Manager.Instance.QuitGame();
    }
   
    public void SettingsMenu()
    {
        Scene_Manager.Instance.SettingsMenu();
    }
    public void TarjetasMenu()
    {
        Scene_Manager.Instance.Tarjetasmenu();
    }
    public void EndGameHUD(bool win)
    {
        GameManager.Instance._gameUIObj.SetActive(false);
        _endUIObj.SetActive(true);
        if (win)
        {
            SoundManager.Instance.PlaySFX(SoundManager.Instance.youWon);
            _winHUD.SetActive(true);
            AssignStarts();
        }
        else
        {
            SoundManager.Instance.PlaySFX(SoundManager.Instance.youFailed);
            _looseHUD.SetActive(true);
        }

      
    }
    public void AssignStarts()
    {
        RawImage estrella1 = _winHUD.transform.GetChild(2).gameObject.GetComponent<RawImage>();
        RawImage estrella2 = _winHUD.transform.GetChild(3).gameObject.GetComponent<RawImage>();
        RawImage estrella3 = _winHUD.transform.GetChild(4).gameObject.GetComponent<RawImage>();
        int tries = GameManager.Instance.GetTries();
        if (tries == 0)
        {
            estrella1.texture = Resources.Load<Sprite>("s1").texture;
            estrella2.texture = Resources.Load<Sprite>("s1").texture;
            estrella3.texture = Resources.Load<Sprite>("s1").texture;
           
        }
        else if(tries == 1)
        {
            estrella1.texture = Resources.Load<Sprite>("s1").texture;
            estrella2.texture = Resources.Load<Sprite>("s1").texture;
        }
        else if(tries == 2)
        {
            estrella1.texture = Resources.Load<Sprite>("s1").texture;
        }
    }

   
 
    #endregion
}
