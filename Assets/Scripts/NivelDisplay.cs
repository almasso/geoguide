using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NivelDisplay : Save_Load
{
    public int index = 0;
    private RawImage estrella_1;
    private RawImage estrella_2;
    private RawImage estrella_3;
    private Button boton;
    private TextMeshProUGUI nivel_Titulo;
   
    void Start()
    {
        estrella_1 = gameObject.transform.GetChild(0).gameObject.GetComponent<RawImage>();
        estrella_2 = gameObject.transform.GetChild(1).gameObject.GetComponent<RawImage>();
        estrella_3 = gameObject.transform.GetChild(2).gameObject.GetComponent<RawImage>();
        boton = gameObject.transform.GetChild(3).gameObject.GetComponent<Button>();
        nivel_Titulo = boton.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        boton.onClick.AddListener(delegate () { Scene_Manager.Instance.StartGamePrueba(index); });
       
        if (myLevelList.nivel[index].estrella1) estrella_1.texture = estrellaActivada.texture;
        else estrella_1.texture = estrellaDesactivada.texture;
        if (myLevelList.nivel[index].estrella2) estrella_2.texture = estrellaActivada.texture;
        else estrella_2.texture = estrellaDesactivada.texture;
        if (myLevelList.nivel[index].estrella3) estrella_3.texture = estrellaActivada.texture;
        else estrella_3.texture = estrellaDesactivada.texture;

        nivel_Titulo.text = myLevelList.nivel[index].name;
           
        if(index > 0)
        {
            if (myLevelList.nivel[index-1].estrella1 == true)
            {
                boton.interactable = true;
            }
            else boton.interactable = false;
        }
        else boton.interactable = true;
    }
}

