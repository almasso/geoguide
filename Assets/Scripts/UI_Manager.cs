using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    #region references
    /// <summary>
    /// Reference to object containing Main Menu objects
    /// </summary>
    [SerializeField]
    private GameObject _mainMenu;
    /// <summary>
    /// Reference to object containing Start Button
    /// </summary>
    [SerializeField]
    private GameObject _startButton;
    /// <summary>
    /// Reference to object containing Quit Button
    /// </summary>
    [SerializeField]
    private GameObject _quitButton;
    #endregion

    #region methods
    // Start is called before the first frame update
    private void Awake()
    {
        SetMainMenu(true);
    }

    /// <summary>
    /// Allows to activate and deactivate Main menu.
    /// </summary>
    /// <param name="enabled">New active state for Main menu.</param>
    public void SetMainMenu(bool enabled)
    {
        _mainMenu.SetActive(enabled);
        _startButton.SetActive(enabled);
        _quitButton.SetActive(enabled);
    }

    /// <summary>
    /// Calls Game Manager method to Quit Game.
    /// </summary>
    public void QuitGame()
    {
        GameManager.Instance.QuitGame();
    }
    #endregion
}
