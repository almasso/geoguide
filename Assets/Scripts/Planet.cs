using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Sacado del v�deo de Sebastian Lague acerca de la generaci�n procedural de planetas (https://youtu.be/QN39W020LqU?si=bPH1h8OAmpn7sDmF)

//Nuestra clase Planet va a crear los planetas como un cubo con 6 meshes, cada una apuntando en una direcci�n distinta. Posteriormente, usando matem�ticas,
//haremos que cada uno de esos meshes se curve y se forme una esfera (haciendo que los v�rtices est�n todos a la misma distancia del centro del cubo).
//A mayor resoluci�n tengamos en nuestros TerrainFaces, m�s continua aparecer� la superficie una vez se curve.
public class Planet : MonoBehaviour {

    [SerializeField] [Range(2,256)] int resolution = 10;
    [SerializeField][Range(0, 1)] float roundnessPercent = 0;

    [SerializeField, HideInInspector] MeshFilter[] meshFilters;
    TerrainFace[] faces;

    private void OnValidate() {
        Inicializar();
        GenerarMesh();
    }
    Vector3[] direcciones = { Vector3.up, Vector3.down, Vector3.forward, Vector3.back, Vector3.left, Vector3.right };

    void Inicializar() {
        if(meshFilters == null || meshFilters.Length == 0) meshFilters = new MeshFilter[6];
        faces = new TerrainFace[6];

        for(int i = 0; i < meshFilters.Length; i++) {
            if (meshFilters[i] == null) {
                GameObject meshObject = new GameObject("mesh");
                meshObject.transform.parent = transform;

                meshObject.AddComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Standard"));
                meshFilters[i] = meshObject.AddComponent<MeshFilter>();
                meshFilters[i].sharedMesh = new Mesh();
            }
            faces[i] = new TerrainFace(meshFilters[i].sharedMesh, resolution, direcciones[i], roundnessPercent);
        }
    }

    void GenerarMesh() {
        foreach(TerrainFace t in faces) {
            t.ConstruirMesh();
        }
    }
}
