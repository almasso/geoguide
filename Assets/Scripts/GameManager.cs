using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region references
    /// <summary>
    /// Unique GameManager instance (Singleton Pattern).
    /// </summary>
    static private GameManager _instance;
    /// <summary>
    /// Public accesor for GameManager instance.
    /// </summary>
    static public GameManager Instance
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
    }

    public void StartGamePrueba(int _i)
    {
        IndexController._index = _i;
        SceneManager.LoadScene("PruebaGameScene");
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
     public void Tarjetasmenu()
    {
        SceneManager.LoadScene("MenuTarjetas");
    }
    public void SettingsMenu()
    {
        SceneManager.LoadScene("SettingsScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    #endregion

    void Start()
    {
    
    }

}



