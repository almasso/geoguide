using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpeechBubbleController : MonoBehaviour
{
    [SerializeField] GameObject _obstacleGenGO;
    [SerializeField] private float _showSpeed = 0.01f;
    private string sentence;
    private WalkieController _walkieController;
    private RawImage _img;
    private TextMeshProUGUI _textMesh;
    private ObstacleGenerator _obstacleGenerator;
    bool _isPlaying = false;
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

    // Update is called once per frame
    void Update()
    {
        if (_walkieController.isCompletelyShown() && !_isPlaying)
        {
            sentence = $"¡Ten mucho cuidado! ¡El radar ha detectado {_obstacleGenerator.getLastObstacle().Item1} en {_obstacleGenerator.getLastObstacle().Item2}! ¡Evita pasar por ese país a toda costa!";
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
