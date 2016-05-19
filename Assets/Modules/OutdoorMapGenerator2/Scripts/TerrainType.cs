using UnityEngine;
using System.Collections.Generic;

public class TerrainType {
	
	//todo:
	//separate this class in two, so that data in atributes
	//are not in the same object as creators of different terrains
	
    private string  terrainName;
    private float 	 terrainHeightLower;
    private float 	 terrainHeightUpper;
    private Color 	terrainColorLower;
	private Color 	terrainColorUpper;
	
	
	public TerrainType() {
		
	}
	
	public TerrainType(string name, float terrainHeightLower, float terrainHeightUpper, Color terrainColorLower, Color terrainColorUpper) {
		this.terrainName = name;
		this.terrainHeightLower = terrainHeightLower;
		this.terrainHeightUpper = terrainHeightUpper;
		this.terrainColorLower = terrainColorLower;
		this.terrainColorUpper = terrainColorUpper;
	}
	
	public TerrainType createWater() {
		terrainName = "water";
        terrainHeightLower = 0.0f;
		terrainHeightUpper = 0.10f;
        terrainColorLower = new Color(0, 0, 0.65f, 1);
        terrainColorUpper = new Color(0, 0, 1, 1);
        // terrainColorUpper = terrainColorLower = Color.blue;
        return this;
	}
	
	public TerrainType createLand() {
		terrainName = "land";
        terrainHeightLower = 0.10f;
		terrainHeightUpper = 0.40f;
        terrainColorLower = new Color(1, 1, 0.80f, 1);
        terrainColorUpper = new Color(1, 0.95f, 0.6f, 1);
        // terrainColorUpper = terrainColorLower = Color.yellow;
        return this;
	}
	
	public TerrainType createGrass() {
		terrainName = "grass";
        terrainHeightLower = 0.40f;
		terrainHeightUpper = 0.70f;
        terrainColorLower = new Color(0.6f, 1, 0.15f, 1);
		terrainColorUpper = new Color(0.6f, 0.95f, 0.05f, 1);
		// terrainColorUpper = terrainColorLower = Color.green;
        return this;
	}
	
	public TerrainType createRocks() {
		terrainName = "rocks";
        terrainHeightLower = 0.70f;
		terrainHeightUpper = 0.90f;
        terrainColorLower = new Color(0.75f, 0.75f, 0.75f, 1);
		terrainColorUpper = new Color(0.55f, 0.55f, 0.55f, 1);
		// terrainColorUpper = terrainColorLower = Color.grey;
        return this;
	}
	
	
	public TerrainType createMountains() {
		terrainName = "mountains";
        terrainHeightLower = 0.90f;
		terrainHeightUpper = 1;
        terrainColorLower = new Color(0.55f, 0.55f, 0.55f, 1);
        terrainColorUpper = new Color(0.20f, 0.25f, 0.20f, 1);
		// terrainColorUpper = terrainColorLower = Color.black;
        return this;
	}
	
	
	public Vector2 getHeightInterval() {
        return new Vector2(terrainHeightLower, terrainHeightUpper);
    }
	
	public List<Color> getColorInterval() {
        List<Color> list = new List<Color>();
        list.Add(terrainColorLower);
		list.Add(terrainColorUpper);
        return list;
    }
	
}
