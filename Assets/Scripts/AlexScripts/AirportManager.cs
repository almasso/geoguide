using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

public class AirportManager : MonoBehaviour
{
    [SerializeField] private string objCountry;
    [SerializedDictionary("Gameobject del collider", "Nombre del pais")] public SerializedDictionary<GameObject, string> airports;
    [SerializeField] private GameObject plane;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = plane.GetComponent<PlayerController>();
    }

    public void Aterrizar(GameObject go)
    {
        if(playerController.isInputEnabled() && Input.GetKeyDown("space") && playerController.isMinimumSpeed())
        {
            if (airports[go] == objCountry) playerController.SecuenciaAterrizaje();
            else
            {
                Debug.Log("FALLO");
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
