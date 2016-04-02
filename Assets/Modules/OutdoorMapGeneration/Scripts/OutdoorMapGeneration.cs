using UnityEngine;
using System.Collections;
using Noises;

public class OutdoorMapGeneration : MonoBehaviour {

    public int mapX = 50;
    public int mapY = 50;
	[Range (0, 50)]
    public float noiseScale = 0.5f;

	[Range (1, 10)]
	public int octaves = 3;
	[Range (1, 6)]
	public float persistence;
	[Range (1, 6)]
	public float lacunarity;

    public bool isAutoUpdatable;

    
    
    public void Generate() {
        if(mapX < 2) mapX = 10;
        if(mapY < 2) mapY = 10;
        float[,] map = PerlinNoise.Generate2d(mapX,mapY, noiseScale, octaves, persistence, lacunarity);
        
        
        OutdoorMapRenderer2DTest renderer = FindObjectOfType<OutdoorMapRenderer2DTest>();
        renderer.DrawTexture(map);
    }
    
    
    
}
