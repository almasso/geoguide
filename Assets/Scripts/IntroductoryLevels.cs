using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerController;

public class IntroductoryLevels : MonoBehaviour
{
    private List<SpeechBubbleController.Frases> listaDeMensajes = new List<SpeechBubbleController.Frases>();
    [SerializeField] private GameObject _walkieGO;
    private WalkieController _walkieController;
    private bool active;
    private float timer = 16f;
    public int mensajeActual = 0;

    // Start is called before the first frame update
    void Start()
    {
        _walkieController = _walkieGO.GetComponent<WalkieController>();
        listaDeMensajes.Add(SpeechBubbleController.Frases.CONTROLES);
        listaDeMensajes.Add(SpeechBubbleController.Frases.VELOCIDAD);
        listaDeMensajes.Add(SpeechBubbleController.Frases.ATERRIZAR);
        listaDeMensajes.Add(SpeechBubbleController.Frases.OBJETIVO);
        listaDeMensajes.Add(SpeechBubbleController.Frases.PISTAS);
        listaDeMensajes.Add(SpeechBubbleController.Frases.READY);
        active = false;
    }
   
   
    public void actiavteIntro()
    {
        active = true;
    }
    

    private void Update()
    {
        if (active)
        {
            timer += Time.deltaTime;
            if (timer >= 11f)
            {
                if (mensajeActual < listaDeMensajes.Count)
                {
                    SpeechBubbleController.setShowString(listaDeMensajes[mensajeActual]);
                    _walkieController.showWalkie();
                    ++mensajeActual;
                    timer = 0;
                }
                else { active = false; UI_Manager.Instance.ActivateAirportsIntroductory(); }
            }
        }
    }
}
