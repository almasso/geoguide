using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    public static List<string> _countriesToVisit;

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
    
   
    public void StartGame()
    {
        SceneManager.LoadScene("LevelsScene");
        IndexController.namePreviousScene = "LevelScene";
    }

    public void StartGamePause()
    {
        SceneManager.LoadScene("LevelsScene");
        IndexController.namePreviousScene = "LevelScene";
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
        IndexController._index = _i;
        IndexController.namePreviousScene = "GameScene";
        if (IndexController._index == 0 || IndexController._index % 5 == 0) SceneManager.LoadScene("IntroductoryLevels");
        else SceneManager.LoadScene("GameScene");
    }
    public void BackToMainMenu()
    {
        IndexController.namePreviousScene = "LevelScene";
        SceneManager.LoadScene("MainMenuScene");
    }
    public void Tarjetasmenu()
    {
        SceneManager.LoadScene("MenuTarjetas");
    }

    public void TarjetasDesdePausa()
    {
        PlayScene("MenuTarjetas");
    }
    public void SettingsMenu()
    {
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
