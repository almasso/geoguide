using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    #region references
    [SerializeField] private GameObject _winHUD;
    [SerializeField] private GameObject _looseHUD;
    [SerializeField]
    private GameObject _endUIObj;
    [SerializeField]
    private GameObject _loreUIObj;
    [SerializeField]
    private GameObject _pauseUIObj;
    [SerializeField]
    private GameObject _gameUIObj;

    Color red = new Color32(255, 0, 0, 94);
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
                _gameUIObj.SetActive(true);
                _endUIObj.SetActive(false);
                _pauseUIObj.SetActive(false);
                break;
            case "LevelScene":; break;
            case "MainMenuScene":; break;
            case "MenuTarjetas":; break;
            case "SettingsScene":; break;
            case "IntroductoryLevels":
                LoreHUD();
                 break;
            default: break;
        }
    }
    public void StartGameHUD()
    {
        _winHUD.SetActive(false);
        _looseHUD.SetActive(false);
    }
    public void LoreHUD()
    {
        _loreUIObj.SetActive(true);
    } 
    public void StartIntroductoryLevel()
    {
        _loreUIObj.SetActive(false);
        GameManager.Instance.changeCountryColor(green);
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
    public void ExpandCard()
    {
        CardManager.Instance.ExpandCard(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject);
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
        _gameUIObj.SetActive(false);
        _endUIObj.SetActive(true);
        if (win)
        {
            _winHUD.SetActive(true);
            AssignStarts();
        }
        else _looseHUD.SetActive(true);

      
    }
    public void AssignStarts()
    {
        RawImage estrella1 = _winHUD.transform.GetChild(2).gameObject.GetComponent<RawImage>();
        RawImage estrella2 = _winHUD.transform.GetChild(3).gameObject.GetComponent<RawImage>();
        RawImage estrella3 = _winHUD.transform.GetChild(4).gameObject.GetComponent<RawImage>();
        int tries = GameManager.Instance.GetTries();
        if (tries == 0)
        {
            estrella1.texture = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Level Menu/s1.png").texture;
            estrella2.texture = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Level Menu/s1.png").texture;
            estrella3.texture = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Level Menu/s1.png").texture;
           
        }
        else if(tries == 1)
        {
            estrella1.texture = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Level Menu/s1.png").texture;
            estrella2.texture = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Level Menu/s1.png").texture;
        }
        else if(tries == 2)
        {
            estrella1.texture = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Level Menu/s1.png").texture;
        }
    }

    public void PauseState()
    {
        _pauseUIObj.SetActive(true);
        _gameUIObj.SetActive(false);
    }
    public void returnToGame()
    {
        _pauseUIObj.SetActive(false);
        _gameUIObj.SetActive(true);
    }
    #endregion
}
