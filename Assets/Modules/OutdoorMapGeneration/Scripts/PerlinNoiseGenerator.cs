using UnityEngine;
using System.Collections;
using Noises;

public static class PerlinNoiseGenerator {
		
	private static System.Random randomizer;
    private static long[] seedCache;
    private static long seedCacheLength;
	
    private static float noiseAmplitude;
    private static float noiseFrequency;
    private static float noisePersistence;
	private static float noiseLacunarity;
	private static float noiseScale;
	
	private static int samples;
    private static double noiseValue;
	private static float noiseValueX;
	private static float noiseValueY;
    private static Vector2 manualOffset;
    // private static PerlinNoise[] generatedNoises;


    static PerlinNoiseGenerator() {
		//instantiation of randomizer and filling in default values
        randomizer = new System.Random();
        // generatedNoises = new PerlinNoise[1];
        noiseScale = 1.5f;
        noiseLacunarity = 2.5f;
        noisePersistence = 0.45f;
    }
	
	public static void GenerateSeeds() {
		
	}
	
	public static void UpdateOffset(Vector2 offset) {
        manualOffset = offset;
    }
	
	public static void UpdateParameters(){
		
	}
	
	
	// public static PerlinNoise Generate() {
    //     UpdateParameters();
    //     generatedNoises[0] = new PerlinNoise();
    //     return GeneratePerlin()
	// }
	
	
	// private static PerlinNoise GeneratePerlin(PerlinNoise perlinNoise) {
    //     float[,] tmpMap = perlinNoise.getNoiseMap();
    //     for (int x = 0; x < perlinNoise.getNoiseMapDimensionX(); x++) {
	// 		for (int y = 0; y < perlinNoise.getNoiseMapDimensionY(); y++) {
    //             noiseAmplitude = 1;
    //             noiseFrequency = 1;
    //             noiseScale = 1;
    //             noiseValue = 0;

    //             for (int s = 0; s < samples; s++) {
    //                 noiseValueX = (x / noiseScale) * noiseFrequency + randomizer.Next(-1000,1000);
	// 				noiseValueY = (y / noiseScale) * noiseFrequency + randomizer.Next(-1000,1000);
    //                 noiseValue += Mathf.PerlinNoise(noiseValueX, noiseValueY);

    //                 noiseFrequency *= 2;
    //                 noiseScale -= 0.25f;
	// 				noiseAmplitude
					
    //             }
				
    //             tmpMap[x,y] = 
	// 		}
	// 	}
		
	// }
	
}
