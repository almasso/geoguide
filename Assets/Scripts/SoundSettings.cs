using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoundSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (IndexController.nameActualScene != "GameScene" && IndexController.namePreviousScene == "GameScene")
        {
            AudioListener audioSystem = GameObject.Find("Main Camera").GetComponent<AudioListener>();
            audioSystem.enabled = false;
            EventSystem eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
            eventSystem.enabled = false;
        }
        else {
            SoundManager.Instance.changeMusic(); 
        }
    }

}
