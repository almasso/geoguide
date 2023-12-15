using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clue : MonoBehaviour
{
    private Transform _myTransform;
    private bool move = false;
    private int dir = -1;
    private int vel = 200;
    private float maxIzq;
    private float maxDer;  

    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
        maxIzq = _myTransform.position.x;
        maxDer = _myTransform.position.x + 500;
        _myTransform.position = new Vector3(maxDer, _myTransform.position.y, _myTransform.position.z);
    }

    public void MoveClue(int _dir)
    {
        dir = _dir;
        move = true;
        vel = 200;
    }
    public void HideClue()
    {
        dir = 1;
        vel = 2000;
        move = true;
    }

    void FixedUpdate()
    {
        if (move)
        {
            if ((dir == -1 &&_myTransform.position.x <= maxIzq) || (dir == 1 && _myTransform.position.x >= maxDer)) { 
                move = false;
            }
            else _myTransform.localPosition += (new Vector3(dir*vel, 0, 0)) * Time.fixedDeltaTime; 
        }
    }
}
