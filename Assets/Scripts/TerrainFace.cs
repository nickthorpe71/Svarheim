using UnityEngine;

public class TerrainFace
{
    Mesh mesh;
    int resolution; // total number of vertices along a single edge
    Vector3 localUp;
    Vector3 axisA;
    Vector3 axisB;

    public TerrainFace(Mesh mesh, int resolution, Vector3 localUp)
    {
        this.mesh = mesh;
        this.resolution = resolution;
        this.localUp = localUp;

        axisA = new Vector3(localUp.y, localUp.z, localUp.x);
        axisA = Vector3.Cross(localUp, axisA);
    }

    public void ConstructMesh()
    {
        // there are 6 meshes (aka terrain faces) per sphere (aka planet)

        // since resolution is the number of vertices along the edge of a mesh
        // the total vertices in a mesh is resolution ^ 2
        Vector3[] vertices = new Vector3[resolution * resolution];

        // to calculate the total number of triangles we do
        // (resolution -1) ^ 2 to get the total number of squares 
        // multiplied by 2 triangles per square
        // multiplied by 3 vertices per triangle
        int[] triangles = new int[(resolution - 1) * (resolution - 1) * 2 * 3];


    }
}
