using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandWave : MonoBehaviour
{
    [SerializeField]
    private GameObject _Canvas;
    [SerializeField]
    private GameObject _prefab;
    [SerializeField]
    private Transform _spawnTransform;
    private float _elapsedTime = 0; 
    [SerializeField]
    private float _lifeTime;
    private bool alive = false;
    GameObject aux;

    void Start()
    {
        InstanciateHand();

    }
    public void InstanciateHand()
    {
        aux = Instantiate(_prefab, new Vector3(_spawnTransform.position.x, _spawnTransform.position.y, _spawnTransform.position.z), Quaternion.identity) as GameObject;
        aux.transform.SetParent(_Canvas.transform, false);
        aux.transform.position = new Vector3(_spawnTransform.position.x, _spawnTransform.position.y, _spawnTransform.position.z);
        alive = true;
    }
     void Update()
    {
        if (alive)
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= _lifeTime)
            {
                Destroy(aux);
                _elapsedTime = 0;
                alive = false;
                SoundManager.Instance.PlaySFX(SoundManager.Instance.clientSound);
            }
        }
    }
}
