using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clue : MonoBehaviour
{
    private Transform _myTransform;
    private bool move = false;
    private int dir = -1;
    private float maxIzq;
    private float maxDer;  

    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
        maxIzq = _myTransform.position.x;
        maxDer = _myTransform.position.x + 500;
    }

    public void MoveClue(int _dir)
    {
        dir = _dir;
        move = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            if ((dir == -1 &&_myTransform.position.x <= maxIzq) || (dir == 1 && _myTransform.position.x >= maxDer)) { 
                move = false;
            }
            else _myTransform.Translate(new Vector3(dir*3, 0, 0));
        }
    }
}
