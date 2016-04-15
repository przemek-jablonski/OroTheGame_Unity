using UnityEngine;

public class Noise  {
	
    private float[,] noiseTable;
    private int mapDimensionsX;
    private int mapDimensionsY;
	
	
	
	public Noise(Vector2 mapDimensions) : this((int)mapDimensions.x, (int)mapDimensions.y){
		
	}
	
	public Noise(int mapDimensionsX, int mapDimensionsY) {
		
		//todo: convert that stuff below into exception wrapper class
		if (mapDimensionsX <= 1 || mapDimensionsY <= 1)
			Debug.LogError("NO CHYBA NIE, PRZESLALES ZA MALY ROZMIAR MAPY");

        this.mapDimensionsX = mapDimensionsX;
        this.mapDimensionsY = mapDimensionsY;
        noiseTable = new float[mapDimensionsX, mapDimensionsY];
    }
	

}
