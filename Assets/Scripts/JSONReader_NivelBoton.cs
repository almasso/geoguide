using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class JSONReader_NivelBoton :  JSONReader
{
    public TextAsset levelsJSON;
    public Sprite estrellaActivada;
    public Sprite estrellaDesactivada;

    [Serializable]
    public class Nivel
    {
        public string name;
        public bool estrella1;
        public bool estrella2;
        public bool estrella3;
        public bool active;
    }

    [Serializable]
    public class NivelList
    {
        public Nivel[] nivel;
    }

    public NivelList myLevelList = new NivelList();

    void Awake()
    {
        myLevelList = JsonUtility.FromJson<NivelList>(levelsJSON.text);
    }
}
