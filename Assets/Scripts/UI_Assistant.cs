using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Assistant : MonoBehaviour
{
    
    private Text messagetext;
    private string textToWrite=  "Hijo, �Por fin estas preparado para heredar la empresa! \n" +
        "S� que no controlas mucho los modelos de avi�n de la compa��a asi que te recuerdo c�mo pilotarlo. \n" +
        "Te ir� dando m�s informaci�n por el walkie. �Preparado?";
    private float timer = 0f;
    private bool active = true;

    private void Awake()
    {
    
        messagetext = transform.Find("message").Find("messageText").GetComponent<Text>();
    }

    private void Start()
    {
        active = true;
        TextWriter.AddWriter_Static(messagetext, textToWrite, .05f, true);
    }
   

    private void Update()
    {
        if(active && IndexController._index == 0)
        {
            timer += Time.deltaTime;
            if(timer >= 11f)
            {
                TextWriter.active = false;
                active = false;
                GameManager.Instance.ActivateStartButtonIntro();

            }
        }
    }
}
