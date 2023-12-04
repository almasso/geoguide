using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region parameters
    private float _elapsedTime;
    private float _firstClue = 5;
    private float _secondClue = 10;
    private float _thirdClue = 15;
    private bool inGame = false;
    private bool firstClue = false;
    private bool secondClue = false;
    private bool thirdClue = false;

    [SerializeField]
    private ButtonClue[] buttonList;
    #endregion

    #region methods
    void Start()
    {
        for (int i = 0; i < buttonList.Length; ++i) buttonList[i] = gameObject.GetComponent<ButtonClue>();
    }

    void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= _firstClue && !firstClue)
        {
            Debug.Log("Primera Pista");
            firstClue = true;
            buttonList[0].EnableButton();
        }
        else if (_elapsedTime >= _secondClue && !secondClue)
        {
            Debug.Log("Segunda Pista");
            secondClue = true;
            buttonList[1].EnableButton();
        }
        else if (_elapsedTime >= _thirdClue && !thirdClue)
        {
            Debug.Log("Tercera Pista");
            thirdClue = true;
            buttonList[2].EnableButton();
        }
    }
    #endregion
}



