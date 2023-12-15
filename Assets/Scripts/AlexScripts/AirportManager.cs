using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

public class AirportManager : MonoBehaviour
{
    [SerializedDictionary("Gameobject del collider", "Nombre del pais")] public SerializedDictionary<GameObject, string> airports;
    [SerializeField] private GameObject plane;
    private PlayerController playerController;
    private float timeInBetween = 5.0f;
    private float _elapsedTime = 0;
    private bool active = false;
    private bool canLand = true;
    // Start is called before the first frame update
    void Start()
    {
        playerController = plane.GetComponent<PlayerController>();
        canLand = true;
    }

    public void Aterrizar(GameObject go)
    {
        if(playerController.isInputEnabled() && Input.GetKeyDown("space") && playerController.isMinimumSpeed())
        {
            if (canLand)
            {
                active = true;
                if (airports[go] == GameSceneInfo.getObjectiveCountry()) playerController.SecuenciaAterrizaje();
                else
                {
                    GameManager.Instance.WrongCountry();
                }
                canLand = false;
            }
        }
    }

    public void Update()
    {
        if (active)
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= timeInBetween)
            {
                active = false;
                canLand = true;
                _elapsedTime = 0.0f;
            }

        }
    }
}
