using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    public static List<string> _countriesToVisit;
    [SerializeField] private GameObject _levelChanger;


    #region references
    static private Scene_Manager _instance;
    static public Scene_Manager Instance
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
        refreshData();
    }
    public void refreshData()
    {
        AssetDatabase.Refresh();

    }
    public void StartGame()
    {
        refreshData();
        SceneManager.LoadScene("LevelsScene");
        IndexController.namePreviousScene = "LevelsScene";
    }

    public void StartGamePause()
    {
        SceneManager.LoadScene("LevelsScene");
        IndexController.namePreviousScene = "LevelsScene";
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        GameManager.Instance.PauseState();
    }

    public void BackToPause() {
        if (IndexController.namePreviousScene == "GameScene")
            UnloadScene("MenuTarjetas");
        else StartGame();
    }

    public void BackToGame()
    {
        Time.timeScale = 1;
        GameManager.Instance.returnToGame();
    }

    public void StartGamePrueba(int _i)
    {
        refreshData();

        IndexController._index = _i;
        IndexController.namePreviousScene = "GameScene";
        if (IndexController._index == 0 || IndexController._index % 5 == 0) SceneManager.LoadScene("IntroductoryLevels");
        else SceneManager.LoadScene("GameScene");
    }
    public void BackToMainMenu()
    {
        refreshData();
        IndexController.namePreviousScene = "LevelsScene";
        SceneManager.LoadScene("MainMenuScene");
    }
    public void Tarjetasmenu()
    {
        refreshData();
        SceneManager.LoadScene("MenuTarjetas");
    }

    public void TarjetasDesdePausa()
    {
        PlayScene("MenuTarjetas");
    }
    public void SettingsMenu()
    {
        refreshData();
        SceneManager.LoadScene("SettingsScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayScene(string nameScene)
    {
        SceneManager.LoadSceneAsync(nameScene, LoadSceneMode.Additive);
    }

    public void UnloadScene(string nameScene)
    {
        SceneManager.UnloadSceneAsync(nameScene);
    }
    #endregion
}
