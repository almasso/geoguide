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
    /// <summary>
    /// Reference to UI Manager.
    /// </summary>
    [SerializeField]
    private GameObject _UIManager;
    private UI_Manager _myUIManager;
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
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    #endregion

    void Start()
    {
        _myUIManager = _UIManager.GetComponent<UI_Manager>();
    }

}



