using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static PlayerController;

public class SpeechBubbleController : MonoBehaviour
{
    public enum Frases {RADAR_DETECCION = 0, OBSTACLE_END = 1, GADGET_BROKEN = 2, COUNTRY_FAILED = 3, MISSION_FAILED = 4, CONTROLES = 5, VELOCIDAD = 6, ATERRIZAR = 7, OBJETIVO  = 8, PISTAS = 9, READY = 10}; 
    [SerializeField] GameObject _obstacleGenGO;
    [SerializeField] private float _showSpeed = 0.01f;
    private string sentence;
    private WalkieController _walkieController;
    private RawImage _img;
    private TextMeshProUGUI _textMesh;
    private ObstacleGenerator _obstacleGenerator;
    bool _isPlaying = false;
    static private int sentenceToShow = 0;
    static private string brokenGadget = "";
    // Start is called before the first frame update
    void Start()
    {
        _walkieController = this.GetComponentInParent<WalkieController>();
        _img = this.GetComponent<RawImage>();
        _textMesh = this.GetComponentInChildren<TextMeshProUGUI>();
        _obstacleGenerator = _obstacleGenGO.GetComponent<ObstacleGenerator>();
        _img.enabled = false;
        _textMesh.enabled = false;
    }

    private IEnumerator ShowBubbleText()
    {

        float newSpeed = _showSpeed * (1 / Time.deltaTime);
        foreach(char letter in sentence.ToCharArray())
        {
            _textMesh.text += letter;
            yield return new WaitForSeconds(0.02191253f);
        }

        yield return new WaitForSeconds(3.0f);

        _walkieController.hideWalkie();
    }

    static public void setShowString(Frases f)
    {
        sentenceToShow = (int)f;
    }

    static public void setBrokenGadgetString(string s)
    {
        brokenGadget = s;
    }

    // Update is called once per frame
    void Update()
    {
        if (_walkieController.isCompletelyShown() && !_isPlaying)
        {
            switch ((Frases)sentenceToShow)
            {
                case Frases.RADAR_DETECCION: sentence = $"¡Ten mucho cuidado! ¡El radar ha detectado {_obstacleGenerator.getLastObstacle().Item1} en {_obstacleGenerator.getLastObstacle().Item2}! ¡Evita pasar por ese país a toda costa!"; break;
                case Frases.OBSTACLE_END: sentence = $"¡Parece ser que la {_obstacleGenerator.getLastObstacle().Item1} en {_obstacleGenerator.getLastObstacle().Item2} ha terminado!"; break;
                case Frases.GADGET_BROKEN: sentence = $"¡Parece ser que tu {brokenGadget} ha dejado de funcionar! Debería arreglarse en unos segundos. ¡Ten más cuidado a la próxima!"; break;
                case Frases.COUNTRY_FAILED: sentence = "¡Ups! Parece que ese país no es tu objetivo"; break;
                case Frases.MISSION_FAILED: sentence = "¡No te preocupes, estás aprendiendo! Te he marcado tu objetivo. ¡Seguro que te irá mejor si lo vuelves a intentar!"; break;
                case Frases.CONTROLES: sentence = "Podrás moverte hacia los lados pulsando (A) y (D). También podrás subir (S) y bajar (W) el avión."; break; 
                case Frases.VELOCIDAD: sentence = "Podrás cambiar de velocidad con los botones 1(más lenta), 2 y 3 (más rápida)."; break; 
                case Frases.ATERRIZAR: sentence = "Recuerda que solo podrás aterrizar (tecla ESPACIO) en un aeropuerto mientras estés en la velocidad 1."; break; 
                case Frases.OBJETIVO: sentence = "Arriba saldrá en todo momento el país al que quiere ir tu cliente ¡Llévales correctamente hijo!"; break; 
                case Frases.PISTAS: sentence = "No te preocupes si te equivocas, a la derecha te iré dando pistas por si fallas y, a las malas, te guiaré al país."; break; 
                case Frases.READY: sentence = "¡Venga! Vamos a poner en marcha lo aprendido. ¡A Europa!"; break; 
            }
            _isPlaying = true;
            _img.enabled = true;
            _textMesh.enabled = true;
            StartCoroutine(ShowBubbleText());
        }
        else if (!_walkieController.isCompletelyShown())
        {
            _img.enabled = false;
            _textMesh.enabled = false;
            _textMesh.text = string.Empty;
            _isPlaying = false;
        }
    }
}
