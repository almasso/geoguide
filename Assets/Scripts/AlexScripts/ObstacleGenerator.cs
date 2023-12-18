using AYellowpaper.SerializedCollections;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializedDictionary("Nombre (en minusculas) del evento", "Nombre del país al que afecta")] public SerializedDictionary<string, string> imprevistos;
    [SerializeField] private GameObject _walkieGO;
    [SerializeField] private GameObject _airportManGO;
    [SerializeField] private GameObject _plane;
    [SerializeField] private float _obstacleDuration;
    private WalkieController _walkieController;
    private AirportManager _airportManager;
    private PlaneColliderCheck _planeColliderCheck;
    private List<GameObject> _airportGOs;
    private List<string> _imprevistosNombres;

    private float _elapsedTime;
    private float _instantiatedElapsedTime;
    private int _randomCountry;
    private float _randomTime;
    private int _randomImprevisto;
    private bool instantiated = false;

    private Tuple<string, string> _lastObstacle;

    // Start is called before the first frame update
    void Start()
    {
        _walkieController = _walkieGO.GetComponent<WalkieController>();
        _airportManager = _airportManGO.GetComponent<AirportManager>();
        _planeColliderCheck = _plane.GetComponent<PlaneColliderCheck>();
        _elapsedTime = 0.0f;
        _airportGOs = new List<GameObject>(_airportManager.airports.Keys);
        _randomTime = UnityEngine.Random.Range(20f, 30f);
        imprevistos = new SerializedDictionary<string, string>
        {
            ["niebla"] = "",
            ["nieve"] = "",
            ["tormenta"] = ""

        };
        _imprevistosNombres = new List<string>(imprevistos.Keys);
    }

    public Tuple<string, string> getLastObstacle() { return _lastObstacle; }

    public bool checkForObstacle(GameObject go)
    {
        foreach(KeyValuePair<string, string> s in imprevistos)
        {
            if (s.Value == _airportManager.airports[go]) return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "GameScene" && IndexController._imprevisto)
        {
            if (!instantiated) _elapsedTime += Time.deltaTime;

            if (instantiated) _instantiatedElapsedTime += Time.deltaTime;

            if (_elapsedTime >= _randomTime)
            {
                _randomCountry = UnityEngine.Random.Range(0, _airportGOs.Count);
                while (_airportManager.airports[_airportGOs[_randomCountry]] == GameSceneInfo.getObjectiveCountry() || (_planeColliderCheck.getCurrentCountry() != null && _airportManager.airports[_airportGOs[_randomCountry]] == _airportManager.airports[_planeColliderCheck.getCurrentCountry()]) || checkForObstacle(_airportGOs[_randomCountry]))
                {
                    _randomCountry = UnityEngine.Random.Range(0, _airportGOs.Count);
                }
                _randomImprevisto = UnityEngine.Random.Range(0, _imprevistosNombres.Count);
                imprevistos[_imprevistosNombres[_randomImprevisto]] = _airportManager.airports[_airportGOs[_randomCountry]];
                _lastObstacle = new Tuple<string, string>(_imprevistosNombres[_randomImprevisto], imprevistos[_imprevistosNombres[_randomImprevisto]]);
                SpeechBubbleController.setShowString(SpeechBubbleController.Frases.RADAR_DETECCION);
                _walkieController.showWalkie();
                _randomTime = UnityEngine.Random.Range(20f, 30f);
                _elapsedTime = 0.0f;
                instantiated = true;
            }

            if (_instantiatedElapsedTime >= _obstacleDuration)
            {
                imprevistos[_imprevistosNombres[_randomImprevisto]] = "";
                instantiated = false;
                _instantiatedElapsedTime = 0.0f;
                SpeechBubbleController.setShowString(SpeechBubbleController.Frases.OBSTACLE_END);
                _walkieController.showWalkie();
            }
        }
    }
}
