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
        //refreshData();
        checkLevelFile();
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
        refreshData();

        IndexController._index = _i;
        IndexController.namePreviousScene = "GameScene";
        if (IndexController._index == 0 || IndexController._index % 5 == 0) SceneManager.LoadScene("IntroductoryLevels");
        else SceneManager.LoadScene("GameScene");
    }
    public void BackToMainMenu()
    {
        refreshData();
        IndexController.namePreviousScene = "LevelScene";
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
