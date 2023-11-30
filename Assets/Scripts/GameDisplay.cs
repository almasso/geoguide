using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDisplay : MonoBehaviour
{
    private JSONReader_GameInfo _JSONReader;
    public string _name;
    public int _intentos;

    void Start()
    {
        _JSONReader = GetComponent<JSONReader_GameInfo>();
        //Debug.Log(_JSONReader.myLevel_Info_List.nivel_Info.Length);
        _name = _JSONReader.myLevel_Info_List.nivel_Info[IndexController._index].name;
        _intentos = _JSONReader.myLevel_Info_List.nivel_Info[IndexController._index].intentos;
    }
}
