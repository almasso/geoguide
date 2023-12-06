using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    #region references
    [SerializeField] private GameObject _winHUD;
    [SerializeField] private GameObject _looseHUD;
    static private UI_Manager _instance;
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
    public void StartGameHUD()
    {
        _winHUD.SetActive(false);
        _looseHUD.SetActive(false);
    }
    public void StartGame()
    {
        Scene_Manager.Instance.StartGame();
    }
    public void BackToMainMenu()
    {
        Scene_Manager.Instance.BackToMainMenu();
    }
    public void QuitGame()
    {
        Scene_Manager.Instance.QuitGame();
    }
    public void ExpandCard()
    {
        CardManager.Instance.ExpandCard(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject);
    }
    public void SettingsMenu()
    {
        Scene_Manager.Instance.SettingsMenu();
    }
    public void TarjetasMenu()
    {
        Scene_Manager.Instance.Tarjetasmenu();
    }
    public void EndGameHUD(bool win)
    {
        if (win) _winHUD.SetActive(true);
        else _looseHUD.SetActive(true);
    }
    #endregion
}
