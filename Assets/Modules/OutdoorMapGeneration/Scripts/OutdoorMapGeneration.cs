using UnityEngine;
using System.Collections;
using Noises;


public class OutdoorMapGeneration : MonoBehaviour {
	
	// this shit should be called OutdoorMapController
	// (because that's what it is)

    public int mapX = 50;
    public int mapY = 50;
	[Range (0, 50)]
    public float noiseScale = 0.5f;
	[Range(1, 10)]
	public int octaves = 3;
    [Range(0.001f, 5)]
    public float persistence = 1;
    [Range(1, 10)]
    public float lacunarity = 1;
	
    public Vector2 scroll;

    public FilterMode textureFiltering = FilterMode.Point;
    public bool useRandomSeed = false;
    public bool scrollable = true;
    public bool autoUpdate = true;


    public void Generate() {
        OutdoorMapRenderer2DTest renderer = FindObjectOfType<OutdoorMapRenderer2DTest>();
        renderer.DrawTexture(this.GeneratorChooser(), textureFiltering);		
    }
	
	public void GenerateMesh() {
		OutdoorMapRenderer2DTest renderer = FindObjectOfType<OutdoorMapRenderer2DTest>();
        renderer.RenderMesh(
				MeshGenerator.GenerateTerrainMesh(this.GeneratorChooser()),
        		renderer.DrawTexture(this.GeneratorChooser(), textureFiltering));
		
    }
	
	private float[,] GeneratorChooser() {
		if(useRandomSeed) {
			System.Random random = new System.Random();
			if(scrollable)
            	return PerlinNoise.Generate2d(mapX, mapY, random.Next(), noiseScale, octaves, persistence, lacunarity, scroll);
			else
				return PerlinNoise.Generate2d(mapX, mapY, random.Next(), noiseScale, octaves, persistence, lacunarity);
        } else {
			if(scrollable) return PerlinNoise.Generate2d(mapX, mapY, noiseScale, octaves, persistence, lacunarity, scroll);
		}
		
		return PerlinNoise.Generate2d(mapX, mapY, noiseScale, octaves, persistence, lacunarity); 
	} 
	
	
	void OnValidate() {
		if (mapX < 10) mapX = 10;
		if (mapY < 10) mapY = 10;
		if (noiseScale <= 0) noiseScale = 0.001f;
    }
	
	
}
