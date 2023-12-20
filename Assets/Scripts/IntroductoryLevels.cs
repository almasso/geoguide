using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroductoryLevels : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        UI_Manager.Instance.LoreHUD();
    }

    public void StartIntroductoryLevel()
    {
        Time.timeScale = 1;
    }
}
