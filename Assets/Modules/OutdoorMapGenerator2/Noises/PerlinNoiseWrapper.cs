using UnityEngine;
using System.Collections;


public static class PerlinNoiseWrapper{

    private static OroNoises.Noise perlinNoise;
	
	//todo: implement seed caching mechanism
	//todo: check if there is a difference between System.Random and Random
    private static System.Random 	random;
    // private static System.Random random;

    private static float actualPerlinValue;


	//generation parameters:
    private static Vector2Int   mapDimensions;
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
    private static float         allSamplesValuePerlin = 0;
    private static float 		 minHeight = float.MaxValue;
	private static float 		 maxHeight = float.MinValue;




    static PerlinNoiseWrapper() {
        random = new System.Random();
        ResetGenerationAttributes();
        Debug.Log("Created PerlinNoiseWrapper");
    }
	
	
	
	public static void InstantiateNoise(Vector2Int noiseDimensions) {
        
        Debug.Log("BEFORE Instantiated noise instance inside PerlinNoiseWrapper");
        perlinNoise = new OroNoises.Noise(noiseDimensions);
        FillNoiseWithZeros();

        Debug.Log("Instantiated noise instance inside PerlinNoiseWrapper");
    }
	
	
	//updating generation parameters and generating Perlin noise values:
	public static OroNoises.Noise GeneratePerlinNoise(Vector2Int _dimensions, Vector2Int _mapScale, bool _useRandomSeed, bool randomOffsets, float _cohesivenessPercent, float _noiseScale, int _samples, float _persistence, float _lacunarity, Vector2 _manualOffset) {
        Debug.Log("PerlinNoiseWrapper: GeneratePerlinNoise()");
        //this must fail someday, so this condition is checked here
        //TODO: change this conditional statement to custom EXCEPTION
        if(_dimensions.GetVector()[0] != perlinNoise.GetTableDimensions().GetVector()[0] || _dimensions.GetVector()[1] != perlinNoise.GetTableDimensions().GetVector()[1]) {
            Debug.LogError("SENT DIMENSIONS ARE NOT EQUALLY VALUED WITH DIMENSIONS INSIDE PERLIN NOISE TABLE!"); return null;
        }

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
        Debug.Log("PerlinNoiseWrapper: GenerateNoiseValues()");

        ResetGenerationAttributes();
        mapDimensions = perlinNoise.GetTableDimensions();

        Debug.Log("useRandomSeed: " + useRandomSeed);
        // if(useRandomSeed == true || cohesivenessPercent != 1f) {
        if(useRandomSeed) { 
			ReinstantiateRandomizer(); 
		}
        

        if(randomSampleOffsets) {
            randomSampleOffsetArray = new Vector2[samples];
            for (int s = 0; s < samples; s++) {
                randomSampleOffsetArray[s].x = random.Next(-1000);
				randomSampleOffsetArray[s].y = random.Next(1000);
            }
		}
        

        // for (int x = 0; x < perlinNoise.GetTableDimensions().GetVector()[0]; ++x) {
        for (int x = 0; x < mapDimensions.GetVector()[0]; ++x) {
            for (int y = 0; y < mapDimensions.GetVector()[1]; ++y) {
				// ??
                // minHeight = float.MaxValue;
                // maxHeight = float.MinValue;

                amplitude = 1f;
                frequency = 1f;
                valuePerlin = 0;


                for (int s = 0; s < samples; ++s) {
                    valueX = GeneratePerlinNoiseCoord(x, mapDimensions.GetVector()[0], manualOffset.x);
					valueY = GeneratePerlinNoiseCoord(y, mapDimensions.GetVector()[1], manualOffset.y);

					// if(randomSampleOffsets) {
                    //     valueX += randomSampleOffsetArray[s].x;
					// 	valueY += randomSampleOffsetArray[s].y;
                    // }
                    valuePerlin = Mathf.PerlinNoise(valueX, valueY);
                    
                    allSamplesValuePerlin += valuePerlin * amplitude;
                    amplitude *= persistence;
                    frequency *= lacunarity;
                }
				
				if (allSamplesValuePerlin > maxHeight) maxHeight = allSamplesValuePerlin;
				else if (allSamplesValuePerlin < minHeight) minHeight = allSamplesValuePerlin; 
				
                allSamplesValuePerlin = Mathf.InverseLerp(minHeight, maxHeight, allSamplesValuePerlin);

                // perlinNoise.SetNoiseTableCell(x, y, allSamplesValuePerlin);
                perlinNoise.noiseTable[x, y] = allSamplesValuePerlin;

            }
        }
		
		Debug.Log("Generated noise values inside PerlinNoiseWrapper");
        Debug.Log("Max Value was: " + maxHeight + ", Min Value was: " + minHeight);
        return perlinNoise;
    }
	

  	private static float GeneratePerlinNoiseCoord(float baseValue, float mapDimension, float offsetValue) {
        return (baseValue - mapDimension / 2f) / noiseScale * frequency + offsetValue;
    }
	
	
	private static void ResetGenerationAttributes() {
        Debug.Log("PerlinNoiseWrapper: ResetGenerationAttributes()");
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
        Debug.Log("PerlinNoiseWrapper: ReinstantiateRandomizer()"); 
        random = new System.Random(random.Next());
		// Debug.Log("Randomizer reinstantiated with seed: [" + seed + "]");
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
