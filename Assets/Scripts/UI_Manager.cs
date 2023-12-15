using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

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
        if (win)
        {
            _winHUD.SetActive(true);
            AssignStarts();
        }
        else _looseHUD.SetActive(true);

      
    }
    public void AssignStarts()
    {
        RawImage estrella1 = _winHUD.transform.GetChild(2).gameObject.GetComponent<RawImage>();
        RawImage estrella2 = _winHUD.transform.GetChild(3).gameObject.GetComponent<RawImage>();
        RawImage estrella3 = _winHUD.transform.GetChild(4).gameObject.GetComponent<RawImage>();
        int tries = GameManager.Instance.GetTries();
        if (tries == 0)
        {
            estrella1.texture = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Level Menu/s1.png").texture;
            estrella2.texture = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Level Menu/s1.png").texture;
            estrella3.texture = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Level Menu/s1.png").texture;
           
        }
        else if(tries == 1)
        {
            estrella1.texture = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Level Menu/s1.png").texture;
            estrella2.texture = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Level Menu/s1.png").texture;
        }
        else if(tries == 2)
        {
            estrella1.texture = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Level Menu/s1.png").texture;
        }
    }
    #endregion
}
