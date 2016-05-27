using UnityEngine;
using System.Collections;

public class Vertice {

	//todo: fix this 'traversable' bool - 
	//if there isnt a wall, then Cell object should not be created(?)
    private bool traversable;
    private readonly int indexX;
	private readonly int indexY;
    private int vertexIndex;
    private Vector3 position { set; get; }
	
	public Vertice(bool traversable, int indexX, int indexY, float positionX, float positionY, float positionZ) {
        this.traversable = traversable;
        this.indexX = indexX;
		this.indexY = indexY;
        position.Set(positionX, positionY, positionZ);
    }
	
	public Vertice(bool traversable, int indexX, int indexY, Vector3 position) {
        this.traversable = traversable;
        this.indexX = indexX;
        this.indexY = indexY;
        this.position = position;
    }
	
	public void SetVertexIndex(int vertexIndex) {
        this.vertexIndex = vertexIndex;
    }

	public bool IsTraversable() {
        return traversable;
    }
	
	public Vector3 GetPosition() {
        return position;
    }
	
	public int GetVertexIndex() {
        return vertexIndex;
    }

}
