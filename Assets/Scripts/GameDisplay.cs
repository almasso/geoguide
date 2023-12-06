using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameDisplay : Save_Load
{
    private RawImage cliente;
    private Transform pistaPrefab1;
    private Transform pistaPrefab2;
    private Transform pistaPrefab3;
    private TMPro.TextMeshProUGUI texto_Pista1;
    private TMPro.TextMeshProUGUI texto_Pista2;
    private TMPro.TextMeshProUGUI texto_Pista3;
    private TMPro.TextMeshProUGUI objetivo;
    private Sprite _myCliente;
    void Start()
    {
        Debug.Log(myIntroLevelList.IntroLevel.Length);

        cliente = gameObject.transform.GetChild(0).gameObject.GetComponent<RawImage>();
        objetivo = gameObject.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "GameScene")
        {
            pistaPrefab1 = gameObject.transform.GetChild(1);
            pistaPrefab2 = gameObject.transform.GetChild(2);
            pistaPrefab3 = gameObject.transform.GetChild(3);
            texto_Pista1 = pistaPrefab1.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>();
            texto_Pista2 = pistaPrefab2.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>();
            texto_Pista3 = pistaPrefab3.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>();

            _myCliente = AssetDatabase.LoadAssetAtPath<Sprite>(myLevel_Info_List.nivel_Info[IndexController._index].cliente);
            cliente.texture = _myCliente.texture;

            texto_Pista1.text = myLevel_Info_List.nivel_Info[IndexController._index].pista1;
            texto_Pista2.text = myLevel_Info_List.nivel_Info[IndexController._index].pista2;
            texto_Pista3.text = myLevel_Info_List.nivel_Info[IndexController._index].pista3;
            objetivo.text = myLevel_Info_List.nivel_Info[IndexController._index].objetivo;
        }
        else if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "IntroductoryLevels")
        {
            cliente.texture = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Clients/dad.png");
            objetivo.text = myIntroLevelList.IntroLevel[0].Objective1;
        }
    }

}
