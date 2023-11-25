using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region parameters
    private bool timerunning = true;
    /// <summary>
    /// Desired duration for match.
    /// </summary>
    [SerializeField]
    private float _matchDuration = 10.0f;
    #endregion
    #region references
    /// <summary>
    /// Unique GameManager instance (Singleton Pattern).
    /// </summary>
    static private GameManager _instance;
    /// <summary>
    /// Public accesor for GameManager instance.
    /// </summary>
    static public GameManager Instance
    {
        get
        {
            return _instance;
        }
    }
    /// <summary>
    /// Reference to UI Manager.
    /// </summary>
    private UI_Manager _myUIManager;
    //private CameraMovementController _myCamera;
    /// <summary>
    /// Reference to player.
    /// </summary>
    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private GameObject _IAplayer;
    /// <summary>
    /// Reference to UI Manager.
    /// </summary>
    [SerializeField]
    private GameObject _UIManager;
    [SerializeField]
    private GameObject _Camera;
    #endregion

    #region properties
    /// <summary>
    /// List containing all live enemies.
    /// </summary>
   // private List<EnemyController> _listOfEnemies;
    /// <summary>
    /// Remaining time to finish match.
    /// </summary>
    private float _timeLeft;
    /// <summary>
    /// Integer version of remaining time to finish match, dispayed on UI.
    /// </summary>
    private int _displayTimeLeft;
    #endregion
    #region methods
    /// <summary>
    /// Initializes GameManager instance and list of enemies.
    /// </summary>
    private void Awake()
    {
        _instance = this;
    }

    /// <summary>
    /// Called on player's victory.
    /// Sets UI Manager accordingly and deactivates player.
    /// </summary>
    private void OnPlayerVictory()
    {
        _player.SetActive(false);
        _IAplayer.SetActive(false);
    }

    /// <summary>
    /// Called on player's defeat.
    /// Set UI Manager accordingly, deactivates enemies and player.
    /// </summary>
    public void OnPlayerDefeat()
    {
        _player.SetActive(false);
        _IAplayer.SetActive(false);
    }

    /// <summary>
    /// Initializes match.
    /// Activates player and enemies and performs initialization stuff.
    /// </summary>
    public void StartMatch()
    {
        enabled = true;
        timerunning = true;
        _timeLeft = _matchDuration;
        _player.SetActive(true);
    }

    public void WatchMatch()
    {
        enabled = true;
        timerunning = true;
        _timeLeft = _matchDuration;
        _IAplayer.SetActive(true);
        
    }

    /// <summary>
    /// Reloads scene after match.
    /// </summary>
    public void Continue()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Allows to quit game.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
    #endregion

    /// <summary>
    /// Finds UI Manager and Player.
    /// Deactivates player and GameManager.
    /// </summary>
    void Start()
    {
        _myUIManager = _UIManager.GetComponent<UI_Manager>();
        //_myCamera = _Camera.GetComponent<CameraMovementController>();
        timerunning = false;
        _player.SetActive(false);
        _IAplayer.SetActive(false);
        _myUIManager.SetMainMenu(true);
        enabled = false;
    }

    /// <summary>
    /// Checks victory and defeat conditions, calling required methods.
    /// Updates time on UI Manager.
    /// </summary>
    void Update()
    {
        if (timerunning == true)
        {
            _timeLeft -= Time.deltaTime;
            _displayTimeLeft = (int)_timeLeft;
            if (_timeLeft <= 0)
            {
                OnPlayerDefeat();
                timerunning = false;
            }
        }
    }
}



