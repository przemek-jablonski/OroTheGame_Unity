using UnityEngine;
using System;
using AssemblyCSharp;

namespace OroIndoorMapGeneratorModule
{

    public class MeshGenerator : MonoBehaviour {

        private Grid grid;
		
		public void generateMesh(bool[,] randomizedMap) {
            grid = new Grid(randomizedMap);
        }
		
		
		void OnDrawGizmos() {
            if (grid != null) {
                Debug.Log("notnull");
                for (int x = 0; x < grid.GetCells().GetLength(0); x++) {
				for (int y = 0; y < grid.GetCells().GetLength(1); y++) {

					Gizmos.color = (grid.GetCells()[x,y].getVertice(1).IsTraversable())?Color.white:Color.black;
					Gizmos.DrawCube(grid.GetCells()[x,y].getVertice(1).GetPosition(), Vector3.one * .4f);

					Gizmos.color = (grid.GetCells()[x,y].getVertice(2).IsTraversable())?Color.white:Color.black;
					Gizmos.DrawCube(grid.GetCells()[x,y].getVertice(2).GetPosition(), Vector3.one * .4f);

					Gizmos.color = (grid.GetCells()[x,y].getVertice(3).IsTraversable())?Color.white:Color.black;
					Gizmos.DrawCube(grid.GetCells()[x,y].getVertice(3).GetPosition(), Vector3.one * .4f);

					Gizmos.color = (grid.GetCells()[x,y].getVertice(4).IsTraversable())?Color.white:Color.black;
					Gizmos.DrawCube(grid.GetCells()[x,y].getVertice(4).GetPosition(), Vector3.one * .4f);


					// Gizmos.color = Color.grey;
					// Gizmos.DrawCube(grid.squares[x,y].centreTop.position, Vector3.one * .15f);
					// Gizmos.DrawCube(grid.squares[x,y].centreRight.position, Vector3.one * .15f);
					// Gizmos.DrawCube(grid.squares[x,y].centreBottom.position, Vector3.one * .15f);
					// Gizmos.DrawCube(grid.squares[x,y].centreLeft.position, Vector3.one * .15f);

				}
			}
		}
	}

    }

}
