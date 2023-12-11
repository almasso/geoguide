using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneInfo
{
    private static string objectiveCountry;

    public static void setObjectiveCountry(string s)
    {
        objectiveCountry = s;
    }

    public static string getObjectiveCountry() {  return objectiveCountry; }
}
