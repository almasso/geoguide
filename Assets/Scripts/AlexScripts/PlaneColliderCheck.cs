using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneColliderCheck : MonoBehaviour
{
    [SerializeField] private GameObject _apManGO;
    private AirportManager _apMan;
    // Start is called before the first frame update

    private void Start()
    {
        _apMan = _apManGO.GetComponent<AirportManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        _apMan.Aterrizar(other.gameObject);
    }
}
