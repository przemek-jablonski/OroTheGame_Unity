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


    private float[,] perlinNoiseTable;
    private Texture2D texture;

    private OutdoorMapRenderer2DTest renderer;


    public void Generate() {
        Debug.Log("OutdoorMapGeneration.Generate()");
        renderer = FindObjectOfType<OutdoorMapRenderer2DTest>();
        if (renderer)  Debug.Log("Renderer instantiated (not null)");
        else           Debug.LogError("RENDERER IS NULL!");

        perlinNoiseTable = this.GeneratorChooser();
        texture = renderer.DrawTexture(perlinNoiseTable, textureFiltering);
		renderer.textureRenderer.sharedMaterial.mainTexture = texture;
        renderer.textureRenderer.transform.localScale = new Vector3(mapX, 1, mapY);		
    }
	
	public void GenerateMesh() {
        Debug.Log("OutdoorMapGeneration.GenerateMesh()");
        renderer.RenderMesh(
				MeshGenerator.GenerateTerrainMesh(perlinNoiseTable),
        		texture);
		
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
