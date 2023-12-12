using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneTrail : MonoBehaviour
{

    [SerializeField] private GameObject trailHolder;
    [SerializeField] private Material trailMaterial;
    [SerializeField] private Color trailCol = Color.white;
    [SerializeField] private TrailRenderer[] trails;
    [SerializeField] private GameObject player;

    [SerializeField] private float alphaMin = 0;
    [SerializeField] private float alphaMax = 0.5f;

    void Awake()
    {
        trailHolder.SetActive(false);
    }

    void Start()
    {
        trailHolder.gameObject.SetActive(true);

        for (int i = 0; i < trails.Length; i++)
        {
            trails[i].material = new Material(trailMaterial);
        }
    }

    void Update()
    {
        float alpha = Mathf.Lerp(alphaMin, alphaMax, player.GetComponent<PlayerController>().GetCurrentSpeed()); //Cambiamos la transparencia de las estelas dependiendo de la velocidad del avión.

        for (int i = 0; i < trails.Length; i++)
        {
            trails[i].sharedMaterial.color = new Color(trailCol.r, trailCol.g, trailCol.b, alpha);
        }

    }
}
