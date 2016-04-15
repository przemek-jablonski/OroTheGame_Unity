using System;
using UnityEngine;

public class Vector2Int {

    private int x { get; set; }
    private int y { get; set; }




    public Vector2Int() {
        x = new int();
        y = new int();
    }
	
	public Vector2Int(object coordX, object coordY) {
        SetVector(coordX, coordY);
    }
	
	public Vector2Int(Vector2 coords) {
        SetVector(coords);
    }
	
	

	public Vector2Int SetVector(object coordX, object coordY) {
		x = Convert.ToInt32(coordX);
        y = Convert.ToInt32(coordY);
        return this;
    }
	
	public Vector2Int SetVector(Vector2 coords) {
        x = (int)coords.x;
        y = (int)coords.y;
        return this;
    }
	
	public int[] GetVector() {
        return new int[2] { x, y };
    }
	
	
}