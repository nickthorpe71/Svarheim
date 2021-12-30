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

    // there are 6 meshes (aka terrain faces) per sphere (aka planet)
    public void ConstructMesh()
    {
        // since resolution is the number of vertices along the edge of a mesh
        // the total vertices in a mesh is resolution ^ 2
        Vector3[] vertices = new Vector3[resolution * resolution];

        // to calculate the total number of triangles we do
        // (resolution -1) ^ 2 to get the total number of squares 
        // multiplied by 2 triangles per square
        // multiplied by 3 vertices per triangle
        int[] triangles = new int[(resolution - 1) * (resolution - 1) * 2 * 3];
        int triIndex = 0;

        for (int y = 0; y < resolution; y++)
            for (int x = 0; x < resolution; x++)
            {
                int i = x + y * resolution;
                Vector2 percent = new Vector2(x, y) / (resolution - 1);
                Vector3 pointOnUnitCube = localUp + (percent.x - 0.5f) * 2 * axisA + (percent.y - 0.5f) * 2 * axisB;
                vertices[i] = pointOnUnitCube;

                if (x != resolution - 1 && y != resolution - 1)
                {
                    triangles[triIndex] = i;
                    triangles[triIndex + 1] = i + resolution + 1;
                    triangles[triIndex + 2] = i + resolution;

                    triangles[triIndex + 3] = i;
                    triangles[triIndex + 4] = i + 1;
                    triangles[triIndex + 5] = i + resolution + 1;

                    triIndex += 6;
                }
            }

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}
