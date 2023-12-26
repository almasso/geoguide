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
    private float timeInBetween = 5.0f;
    private float _elapsedTime = 0;
    private bool active = false;
    private bool canLand = true;
    // Start is called before the first frame update
    void Start()
    {
        playerController = plane.GetComponent<PlayerController>();
        canLand = true;
        _walkieController = _walkieGO.GetComponent<WalkieController>();
    }

    public void Aterrizar(GameObject go)
    {
        if(playerController.isInputEnabled() && Input.GetKeyDown("space") && playerController.isMinimumSpeed())
        {
            if (canLand)
            {
                active = true;
                Debug.Log("Objetivo: " + GameSceneInfo.getObjectiveCountry());
                Debug.Log("Donde estoy: " + airports[go]);
                if (airports[go] == GameSceneInfo.getObjectiveCountry())
                {
                    if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "IntroductoryLevels")
                    {
                        GameManager.Instance.updateIntroCountry(GameSceneInfo.getObjectiveCountry());
                    }
                    else if(GameManager.Instance.GetTries() <= 3) playerController.SecuenciaAterrizaje();
                    else if(GameManager.Instance.GetTries() > 3)
                    {
                        GameManager.Instance.fail();
                    }
                }
                else if(GameManager.Instance.GetTries() < 3)
                {
                    SpeechBubbleController.setShowString(SpeechBubbleController.Frases.COUNTRY_FAILED);
                    _walkieController.showWalkie();
                    GameManager.Instance.WrongCountry();
                }
                else
                {
                    SpeechBubbleController.setShowString(SpeechBubbleController.Frases.MISSION_FAILED);
                    _walkieController.showWalkie();
                    GameManager.Instance.updateCountryObject(GameSceneInfo.getObjectiveCountry());
                    GameManager.Instance.changeCountryColor(new Color32(0, 255, 0, 94));
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
