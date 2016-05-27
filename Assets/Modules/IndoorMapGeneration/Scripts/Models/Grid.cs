using UnityEngine;
using System.Collections;

public class Grid {

    private Cell[,] cells;
    private int cellsWidthX;
	private int cellsDepthY;
	
	public Grid(bool[,] randomizedMap) {
        cellsWidthX = randomizedMap.GetLength(0);
        cellsDepthY = randomizedMap.GetLength(1);

        Vertice[,] vertices = new Vertice[cellsWidthX, cellsDepthY];
		for (int x = 0; x < cellsWidthX; ++x) {
			for (int y = 0; y < cellsDepthY; ++y) {
                Vector3 position = new Vector3(-cellsWidthX/2 + x, 0, -cellsDepthY + y);
                vertices[x, y] = new Vertice(randomizedMap[x,y] == true, x, y, position);
         	}
    	}


        cells = new Cell[cellsWidthX - 1, cellsDepthY - 1];
		for (int x = 0; x < cellsWidthX-1; x++) {
			for (int y = 0; y < cellsDepthY-1; y++) {
                cells[x, y] = new Cell(
					vertices[x,y+1],
					vertices[x+1, y+1],
					vertices[x,y],
					vertices[x+1, y]
					);
            }
		}


    }

	public Cell[,] GetCells() {
        return cells;
    }


}
