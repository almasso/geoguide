using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    #region references
    /// <summary>
    /// Unique GameManager instance (Singleton Pattern).
    /// </summary>
    static private Scene_Manager _instance;
    /// <summary>
    /// Public accesor for GameManager instance.
    /// </summary>
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

    public void StartGamePrueba(int _i)
    {
        refreshData();
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
    public void SettingsMenu()
    {
        refreshData();
        SceneManager.LoadScene("SettingsScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    #endregion
}
