using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    #region methods
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
    public void TarjetasMenu()
    {
        GameManager.Instance.Tarjetasmenu();
    }
    #endregion
}
