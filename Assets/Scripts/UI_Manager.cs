using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    #region references
    /// <summary>
    /// Unique GameManager instance (Singleton Pattern).
    /// </summary>
    static private UI_Manager _instance;
    /// <summary>
    /// Public accesor for GameManager instance.
    /// </summary>
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
    public void StartGame()
    {
        GameManager.Instance.StartGame();
    }
    public void BackToMainMenu()
    {
        GameManager.Instance.BackToMainMenu();
    }
    public void QuitGame()
    {
        GameManager.Instance.QuitGame();
    }
    public void ExpandCard()
    {
        CardManager.Instance.ExpandCard(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject);
    }
    public void SettingsMenu()
    {
        GameManager.Instance.SettingsMenu();
    }
    public void TarjetasMenu()
    {
        GameManager.Instance.Tarjetasmenu();
    }
    #endregion
}
