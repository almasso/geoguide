using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Assistant : MonoBehaviour
{
    
    private Text messagetext;
    private string textToWrite=  "Hijo, por fin estas preparado para heredar la empresa! \n" +
        "Se que no controlas mucho los modelos de aviones de la empresa asi que te recuerdo cómo pilotarlo. \n" +
        "Te iré dando más información por el walkie, ¿preparado?";
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
        if(active)
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
