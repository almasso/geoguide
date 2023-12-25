using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] Slider _volumeSlider;
    //public void Awake()
    //{
    //    DontDestroyOnLoad(this);
    //}
    public void Start()
    {
        _volumeSlider.value = IndexController._volume;
    }
    public void SetVolume (float volume)
    {
        AudioListener.volume = volume;
        IndexController._volume = volume;
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
