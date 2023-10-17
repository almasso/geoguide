using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Sacado del vídeo de Sebastian Lague acerca de la generación procedural de planetas (https://youtu.be/QN39W020LqU?si=bPH1h8OAmpn7sDmF)

//Esta TerrainFace va a ser una de las 6 que compongan el cubo que va a ser nuestro planeta. Posteriormente, en el script "Planet" definiremos 6
//TerrainFaces, cada una con una orientación distinta, y es cuando las "curvaremos" para que en conjunto formen un cilindro en el que todos los triángulos
//de las caras en los Mesh que lo componen tengan el mismo tamaño.
public class TerrainFace {

    Mesh mesh; //Mesh que construimos para la cara
    int resolution; //Resolución de la mesh, es decir, el número de detalle (a más detalle, más triángulos se generan en la mesh)
    
    //Vectores que definen el plano de la mesh
    Vector3 localUp; //Este es el vector en el que la mesh está mirando
    //Estos dos vectores formarían el espacio vectorial de nuestro plano
    Vector3 vectorDirectorA;
    Vector3 vectorDirectorB;

    //Constructora de TerrainFace en la que se guardan los valores pasados y se calculan los otros dos vectores
    public TerrainFace(Mesh mesh, int resolution, Vector3 localUp) {
        this.mesh = mesh;
        this.resolution = resolution;
        this.localUp = localUp;

        vectorDirectorA = new Vector3(localUp.y, localUp.z, localUp.x); //Para generar el vectorDirectorA simplemente mezclamos las coordenadas de nuestro vector en el que mira la mesh
        vectorDirectorB = Vector3.Cross(localUp, vectorDirectorA); //Y para generar el otro vector, simplemente hacemos el producto vectorial entre los dos vectores de nuestro espacio vectorial (ya que tiene que ser perpendicular a ambos)
    }


    public void ConstruirMesh() {
        Vector3[] vertices = new Vector3[resolution * resolution]; //Generamos un vector de vértices de tamaño resolución^2, ya que la resolución es el número de vértices que vamos a tener a lo largo de uno de los ejes de la mesh
        int[] indicesTriangulos = new int[(resolution - 1) * (resolution - 1) * 6]; //Dado una mesh de tamaño r*r en resolución, tendremos en total (r-1)^2 cuadrados en la mesh (de una cuadrícula de 2*2 vértices, tendremos solo 1 cuadrado con sus 4 vértices).
        //Ahora dividimos esos cuadrados por su diagonal en 2 triángulos. Tendremos un total de (r-1)^2 * 2 triángulos en toda la malla. Como cada triángulo tiene 3 vértices, tendremos un total de (r-1)^2 * 2 * 3 índices para nuestros triángulos.
        int indiceTrianguloActual = 0;
        int k = 0;
        for (int i = 0; i < resolution; ++i) {
            for(int j = 0; j < resolution; ++j) {
                Vector2 percent = new Vector2(j, i) / (resolution - 1); //Este vector nos sirve para ver por qué por ciento van los bucles for en cada uno de los ejes.
                Vector3 puntoEnLaMesh = localUp + (percent.x - 0.5f) * 2 * vectorDirectorA + (percent.y - 0.5f) * 2 * vectorDirectorB; //Esto calcula el vector de posición de nuestro vértice en la mesh dado nuestro vector localUp, que empieza en el origen que nosotros establezcamos
                Vector3 puntoEnLaMeshEsferica = puntoEnLaMesh.normalized;
                vertices[k] = puntoEnLaMeshEsferica;

                if(i != resolution - 1 && j != resolution - 1) {
                    //Definimos los triángulos en la mesh en sentido horario excepto para la última coordenada de los ejes X e Y
                    indicesTriangulos[indiceTrianguloActual] = k;
                    indicesTriangulos[indiceTrianguloActual + 1] = k + resolution + 1;
                    indicesTriangulos[indiceTrianguloActual + 2] = k + resolution;
                    indicesTriangulos[indiceTrianguloActual + 3] = k;
                    indicesTriangulos[indiceTrianguloActual + 4] = k + 1;
                    indicesTriangulos[indiceTrianguloActual + 5] = k + resolution + 1;
                    indiceTrianguloActual += 6;
                }
                ++k;
            }
        }
        mesh.Clear(); //Limpiamos la data del mesh para cuando bajemos la resolución no tengamos triángulos inexistentes que apunten a vértices inexistentes, sino que lo vuelva a recalcular todo de nuevo
        mesh.vertices = vertices;
        mesh.triangles = indicesTriangulos;
        mesh.RecalculateNormals();
    }
   
}
