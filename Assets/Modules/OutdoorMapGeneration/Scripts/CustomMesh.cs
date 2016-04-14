using UnityEngine;
using System.Collections;

public class CustomMesh {

	//mesh boundary dimensions in 2d (x,y)
    private int 		meshDimensionX;
	private int 		meshDimensionY;

	//mesh data - holders for triangles, vertices, UVs
    private int[] 		arrayTriangles;
    private Vector3[] 	arrayVertices;
    private Vector2[] 	arrayUVs;

    //detail count (triangles and vertices count)
    private int 		trianglesCount;
	private int 		verticesCount;
    private int 		uvCount;


    private Mesh 		elementaryMesh;



    //default constructor
    public CustomMesh() {
        trianglesCount = 0;
		verticesCount = 0;
        uvCount = 0;
    }
	
	//constructor with boundaries of plane
	public CustomMesh(int meshDimensionX, int meshDimensionY) : base() {
        this.meshDimensionX = meshDimensionX;
		this.meshDimensionY = meshDimensionY;
		
        arrayVertices = new Vector3[(meshDimensionX * meshDimensionY)];
        int arrayTrianglesCount = ((meshDimensionX - 1) * (meshDimensionY - 1)) * 6;
        arrayTriangles = new int[arrayTrianglesCount];
        arrayUVs = new Vector2[(meshDimensionX * meshDimensionY)];
    }
	
	
	
	public Mesh InitializeMesh() {
        elementaryMesh = new Mesh();
        elementaryMesh.vertices = arrayVertices;
        elementaryMesh.triangles = arrayTriangles;
        elementaryMesh.uv = arrayUVs;
		// elementaryMesh.RecalculateBounds();
        elementaryMesh.RecalculateNormals();
		
        return elementaryMesh;
    }
	
	public Mesh UpdateMesh(Vector3[] vertices, int[] triangles, Vector2[] uvs) {
        elementaryMesh.vertices = vertices;
        elementaryMesh.triangles = triangles;
        elementaryMesh.uv = uvs;
        elementaryMesh.RecalculateBounds();
        elementaryMesh.RecalculateNormals();
		
        return elementaryMesh;
	}
	
	
	//adding single triangle to mesh
	public Vector3 addTriangle(int verticeA, int verticeB, int verticeC) {
        arrayTriangles[trianglesCount] = verticeA;
		arrayTriangles[trianglesCount+1] = verticeB;
		arrayTriangles[trianglesCount+2] = verticeC;
        trianglesCount += 3;

        return new Vector3(verticeA, verticeB, verticeC);
    }
	
	//adding single vertice to a mesh
	public Vector3 addVertice(Vector3 vertice) {
        arrayVertices[verticesCount].x = vertice.x;
		arrayVertices[verticesCount].y = vertice.y;
		arrayVertices[verticesCount].z = vertice.z;
        ++verticesCount;

        return arrayVertices[(verticesCount-1)];
    }
	
	//adding single vertice to a mesh
	public Vector3 addVertice(int x, float height, int y) {
        arrayVertices[verticesCount].x = x;
        arrayVertices[verticesCount].y = height;
        arrayVertices[verticesCount].z = y;
        ++verticesCount;

        return arrayVertices[(verticesCount-1)];
    } 
	
	//adding a single UV to mesh
	public Vector2 addUV(float x, float y) {
        arrayUVs[uvCount].x = x;
		arrayUVs[uvCount].y = y;
        ++uvCount;

        return arrayUVs[(uvCount-1)];
    }
	
	
	
	public int GetVerticesCount() {
        return verticesCount;
    }
	
	public int GetTrianglesCount() {
        return trianglesCount;
    }
	
	public Mesh GetElementaryMesh() {
        return elementaryMesh;
    }
	
	
}
