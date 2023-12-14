using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUIController : MonoBehaviour
{
    // Start is called before the first frame update

    private RawImage _velImg;
    private PlayerController _playerController;
    [SerializeField] private GameObject _plane;
    [SerializeField] private Texture _minVelTex;
    [SerializeField] private Texture _medVelTex;
    [SerializeField] private Texture _maxVelTex;
    [SerializeField] private Texture _malfunctionVelTex;
    void Start()
    {
        _velImg = GetComponent<RawImage>();
        _playerController = _plane.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerController.isMinimumSpeed() && !_playerController.isMalfunctioning()) _velImg.texture = _minVelTex;
        else if (_playerController.isMinimumSpeed() && _playerController.isMalfunctioning()) _velImg.texture = _malfunctionVelTex;
        else if (_playerController.isMediumSpeed()) _velImg.texture = _medVelTex;
        else if (_playerController.isMaximumSpeed()) _velImg.texture = _maxVelTex;
    }
}
