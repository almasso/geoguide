using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

public class AirportManager : MonoBehaviour
{
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
            if (airports[go] == GameSceneInfo.getObjectiveCountry()) { 
                if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "IntroductoryLevels")
                {
                    GameManager.Instance.updateIntroCountry(GameSceneInfo.getObjectiveCountry());
                }
                else playerController.SecuenciaAterrizaje(); 
            }
            else
            {
                Debug.Log("FALLO");
            }
        }
    }

    //actualCountryObject.GetComponent<MeshRenderer>().material.color = Color.red;
    //        Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAA");
    //        if (actualCountry == _game.myIntroLevelList.IntroLevel[_game.introIndex].Country1) actualCountry = _game.myIntroLevelList.IntroLevel[_game.introIndex].Country2;
    //        else if (actualCountry == _game.myIntroLevelList.IntroLevel[_game.introIndex].Country2) actualCountry = _game.myIntroLevelList.IntroLevel[_game.introIndex].Country3;
    //        else Debug.Log("FINISH MANGERRR");

    //        updateCountryObject(actualCountry);
    //changeCountryColor(actualCountryObject);

    //_game.updateIntroObjective();
}
