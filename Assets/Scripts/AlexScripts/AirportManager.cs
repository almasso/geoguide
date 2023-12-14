using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

public class AirportManager : MonoBehaviour
{
    [SerializedDictionary("Gameobject del collider", "Nombre del pais")] public SerializedDictionary<GameObject, string> airports;
    [SerializeField] private GameObject plane;
    [SerializeField] private GameObject _walkieGO;
    private WalkieController _walkieController;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = plane.GetComponent<PlayerController>();
        _walkieController = _walkieGO.GetComponent<WalkieController>();
    }

    public void Aterrizar(GameObject go)
    {
        if(playerController.isInputEnabled() && Input.GetKeyDown("space") && playerController.isMinimumSpeed())
        {
            if (airports[go] == GameSceneInfo.getObjectiveCountry()) playerController.SecuenciaAterrizaje();
            else
            {
                SpeechBubbleController.setShowString(SpeechBubbleController.Frases.COUNTRY_FAILED);
                _walkieController.showWalkie();
            }
        }
    }
}
