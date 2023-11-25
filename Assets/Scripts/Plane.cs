using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public PlaneSpawner ship_spawner;

    public float speed;
    public float x_min, x_max, y_min, y_max;
    Vector2 dir;

    private void Start()
    {
        
    }
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position += transform.right * (Time.deltaTime * speed);
        if (transform.position.x > x_max || transform.position.x < x_min || transform.position.y < y_min || transform.position.y > y_max)
        {
            RemoveShip();
        }
    }
    void RemoveShip()
    {
        Destroy(gameObject);
        ship_spawner.ship_count -= 1;
    }
}
