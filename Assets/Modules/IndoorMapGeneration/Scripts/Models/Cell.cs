using UnityEngine;
using System.Collections;

public class Cell {
	
	//array of 4 vertices, as follows:
	//index 0: top left
	//index 1: top right
	//index 2: bottom left
	//index 3: bottom right
    private Vertice[] vertices;
	
	
	public Cell(Vertice vTopLeft, Vertice vTopRight, Vertice vBottomLeft, Vertice vBottomRight) : this() {
        updateVertices(vTopLeft, vTopRight, vBottomLeft, vBottomRight);
    }
	
	public Cell() {
        vertices = new Vertice[4];
        vertices[0] = null;
		vertices[1] = null;
		vertices[2] = null;
		vertices[3] = null;
    }
	

    public void updateVertice(int index, Vertice vertice) {
        vertices[index] = vertice;
    }
	
	public void updateVertices(Vertice vTopLeft, Vertice vTopRight, Vertice vBottomLeft, Vertice vBottomRight) {
		vertices[0] = vTopLeft;
		vertices[1] = vTopRight;
		vertices[2] = vBottomLeft;
		vertices[3] = vBottomRight;
	}
	
	
	//fix that, there should be only one getter for specific vertice
	public Vertice getVertice(int standardIndexing) {
        return vertices[standardIndexing-1];
    }
	
	public Vertice GetVerticeZero(int index) {
        return vertices[index];
    }
	
	public Vertice[] getVertices() {
        return vertices;
    }
	
}
