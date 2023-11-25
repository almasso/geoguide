using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{
    #region references
    [SerializeField]
    private GameObject _prefab;
    #endregion
    #region paramaters
    [SerializeField]
    private float _maxTimeInterval = 5.0f;
    [SerializeField]
    private float _minTimeInterval = 1.0f;
    #endregion
    #region properties
    private float _elapsedTime;
    private float _nextSpawnTime = 0;
    public float y_max, y_min;
    public float x_max, x_min;
    #endregion

    void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= _nextSpawnTime)
        {
            Instantiate(_prefab, GetRandomPosition(), Quaternion.identity);
            _nextSpawnTime = Random.Range(_minTimeInterval, _maxTimeInterval + 1);
            _elapsedTime = 0;
        }
    }
    Vector3 GetRandomPosition()
    {
        SpriteRenderer sprite = _prefab.GetComponent<SpriteRenderer>();
        float aux = (Random.Range(-1,2));
        float scale = Random.Range(0.01f, 0.03f);
        float posX;
        if (aux <= 0) {  posX = x_min; sprite.flipX = true; _prefab.transform.localScale = new Vector3(scale, scale, scale); }
        else {posX = x_max; sprite.flipX = false; _prefab.transform.localScale = new Vector3(scale, scale, scale); }
        Vector3 position = new Vector3(posX, Random.Range(y_min, y_max), -3);
        return position;
    }
}
