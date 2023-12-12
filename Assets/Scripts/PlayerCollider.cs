using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("CHOCO");
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (other.gameObject.tag == "Country" && Input.GetKeyDown("space"))
        {
            Debug.Log("CHOCO BIEN");
            GameManager.Instance.checkCountry(other.gameObject.name);
        }
    }

}
