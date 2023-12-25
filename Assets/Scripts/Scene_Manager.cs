using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

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
        checkLevelFile();
        Time.timeScale = 1;
        SceneManager.LoadScene("LevelsScene");
        IndexController.namePreviousScene = "LevelsScene";
        IndexController.nameActualScene = "LevelsScene";
    }

    public void StartGamePause()
    {
        SceneManager.LoadScene("LevelsScene");
        IndexController.namePreviousScene = "LevelsScene";
        IndexController.nameActualScene = "LevelsScene";

    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        GameManager.Instance.PauseState();
    }

    public void BackToPause() {
        if (IndexController.namePreviousScene == "GameScene")
        {
            IndexController.nameActualScene = "GameScene";
            UnloadScene("MenuTarjetas");
        }
        else
        {
            StartGame();
            IndexController.nameActualScene = "LevelsScene";
        }
    }
    public void BackToPauseSettings()
    {
        if (IndexController.namePreviousScene == "GameScene")
        {
            IndexController.nameActualScene = "GameScene";
            UnloadScene("SettingsScene");
        }
        else
        {
            StartGame();
            IndexController.nameActualScene = "LevelsScene";

        }
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
        IndexController.nameActualScene = "GameScene";
        if (IndexController._index == 0 || IndexController._index % 5 == 0) SceneManager.LoadScene("IntroductoryLevels");
        else SceneManager.LoadScene("GameScene");
    }
    public void BackToMainMenu()
    {
        IndexController.namePreviousScene = "LevelsScene";
        SceneManager.LoadScene("MainMenuScene");
        IndexController.nameActualScene = "MainMenuScene";
    }
    public void Tarjetasmenu()
    {
        SceneManager.LoadScene("MenuTarjetas");
        IndexController.nameActualScene = "MenuTarjetas";
    }

    public void TarjetasDesdePausa()
    {
        PlayScene("MenuTarjetas");
    }

    public void SettingsDesdePausa()
    {
        PlayScene("SettingsScene");
    }
    public void SettingsMenu()
    {
        SceneManager.LoadScene("SettingsScene");
        IndexController.nameActualScene = "SettingsScene";
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayScene(string nameScene)
    {
        SceneManager.LoadSceneAsync(nameScene, LoadSceneMode.Additive);
        IndexController.nameActualScene = nameScene;

    }

    public void UnloadScene(string nameScene)
    {
        SceneManager.UnloadSceneAsync(nameScene);
    }

    public void checkLevelFile()
    {
        var ruta1 = Path.Combine(Application.persistentDataPath, "nivel_Info.txt");
        var ruta2 = Path.Combine(Application.persistentDataPath, "Levels.txt");
        var ruta3 = Path.Combine(Application.persistentDataPath, "ClienteInfo.txt");
        var ruta4 = Path.Combine(Application.persistentDataPath, "Cards_Info.txt");
        var ruta5 = Path.Combine(Application.persistentDataPath, "IntroductoryLevels.txt");
        if (!File.Exists(ruta1)) File.Copy("Assets/Level Menu/Resources/nivel_Info.txt", ruta1);
        if (!File.Exists(ruta2)) File.Copy("Assets/Level Menu/Resources/Levels.txt", ruta2);
        if (!File.Exists(ruta3)) File.Copy("Assets/Level Menu/Resources/ClienteInfo.txt", ruta3);
        if (!File.Exists(ruta4)) File.Copy("Assets/Tarjetas Menu/InfoCards/Resources/Cards_Info.txt", ruta4);
        if (!File.Exists(ruta5)) File.Copy("Assets/Introductory Game/Resources/IntroductoryLevels.txt", ruta5);
    }
    #endregion
}
