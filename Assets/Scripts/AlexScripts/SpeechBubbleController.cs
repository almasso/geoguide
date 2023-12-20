using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static PlayerController;
using UnityEditor.Experimental.GraphView;

public class SpeechBubbleController : MonoBehaviour
{
    public enum Frases {RADAR_DETECCION = 0, OBSTACLE_END = 1, GADGET_BROKEN = 2, COUNTRY_FAILED = 3, MISSION_FAILED = 4, CONTROLES = 5, BRUJULA = 6, VELOCIDAD = 7, MINIMAPA = 8, OBJETIVO = 9, PISTAS = 10, ATERRIZAR_1 =11, ATERRIZAR_2 = 12}; 
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
        foreach(char letter in sentence.ToCharArray())
        {
            _textMesh.text += letter;
            yield return new WaitForSeconds(_showSpeed);
        }
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
                case Frases.CONTROLES: sentence = "Podrás moverte hacia los lados pulsando A y D. También podrás subir (S) y bajar (W) el avión."; break; 
                case Frases.BRUJULA: sentence = "Para poder orientarte mejor, tendrás a la izquierda una brújula!"; break; 
                case Frases.VELOCIDAD: sentence = "Podrás cambiar de velocidad con los botones 1(más lenta), 2 y 3 (más rápida)."; break; 
                case Frases.ATERRIZAR_1: sentence = "Recuerda que solo podrán aterrizar en un aeropuerto mientras estés con la velocidad 1."; break; 
                case Frases.ATERRIZAR_2: sentence = "Cuando pases por por aeropuerto podrás aterrizar presionando el tecla de ESPACIO"; break; 
                case Frases.MINIMAPA: sentence = "Para situar mejor los paises y tu posición en el mundo, a la derecha tendrás un mini mapa!"; break; 
                case Frases.OBJETIVO: sentence = "Arriba saldrá en todo momento el país al que quiere ir tu cliente! Llevales correctamente hijo!"; break; 
                case Frases.PISTAS: sentence = "No te preocupes si te equivocas, a la derecha te iré dando pistas por si fallas y, a las malas, te guiaré al país!"; break; 
            }
            _isPlaying = true;
            _img.enabled = true;
            _textMesh.enabled = true;
            StartCoroutine(ShowBubbleText());
        }
        else if(!_walkieController.isCompletelyShown())
        {
            _img.enabled = false;
            _textMesh.enabled = false;
            _textMesh.text = string.Empty;
            _isPlaying = false;
        }
    }
}
