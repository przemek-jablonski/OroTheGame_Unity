using UnityEngine;
using System.Collections;

public class OutdoorMapController : MonoBehaviour {


    public MeshRenderer texture;
	
	//todo: instead of creating MESH object manually
	//let this controller (or rather some model method)
	//create it automatically...
    public MeshFilter meshFilter;
    public MeshRenderer meshRenderer;

    public int mapDimensionX = 75;
	public int mapDimensionY = 75;
    public int mapScaleX = 75;
    public int mapScaleY = 75;
    public Vector2 scrolling;

	[Range (0,35)]
    public float noiseScale = 0.5f;

	[Range (1, 10)]
    public int samples = 3;

	[Range (0, 9f)]
    public float persistence = 0.75f;
	
	[Range (0.50f, 10)]
	public float lacunarity = 1.15f;

    [Range(0, 1)]
    public float cohesiveness = 1f;


    public bool useRandomSeed = false;
    public bool scrollable = true;
    public bool rndSampleOffsets = false;
    public bool autoUpdate = false;
    public bool customMapScale = false;
    public FilterMode textureFiltering = FilterMode.Point;
	
	
	public void OnValidate() {
		if (mapDimensionX < 5) mapDimensionX = 5;
		if (mapDimensionY < 5) mapDimensionY = 5;
		if (noiseScale <= 0) noiseScale = 0.001f;
		if (persistence <= 0) persistence = 0.0001f;
		if (cohesiveness < 0f || cohesiveness > 1f) cohesiveness = 1f;
		if (!customMapScale) {
			if (mapDimensionX != mapScaleX) mapScaleX = mapDimensionX;
			if (mapDimensionY != mapScaleY) mapScaleY = mapDimensionY;
        }
    } 
		
	private void GeneratePerlinNoise() {
        OroNoises.Noise perlinNoise = new OroNoises.Noise(mapDimensionX, mapDimensionY);
        PerlinNoiseWrapper.InstantiateNoise();
        PerlinNoiseWrapper.GeneratePerlinNoise(
            new Vector2Int(mapDimensionX, mapDimensionY),
			new Vector2Int(mapScaleX, mapScaleY),
            false,
			false,
            cohesiveness,
            noiseScale,
            samples,
            persistence,
            lacunarity,
            scrolling);

    }
	
	public void GenerateNonColourTexture() {
        RenderingUtility rendering = FindObjectOfType<RenderingUtility>();
        rendering.CreateNonColourTexture(PerlinNoiseWrapper.GetNoiseClass(), new Vector2Int(mapScaleX, mapScaleY), textureFiltering);

    }
	
	public void GenerateColourfulTexture() {
		//...
	}

	public void GenerateMesh() {
		//...
	}

}
