using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{
    public GameObject ship;
    private SpriteRenderer ship_sprite;

    public int ship_count = 0;
    public int ship_limit = 3;
    public int ships_per_frame = 1;
    public float fastest_speed = 0.40f;
    public float slowest_speed = 0.1f;

    public float y_max, y_min;
    public float x_max, x_min;

    void Start()
    {
        ship_sprite = ship.GetComponent<SpriteRenderer>();
        InitialPopulation();
    }

    void Update()
    {
        MaintainPopulation();
    }

    void InitialPopulation()
    {
        for (int i = 0; i < ship_limit; i++)
        {
            Vector3 position = GetRandomPosition();
            AddShip(position);
        }
    }

    void MaintainPopulation()
    {
        if (ship_count < ship_limit)
        {
            for (int i = 0; i < ships_per_frame; i++)
            {
                Vector3 position = GetRandomPosition();
                AddShip(position);
            }
        }
    }

    Vector3 GetRandomPosition()
    {
        float aux = (Random.Range(-1,2));
        float posX;
        if (aux <= 0) { posX = x_min; ship_sprite.flipX = true; }
        else { posX = x_max; ship_sprite.flipX = false; }
        Vector3 position = new Vector3(posX, Random.Range(y_min, y_max), -3);
        return position;
    }

    void AddShip(Vector3 position)
    {
        ++ship_count;
        GameObject aux = Instantiate(ship, position, Quaternion.identity);
        Plane ship_script = aux.GetComponent<Plane>();
        ship_script.ship_spawner = this;
        ship_script.speed = Random.Range(slowest_speed, fastest_speed);
        ship_script.transform.Rotate(Vector3.forward * Random.Range(-45.0f, 45.0f));
        ship_script.transform.position = position;

    }
}
