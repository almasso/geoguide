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
    int actualClient = 0;
    int clientesTotales = 1;
    int index = 0;
    public int introIndex = 0;

    void Start()
    {
        Debug.Log(IndexController._index);
        Debug.Log(index);
        IndexController.paisesPorNivel.Clear();
        clientesTotales = myLevel_Info_List.nivel_Info[IndexController._index].clientesTotales;
        IndexController._imprevisto = myLevel_Info_List.nivel_Info[IndexController._index].imprevistos;
        cliente = gameObject.transform.GetChild(0).gameObject.GetComponent<RawImage>();
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "GameScene")
        {
            objetivo = gameObject.transform.GetChild(4).gameObject.GetComponent<TMPro.TextMeshProUGUI>();

            pistaPrefab1 = gameObject.transform.GetChild(1);
            pistaPrefab2 = gameObject.transform.GetChild(2);
            pistaPrefab3 = gameObject.transform.GetChild(3);
            texto_Pista1 = pistaPrefab1.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>();
            texto_Pista2 = pistaPrefab2.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>();
            texto_Pista3 = pistaPrefab3.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>();

            while (myCliente_Info_List.cliente_Info[index].name != myLevel_Info_List.nivel_Info[IndexController._index].name)
            {
                Debug.Log(index);
                ++index;
            } 

            for (int j = 0; j < clientesTotales; ++j)
            {
                myLevel_Info_List.nivel_Info[IndexController._index].clientes_Info.Add(myCliente_Info_List.cliente_Info[index+j]);
                IndexController.paisesPorNivel.Add(myCliente_Info_List.cliente_Info[index + j].pais);
            }
            AddClient();
        }
        else if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "IntroductoryLevels")
        {
            objetivo = gameObject.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>();
            cliente.texture = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Clients/dad.png");
            objetivo.text = myIntroLevelList.IntroLevel[0].Objective1;
            GameSceneInfo.setObjectiveCountry(myIntroLevelList.IntroLevel[0].Objective1);
        }

    }
    void AddClient()
    {
        var aux = myLevel_Info_List.nivel_Info[IndexController._index].clientes_Info[actualClient];
        _myCliente = AssetDatabase.LoadAssetAtPath<Sprite>(aux.cliente);
        cliente.texture = _myCliente.texture;

        texto_Pista1.text = aux.pista1;
        texto_Pista2.text = aux.pista2;
        texto_Pista3.text = aux.pista3;
        objetivo.text = aux.objetivo;
        GameSceneInfo.setObjectiveCountry(aux.pais);
    }
   
    public void nextClient()
    {
        ++actualClient;
        AddClient();
    }
    public bool HasMoreClients() { return actualClient < clientesTotales - 1;}

    public void updateIntroObjective() {
        if (objetivo.text == myIntroLevelList.IntroLevel[introIndex].Objective1) objetivo.text = myIntroLevelList.IntroLevel[introIndex].Objective2;
        else if (objetivo.text == myIntroLevelList.IntroLevel[introIndex].Objective2) objetivo.text = myIntroLevelList.IntroLevel[introIndex].Objective3;
    }
}
