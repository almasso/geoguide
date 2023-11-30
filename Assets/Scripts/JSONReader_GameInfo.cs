using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader_GameInfo : JSONReader
{
    public TextAsset level_Info_JSON;
    [Serializable]
    public class Nivel_Info
    {
        public string name;
        public int intentos;
    }
    [Serializable]
    public class Nivel_Info_List
    {
        public Nivel_Info[] nivel_Info;
    }

    public Nivel_Info_List myLevel_Info_List = new Nivel_Info_List();

    void Awake()
    {
        myLevel_Info_List = JsonUtility.FromJson<Nivel_Info_List>(level_Info_JSON.text);
    }
}
