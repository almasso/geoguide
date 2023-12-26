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
        planeEngineSource.clip = planeFlying;

    }
 
    [SerializeField] AudioSource musicSource = null;
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

    public void changeMusic()
    {
        if (IndexController._audioActual != musicSource)
        {
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "GameScene" || UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "IntroductoryLevels")
            {
                musicSource.clip = backgroundGame;
                planeEngineSource.Play();
                planeEngineSource.volume = 0.33f;
            }
            else { musicSource.clip = backgroundMenu; planeEngineSource.Stop(); }
            musicSource.Play();
            IndexController._audioActual = musicSource;

        }
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
        SFXSource.PlayOneShot(clip);
    }

}
