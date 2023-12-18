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
    }

    public void StartGamePause()
    {
        LevelChanger _lvlChngr = _levelChanger.GetComponent<LevelChanger>();
        _lvlChngr.FadeScreen();
       // SceneManager.UnloadScene("GameScene");
        SceneManager.LoadScene("LevelsScene");
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        GameManager.Instance.PauseState();
    }

    public void BackToPause() {
        UnloadScene("MenuTarjetas");
    }

    public void BackToGame()
    {
        Time.timeScale = 1;
        GameManager.Instance.returnToGame();
    }

    public void StartGamePrueba(int _i)
    {
        refreshData();

        Debug.Log(_i);
        IndexController._index = _i;
        SceneManager.LoadScene("GameScene");
    }
    public void BackToMainMenu()
    {
        refreshData();
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
