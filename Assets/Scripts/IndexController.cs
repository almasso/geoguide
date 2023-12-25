using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class IndexController
{
    public static int _index = 0;
    public static AudioSource _audioActual = null;

    public static float _volume = 1;
    public static bool _fullScreen = true;

    public static List<string> paisesPorNivel = new List<string>();

    public static string namePreviousScene = "LevelScene";
    public static string nameActualScene = "MainMenuScene";

    public static bool _imprevisto;
}
