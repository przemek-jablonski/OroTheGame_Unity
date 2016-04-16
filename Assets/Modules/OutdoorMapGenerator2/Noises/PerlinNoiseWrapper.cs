using UnityEngine;
using System.Collections;


public static class PerlinNoiseWrapper{

    private static OroNoises.Noise perlinNoise;
	
	//todo: implement seed caching mechanism
	//todo: check if there is a difference between System.Random and Random
    private static System.Random 	random;
    // private static System.Random random;

    private static Vector2Int mapDimensions;
    private static float actualPerlinValue;


	//generation parameters:
    private static Vector2Int 	dimensions;
    private static Vector2Int   mapScale;
    private static bool 		useRandomSeed;
    private static bool 		randomSampleOffsets;
    private static float 		 cohesivenessPercent;
    private static float 		 noiseScale;
    private static int 			samples;
    private static float 		 persistence;
    private static float 		 lacunarity;
    private static Vector2 		manualOffset;
	private static Vector2[] 	randomSampleOffsetArray;
	
	//generation temporary attributes:
    private static float 		 amplitude = 1f;
    private static float 		 frequency = 1f;
    private static float 		 valueX = 0;
	private static float 		 valueY = 0;
    private static float 		 valuePerlin = 0;
	private static float 		 minHeight = float.MaxValue;
	private static float 		 maxHeight = float.MinValue;




    static PerlinNoiseWrapper() {
        random = new System.Random();
        ResetGenerationAttributes();
        Debug.Log("Created PerlinNoiseWrapper");
    }
	
	
	
	public static void InstantiateNoise() {
        perlinNoise = new OroNoises.Noise(perlinNoise.GetTableDimensions());
        FillNoiseWithZeros();

        Debug.Log("Instantiated noise instance inside PerlinNoiseWrapper");
    }
	
	
	//updating generation parameters and generating Perlin noise values:
	public static OroNoises.Noise GeneratePerlinNoise(Vector2Int _dimensions, Vector2Int _mapScale, bool _useRandomSeed, bool randomOffsets, float _cohesivenessPercent, float _noiseScale, int _samples, float _persistence, float _lacunarity, Vector2 _manualOffset) {
		
		//this must fail someday, so this condition is checked here
		//TODO: change this conditional statement to custom EXCEPTION
		if(dimensions.GetVector()[0] != mapDimensions.GetVector()[0] || dimensions.GetVector()[1] != mapDimensions.GetVector()[1]) {
            Debug.Log("SENT DIMENSIONS ARE NOT EQUALLY VALUED WITH DIMENSIONS INSIDE PERLIN NOISE TABLE!"); return null;
        }

        dimensions = _dimensions;
        mapScale = _mapScale;
        useRandomSeed = _useRandomSeed;
        randomSampleOffsets = randomOffsets;
        cohesivenessPercent = _cohesivenessPercent;
        noiseScale = _noiseScale;
        samples = _samples;
        persistence = _persistence;
        lacunarity = _lacunarity;
        manualOffset = _manualOffset;
		
        GenerateNoiseValues();
        return perlinNoise;
    }
	
	
	//static method for inserting randomized values into Noise (perlinNoise) class
	private static OroNoises.Noise GenerateNoiseValues() {
		
		ResetGenerationAttributes();
		if(useRandomSeed == true || cohesivenessPercent != 1f) { 
			ReinstantiateRandomizer(); 
		}
		
		if(randomSampleOffsets) {
            randomSampleOffsetArray = new Vector2[samples];
            for (int s = 0; s < samples; s++) {
                randomSampleOffsetArray[s].x = random.Next(-1000);
				randomSampleOffsetArray[s].y = random.Next(1000);
            }
		}
        

        for (int x = 0; x < perlinNoise.GetTableDimensions().GetVector()[0]; ++x) {
            for (int y = 0; y < perlinNoise.GetTableDimensions().GetVector()[1]; ++y) {
				// ??
                // minHeight = float.MaxValue;
                // maxHeight = float.MinValue;
				
                amplitude = 1f;
                frequency = 1f;
                valuePerlin = 0;

                for (int s = 0; s < samples; ++s) {
                    valueX = GeneratePerlinNoiseCoord(x, manualOffset.x);
					valueY = GeneratePerlinNoiseCoord(y, manualOffset.y);
					if(randomSampleOffsets) {
                        valueX += randomSampleOffsetArray[s].x;
						valueY += randomSampleOffsetArray[s].y;
                    }
                    valuePerlin += Mathf.PerlinNoise(valueX, valueY);
					
                    amplitude *= persistence;
                    frequency *= lacunarity;
                }
				
				if (valuePerlin > maxHeight) maxHeight = valuePerlin;
				else if (valuePerlin < minHeight) minHeight = valuePerlin; 
				
                valuePerlin = Mathf.InverseLerp(minHeight, maxHeight, valuePerlin);
				
                perlinNoise.SetNoiseTableCell(x, y, valuePerlin);

            }
        }
		
		Debug.Log("Generated noise values inside PerlinNoiseWrapper");
        Debug.Log("Max Value was: " + maxHeight + ", Min Value was: " + minHeight);
        return perlinNoise;
    }
	

  	private static float GeneratePerlinNoiseCoord(float baseValue, float offsetValue) {
		 if (cohesivenessPercent != 1f) {
            float randomElement = (float)random.NextDouble() * cohesivenessPercent;
			return (((baseValue - mapDimensions.GetVector()[0]) / 2f) / noiseScale * frequency ) + offsetValue + randomElement;
        }
        
		return (((baseValue - mapDimensions.GetVector()[0]) / 2f) / noiseScale * frequency) + offsetValue;
	}
	
	
	private static void ResetGenerationAttributes() {
        minHeight = float.MaxValue;
        maxHeight = float.MinValue;
        amplitude = 1f;
        frequency = 1f;
        valueX = 0;
        valueY = 0;
        valuePerlin = 0;
        randomSampleOffsetArray = new Vector2[samples];
    }
	
  
	private static void ReinstantiateRandomizer() {
		int seed = Random.seed;
		random = new System.Random(seed);
		Debug.Log("Randomizer reinstantiated with seed: [" + seed + "]");
	}
	


    public static float[,] GetNoiseTable() {
        return perlinNoise.GetNoiseTable();
    }
	
	
	private static float[,] FillNoiseWithZeros() {
        int noiseTableDimensionsX = perlinNoise.GetTableDimensions().GetVector()[0];
		int noiseTableDimensionsY = perlinNoise.GetTableDimensions().GetVector()[1];
        float[,] zeroedNoiseTable = new float[noiseTableDimensionsX, noiseTableDimensionsY];
		
        for (int x = 0; x < noiseTableDimensionsX; ++x)
            for (int y = 0; y < noiseTableDimensionsY; ++y)
                zeroedNoiseTable[x, y] = 0;

        perlinNoise.SetNoiseTable(zeroedNoiseTable);
        return GetNoiseTable();
    }
	
    
    public static OroNoises.Noise GetNoiseClass() {
        return perlinNoise;
    }
    

}
