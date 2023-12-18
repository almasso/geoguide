using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static private SoundManager _instance;
    static public SoundManager Instance
    {
        get
        {
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }

    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource planeEngineSource;

    [Header("---------- Audio Source ----------")]
    public AudioClip backgroundMenu;
    public AudioClip backgroundGame;
    public AudioClip click;
    public AudioClip cardFlip;
    public AudioClip clientSound;
    public AudioClip staticSound;
    public AudioClip youWon;
    public AudioClip youFailed;
    public AudioClip clueSound;
    public AudioClip walkieTalkie;
    public AudioClip planeFlying;
    public AudioClip planeLanding;
    public AudioClip successSound;
    public AudioClip failSound;

    private void Start()
    {
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "GameScene" || UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "IntroductoryLevels")
        {
            musicSource.clip = backgroundGame;
            musicSource.Play();

            planeEngineSource.clip = planeFlying;
            planeEngineSource.Play();
            planeEngineSource.volume = 0.33f;
        }
        else
        {
            musicSource.clip = backgroundMenu;
            musicSource.Play();
        }
    }

    public void ChangePlaneSpeedSound(int speed)
    {
        planeEngineSource.volume = 0.33f * speed;
    }

    public void PlaySFX(AudioClip clip)
    {
        //SFXSource.volume = 0.5f;
        SFXSource.PlayOneShot(clip);
    }

}
