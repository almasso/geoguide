using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSONWriter : MonoBehaviour
{
    [System.Serializable]
    public class Nivel_Info
    {
        public string name;
        public int intentos;
    }
   
    public Nivel_Info myLevel_Info_List = new Nivel_Info();

    public void outputJSON()
    {
        string strOutput = JsonUtility.ToJson(myLevel_Info_List);
        File.WriteAllText(Application.dataPath + "/Scripts/nivel_Info.txt", strOutput);
    }
}
