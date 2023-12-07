using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

public class AirportManager : MonoBehaviour
{
    [SerializedDictionary("Gameobject del collider", "Nombre del pais")] public SerializedDictionary<GameObject, string> airports;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Aterrizar(GameObject go)
    {
        if(Input.GetKeyDown("space"))
        {
            Debug.Log($"Aterrizado en {airports[go]}");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
