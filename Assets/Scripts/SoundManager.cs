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

    AudioSource musicSource = null;
    AudioSource SFXSource;
    AudioSource planeEngineSource;

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

    private void Awake()
    {
        if (Instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else if (this != Instance)
        {
            Destroy(this);
        }

        musicSource = gameObject.transform.GetChild(0).GetComponent<AudioSource>();
        SFXSource = gameObject.transform.GetChild(1).GetComponent<AudioSource>();
        planeEngineSource = gameObject.transform.GetChild(2).GetComponent<AudioSource>();

        planeEngineSource.clip = planeFlying;

    }

    public void changeMusic()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "GameScene" || UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "IntroductoryLevels")
        {
            musicSource.clip = backgroundGame;
            planeEngineSource.Play();
            planeEngineSource.volume = 0.33f;
        }
        else { musicSource.clip = backgroundMenu; planeEngineSource.Stop(); }
        musicSource.Play(); 
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SFXSource.PlayOneShot(click);
        }
    }

    public void ChangePlaneSpeedSound(int speed)
    {
        planeEngineSource.volume = 0.33f * speed;
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource = gameObject.transform.GetChild(1).GetComponent<AudioSource>();
        //Debug.Log(clip.name);
        //Debug.Log(SFXSource);
        SFXSource.PlayOneShot(clip);
    }

}
