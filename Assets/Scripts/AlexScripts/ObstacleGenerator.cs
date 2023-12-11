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
    private WalkieController _walkieController;
    private AirportManager _airportManager;
    private List<GameObject> _airportGOs;
    private List<string> _imprevistosNombres;

    private float _elapsedTime;
    private int _randomCountry;
    private float _randomTime;
    private int _randomImprevisto;

    private Tuple<string, string> _lastObstacle;

    // Start is called before the first frame update
    void Start()
    {
        _walkieController = _walkieGO.GetComponent<WalkieController>();
        _airportManager = _airportManGO.GetComponent<AirportManager>();
        _elapsedTime = 0.0f;
        _airportGOs = new List<GameObject>(_airportManager.airports.Keys);
        _randomTime = UnityEngine.Random.Range(10f, 20f);
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
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= _randomTime)
        {
            _randomCountry = UnityEngine.Random.Range(0, _airportGOs.Count);
            _randomImprevisto = UnityEngine.Random.Range(0, _imprevistosNombres.Count);
            imprevistos[_imprevistosNombres[_randomImprevisto]] = _airportManager.airports[_airportGOs[_randomCountry]];
            _lastObstacle = new Tuple<string, string>(_imprevistosNombres[_randomImprevisto], imprevistos[_imprevistosNombres[_randomImprevisto]]);
            _walkieController.showWalkie();
            _randomTime = UnityEngine.Random.Range(10f, 20f);
            _elapsedTime = 0.0f;
        }
    }
}
