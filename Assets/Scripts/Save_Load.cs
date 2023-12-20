using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Save_Load : MonoBehaviour
{
    #region JSON_TEXTS
    
    //cartas
    protected string cards_info_path = "Cards_Info";
    protected string cards_info_path_real = "Assets/Tarjetas Menu/InfoCards/Resources/Cards_Info.txt";
    //introLevels
    protected string introLevels_path = "IntroductoryLevels";
    protected string introLevels_path_real = "Assets/Introductory Game/Resources/IntroductoryLevels.txt";
    //levels
    protected string level_Info_path = "nivel_Info";
    protected string level_Info_path_real = "Assets/Level Menu/Resources/nivel_Info.txt";

    protected string levels_path = "Levels";
    protected string levels_path_real = "Assets/Level Menu/Resources/Levels.txt";

    //clientes
    protected string clienteLevel_path = "ClienteInfo";
    protected string clienteLevel_path_real = "Assets/Level Menu/Resources/ClienteInfo.txt";

    #endregion

    #region UI_ELEMENTS
    //levels
    protected Sprite estrellaActivada;
    protected Sprite estrellaDesactivada;
    //cartas
    protected Sprite cartaActivada;
    protected Sprite cartaDesactivada;
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

        #region CARTA
        [Serializable]
        public class Card
        {
            public int index;
            public string name;
            public bool isActive;
            public string capital;
            public string languaje;
            public string currency;
            public string climate;
            public string info;
            public string mapPos;
            public string flag;
            public string memory;
        }

        [Serializable]
        public class CardList
        {
            public Card[] card;
        }
        public CardList myCardList = new CardList();
    #endregion

        #region INTROLEVELS
        [Serializable]
        public class IntroLevel
        {
            public string Continent;
            public string Country1;
            public string Objective1;
            public string Country2;
            public string Objective2;
            public string Country3;
            public string Objective3;
        }

        [Serializable]
        public class IntroLevelList
        {
            public IntroLevel[] IntroLevel;
        }
        public IntroLevelList myIntroLevelList = new IntroLevelList();
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
            public string pais;
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
        //levels
        estrellaActivada = Resources.Load<Sprite>("s1");
        estrellaDesactivada = Resources.Load<Sprite>("s2");

        TextAsset levels = Resources.Load<TextAsset>(levels_path);
        myLevelList = JsonUtility.FromJson<NivelList>(levels.text);

        TextAsset level_Info = Resources.Load<TextAsset>(level_Info_path);
        myLevel_Info_List = JsonUtility.FromJson<Nivel_Info_List>(level_Info.text);

        //cartas
        cartaActivada = Resources.Load<Sprite>("Tarjeta Pais");
        cartaDesactivada = Resources.Load<Sprite>("Tarjeta Pais Bloqueada");
        TextAsset cards_info = Resources.Load<TextAsset>(cards_info_path);
        myCardList = JsonUtility.FromJson<CardList>(cards_info.text);
        
        // introLevels
        TextAsset introLevels_info = Resources.Load<TextAsset>(introLevels_path);
        myIntroLevelList = JsonUtility.FromJson<IntroLevelList>(introLevels_info.text);

        // cliente
        TextAsset cliente = Resources.Load<TextAsset>(clienteLevel_path);
        myCliente_Info_List = JsonUtility.FromJson<Cliente_Info_List>(cliente.text);
    }

}
