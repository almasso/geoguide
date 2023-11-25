using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    Transform _myTransform;
    SpriteRenderer _mySprite;
    private float speed;
    public float x_min, x_max, y_min, y_max;
    public float fastest_speed;
    public float slowest_speed;

    private void Start()
    {
        _myTransform = transform;
        _mySprite = gameObject.GetComponent<SpriteRenderer>();
        speed = Random.Range(slowest_speed, fastest_speed);
        _myTransform.Rotate(Vector3.forward * Random.Range(-15.0f, 15.0f));
    }
    void Update()
    {
        if(_mySprite.flipX == true)
            _myTransform.position += _myTransform.right * (Time.deltaTime * speed);
        else
            _myTransform.position += -_myTransform.right * (Time.deltaTime * speed);

        if (_myTransform.position.x > x_max || _myTransform.position.x < x_min || _myTransform.position.y < y_min || _myTransform.position.y > y_max)
        {
            Destroy(gameObject);
        }
    }
}
