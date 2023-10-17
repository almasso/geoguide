using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainFace {

    Mesh mesh; //Mesh
    int resolution; //Resolución de la mesh
    //Vectores que definen el plano de la mesh
    Vector3 localUp;
    Vector3 axisA;
    Vector3 axisB;

    //Constructora de TerrainFace en la que se guardan los valores pasados y se calculan los otros dos vectores
    public TerrainFace(Mesh mesh, int resolution, Vector3 localUp) {
        this.mesh = mesh;
        this.resolution = resolution;
        this.localUp = localUp;

        axisA = new Vector3(localUp.y, localUp.z, localUp.x);
        axisB = Vector3.Cross(localUp, axisA);
    }


    public void ConstructMesh()
    {
        Vector3[] vertices = new Vector3[resolution * resolution];
        int[] triangles = new int[(resolution - 1) * (resolution - 1) * 6];
        int indexTriangles = 0;
        for (int i = 0; i < resolution; ++i)
        {
            for(int j = 0; j < resolution; ++j)
            {
                int k = i + j * resolution;
                Vector2 percent = new Vector2(i, j) / (resolution - 1);
                Vector3 pointOnUnitCube = localUp + (percent.x - 0.5f) * 2 * axisA + (percent.y - 0.5f) * 2 * axisB;
                vertices[k] = pointOnUnitCube;

                if(i != resolution - 1 && j != resolution - 1)
                {
                    triangles[indexTriangles] = k;
                    triangles[indexTriangles + 1] = k + resolution + 1;
                    triangles[indexTriangles + 2] = k + resolution;
                    triangles[indexTriangles + 3] = k;
                    triangles[indexTriangles + 4] = k + resolution;
                    triangles[indexTriangles + 5] = k + resolution + 1;
                    indexTriangles += 6;
                }
            }
        }
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
   
}
