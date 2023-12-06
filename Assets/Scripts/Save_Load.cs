using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Save_Load : MonoBehaviour
{
    #region JSON_TEXTS
    //levels
    protected string level_Info_JSON;
    protected string level_Info_path;
    protected string level_Info_path_real = "Assets/Level Menu/nivel_Info.txt";
    protected string levelsJSON;
    protected string levels_path;
    protected string levels_path_real = "Assets/Level Menu/Levels.txt";
    //cartas
    protected string cards_info_path = "Assets/Tarjetas Menu/InfoCards/Cards_Info.txt";
    //introLevels
    protected string introLevels_path = "Assets/Introductory Game/IntroductoryLevels.txt";
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
            public bool Country1;
            public string Objective1;
            public bool Country2;
            public string Objective2;
            public bool Country3;
            public string Objective3;
        }

        [Serializable]
        public class IntroLevelList
        {
            public IntroLevel[] IntroLevel;
        }
        public IntroLevelList myIntroLevelList = new IntroLevelList();
    #endregion

    #region LISTA_NIVELES
    [Serializable]
        public class Nivel_Info
        {
            public string name;
            public string intentos;
            public string cliente;
            public string pista1;
            public string pista2;
            public string pista3;
            public string objetivo;
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
        estrellaActivada = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Level Menu/s1.png");
        estrellaDesactivada = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Level Menu/s2.png");
        TextAsset levels = AssetDatabase.LoadAssetAtPath<TextAsset>(levels_path_real);
        levels_path = levels.text;
        myLevelList = JsonUtility.FromJson<NivelList>(levels.text);
        TextAsset level_Info = AssetDatabase.LoadAssetAtPath<TextAsset>(level_Info_path_real);
        level_Info_path = level_Info.text;
        myLevel_Info_List = JsonUtility.FromJson<Nivel_Info_List>(level_Info.text);
        //cartas
        cartaActivada = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Tarjetas Menu/InfoCards/Tarjeta Pais.png");
        cartaDesactivada = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Tarjetas Menu/InfoCards/Tarjeta Pais Bloqueada.png");
        TextAsset cards_info = AssetDatabase.LoadAssetAtPath<TextAsset>(cards_info_path);
        myCardList = JsonUtility.FromJson<CardList>(cards_info.text);
        // introLevels
        TextAsset introLevels_info = AssetDatabase.LoadAssetAtPath<TextAsset>(introLevels_path);
        myIntroLevelList = JsonUtility.FromJson<IntroLevelList>(introLevels_info.text);
    }

}
