using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Sacado del vídeo de Sebastian Lague acerca de la generación procedural de planetas (https://youtu.be/QN39W020LqU?si=bPH1h8OAmpn7sDmF)

//Nuestra clase Planet va a crear los planetas como un cubo con 6 meshes, cada una apuntando en una dirección distinta. Posteriormente, usando matemáticas,
//haremos que cada uno de esos meshes se curve y se forme una esfera (haciendo que los vértices estén todos a la misma distancia del centro del cubo).
//A mayor resolución tengamos en nuestros TerrainFaces, más continua aparecerá la superficie una vez se curve.
public class Planet : MonoBehaviour {

    [SerializeField] [Range(2,256)] int resolution = 10;

    [SerializeField, HideInInspector] MeshFilter[] meshFilters;
    TerrainFace[] faces;

    private void OnValidate() {
        Inicializar();
        GenerarMesh();
    }

    void Inicializar() {
        if(meshFilters == null || meshFilters.Length == 0) meshFilters = new MeshFilter[6];
        faces = new TerrainFace[6];
        Vector3[] direcciones = { Vector3.up, Vector3.down, Vector3.forward, Vector3.back, Vector3.left, Vector3.right };

        for(int i = 0; i < meshFilters.Length; i++) {
            if (meshFilters[i] == null) {
                GameObject meshObject = new GameObject("mesh");
                meshObject.transform.parent = transform;

                meshObject.AddComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Standard"));
                meshFilters[i] = meshObject.AddComponent<MeshFilter>();
                meshFilters[i].sharedMesh = new Mesh();
            }
            faces[i] = new TerrainFace(meshFilters[i].sharedMesh, resolution, direcciones[i]);
        }
    }

    void GenerarMesh() {
        foreach(TerrainFace t in faces) {
            t.ConstruirMesh();
        }
    }
}
