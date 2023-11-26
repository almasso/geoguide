using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Level : ScriptableObject
{
    public Texture estrellaActivada;
    public Texture estrellaDesactivada;
    public Color fondoNivel;
    public Color colorLetraNivel;
    public bool estrella1_activada = true;
    public bool estrella2_activada = false;
    public bool estrella3_activada = false;
    public string nivel_Titulo;
    public bool bloqueado = true;
}
