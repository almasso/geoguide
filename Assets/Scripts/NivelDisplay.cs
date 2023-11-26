using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NivelDisplay : MonoBehaviour
{
    private JSONReader _JSONReader;
    public int index = 0;
    private RawImage estrella_1;
    private RawImage estrella_2;
    private RawImage estrella_3;
    private RawImage fondoNivel;
    private TextMeshProUGUI nivel_Titulo;
    void Start()
    {
        _JSONReader = GetComponentInParent<JSONReader>();
        estrella_1 = gameObject.transform.GetChild(0).gameObject.GetComponent<RawImage>();
        estrella_2 = gameObject.transform.GetChild(1).gameObject.GetComponent<RawImage>();
        estrella_3 = gameObject.transform.GetChild(2).gameObject.GetComponent<RawImage>();
        fondoNivel = gameObject.transform.GetChild(3).gameObject.GetComponent<RawImage>();
        nivel_Titulo = gameObject.transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>();
        if (_JSONReader != null)
        {
            if (_JSONReader.myLevelList.nivel[index].estrella1) estrella_1.texture = _JSONReader.estrellaActivada.texture;
            else estrella_1.texture = _JSONReader.estrellaDesactivada.texture;
            if (_JSONReader.myLevelList.nivel[index].estrella2) estrella_2.texture = _JSONReader.estrellaActivada.texture;
            else estrella_2.texture = _JSONReader.estrellaDesactivada.texture;
            if (_JSONReader.myLevelList.nivel[index].estrella3) estrella_3.texture = _JSONReader.estrellaActivada.texture;
            else estrella_3.texture = _JSONReader.estrellaDesactivada.texture;

            nivel_Titulo.text = _JSONReader.myLevelList.nivel[index].name;
            if (!_JSONReader.myLevelList.nivel[index].active)
            {
                nivel_Titulo.color = Color.black;
                fondoNivel.color = Color.gray;
            }
        }
        else Debug.Log("No existe");
    }

}
