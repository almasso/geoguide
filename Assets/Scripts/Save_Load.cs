using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Save_Load : MonoBehaviour
{
    #region JSON_TEXTS
    protected string level_Info_path = "Assets/Level Menu/nivel_Info.txt";
    protected string levels_path = "Assets/Level Menu/Levels.txt";
    protected string clienteLevel_path = "Assets/Level Menu/ClienteInfo.txt";
    #endregion

    #region UI_ELEMENTS
    protected Sprite estrellaActivada;
    protected Sprite estrellaDesactivada;
    #endregion

    #region INFO_MANAGEMENT
        #region NIVEL_GAME
        [Serializable]
        public class Nivel
        {
            public int index;
            public string name;
            public bool estrella1;
            public bool estrella2;
            public bool estrella3;
        }

        [Serializable]
        public class NivelList
        {
            public Nivel[] nivel;
        }
        public NivelList myLevelList = new NivelList();
        #endregion

        #region INFO_POR_CLIENTE
        [Serializable]
        public class Cliente_Info
        {
            public string name;
            public string pais;
            public string cliente;
            public string pista1;
            public string pista2;
            public string pista3;
            public string objetivo;
        }
        [Serializable]
        public class Cliente_Info_List
        {
            public Cliente_Info[] cliente_Info;
        }
        public Cliente_Info_List myCliente_Info_List = new Cliente_Info_List();
        #endregion

        #region LISTA_NIVELES_INGAME
        [Serializable]
        public class Nivel_Info
        {
            public string name;
            public string intentos;
            public int clientesTotales;
            public bool imprevistos;
            public List<Cliente_Info> clientes_Info = new List<Cliente_Info>();
        }
        [Serializable]
        public class Nivel_Info_List
        {
            public Nivel_Info[] nivel_Info;
        }
        public Nivel_Info_List myLevel_Info_List = new Nivel_Info_List();
        #endregion


    #endregion
    void Awake()
    {
        estrellaActivada = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Level Menu/s1.png");
        estrellaDesactivada = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Level Menu/s2.png");

        TextAsset levels = AssetDatabase.LoadAssetAtPath<TextAsset>(levels_path);
        myLevelList = JsonUtility.FromJson<NivelList>(levels.text);

        TextAsset level_Info = AssetDatabase.LoadAssetAtPath<TextAsset>(level_Info_path);
        myLevel_Info_List = JsonUtility.FromJson<Nivel_Info_List>(level_Info.text);

        TextAsset cliente = AssetDatabase.LoadAssetAtPath<TextAsset>(clienteLevel_path);
        myCliente_Info_List = JsonUtility.FromJson<Cliente_Info_List>(cliente.text);
    }

}
