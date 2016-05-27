using UnityEngine;
using System.Collections.Generic;
using AssemblyCSharp;

namespace OroIndoorMapGeneratorModule
{

    public class MeshGenerator : MonoBehaviour {

        private Grid grid;
        private List<Vector3> vertices; //shouldnt it be List<Vertice>?
        private List<int> trianglesIndexes;


        public void generateMesh(bool[,] randomizedMap) {
            grid = new Grid(randomizedMap);
            vertices = new List<Vector3>();
            trianglesIndexes = new List<int>();

            for (int x = 0; x < grid.GetCells().GetLength(0); x++) {
                for (int y = 0; y < grid.GetCells().GetLength(1); y++) {
                    CreateTriangles(grid.GetCells()[x, y]);
                }
			}

            Mesh mapMesh = new Mesh();
            GetComponent<MeshFilter>().mesh = mapMesh;

            mapMesh.vertices = vertices.ToArray();
            mapMesh.triangles = trianglesIndexes.ToArray();
            mapMesh.RecalculateNormals();
			// mapMesh.RecalculateBounds();

        }
		
		private void CreateTriangles(Cell cell) {
            AssignVertices(cell.getVertices());
            MeshFromPoints(cell.getVertice(1), cell.getVertice(2), cell.getVertice(3), cell.getVertice(4));
        }
		
		private void AssignVertices(params Vertice[] verts) {
            //todo: change that, so that value is added on x, y variable initialize (1 + xVal * rowCountmax + yVal);
            for (int i = 0; i < verts.Length; ++i) {
				verts[i].SetVertexIndex(vertices.Count);
                vertices.Add(verts[i].GetPosition());
            }
        }
		
		private void MeshFromPoints(params Vertice[] verts) {
            CreateTriangle(verts[0], verts[1], verts[3]);
            CreateTriangle(verts[0], verts[3], verts[2]);
        }
		
		private void CreateTriangle(Vertice vA, Vertice vB, Vertice vC) {
            trianglesIndexes.Add(vA.GetVertexIndex());
			trianglesIndexes.Add(vB.GetVertexIndex());
			trianglesIndexes.Add(vC.GetVertexIndex());
        }
		
		
	// 	void OnDrawGizmos() {
    //         if (grid != null) {
    //             Debug.Log("notnull");
    //             for (int x = 0; x < grid.GetCells().GetLength(0); x++) {
	// 			for (int y = 0; y < grid.GetCells().GetLength(1); y++) {

	// 				Gizmos.color = (grid.GetCells()[x,y].getVertice(1).IsTraversable())?Color.white:Color.black;
	// 				Gizmos.DrawCube(grid.GetCells()[x,y].getVertice(1).GetPosition(), Vector3.one * .4f);

	// 				Gizmos.color = (grid.GetCells()[x,y].getVertice(2).IsTraversable())?Color.white:Color.black;
	// 				Gizmos.DrawCube(grid.GetCells()[x,y].getVertice(2).GetPosition(), Vector3.one * .4f);

	// 				Gizmos.color = (grid.GetCells()[x,y].getVertice(3).IsTraversable())?Color.white:Color.black;
	// 				Gizmos.DrawCube(grid.GetCells()[x,y].getVertice(3).GetPosition(), Vector3.one * .4f);

	// 				Gizmos.color = (grid.GetCells()[x,y].getVertice(4).IsTraversable())?Color.white:Color.black;
	// 				Gizmos.DrawCube(grid.GetCells()[x,y].getVertice(4).GetPosition(), Vector3.one * .4f);


	// 				// Gizmos.color = Color.grey;
	// 				// Gizmos.DrawCube(grid.squares[x,y].centreTop.position, Vector3.one * .15f);
	// 				// Gizmos.DrawCube(grid.squares[x,y].centreRight.position, Vector3.one * .15f);
	// 				// Gizmos.DrawCube(grid.squares[x,y].centreBottom.position, Vector3.one * .15f);
	// 				// Gizmos.DrawCube(grid.squares[x,y].centreLeft.position, Vector3.one * .15f);

	// 			}
	// 		}
	// 	}
	// }

    }

}
