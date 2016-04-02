using UnityEngine;
using System.Collections;

namespace Noises {
	
	
	public static class PerlinNoise {
		
		//todo:
		//make separate class for 2d visualization of map
		
		public static float[,] Generate2d(int mapX, int mapY, float scale, float octaves, float persistence, float lacunarity) {
			float[,] map = new float[mapX, mapY];
			
			if(scale==0) 
				scale = 0.0001f;

			float sampleX, sampleY;
			float perlinNoiseValue;
			float maxNoiseHeight;
			float minNoiseHeight;


			maxNoiseHeight = float.MaxValue;
			minNoiseHeight = float.MinValue;

			Debug.Log("Debugging values to interpolate:");
			Debug.Log("maxNoiseHeight: " + maxNoiseHeight + ", minNoiseHeight: " + minNoiseHeight);

			for (int x = 0; x < mapX; ++x) {
				for (int y = 0; y < mapY; ++y) {
					
					float amplitude = 1;
					float frequency = 1;
					float noiseHeight = 0;

					for (int o = 0; o < octaves; ++o){
						sampleX = x / scale * frequency;
						sampleY = y / scale * frequency;

						perlinNoiseValue = Mathf.PerlinNoise(sampleX, sampleY)*2-1;

						//below will transform output of perlinNoise to (-1,1) instead of (0,1)
						// perlinNoiseValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 -1;

						noiseHeight += perlinNoiseValue * amplitude;
						amplitude *= persistence;
						frequency *= lacunarity;
					}

					// if (noiseHeight > maxNoiseHeight){
					// 	Debug.Log("New lerp (max):");
					// 	Debug.Log("was: " + maxNoiseHeight + ", now: " + noiseHeight);
					// 	maxNoiseHeight = noiseHeight;
					// } else if (noiseHeight < minNoiseHeight) {
					// 	Debug.Log("New lerp (min):");
					// 	Debug.Log("was: " + maxNoiseHeight + ", now: " + noiseHeight);
					// 	minNoiseHeight = noiseHeight;
					// }

						map[x,y] = noiseHeight;
				}
			}
			
			// for (int y= 0; y < mapY; ++y){
			// 	for (int x = 0 ; x < mapX;  ++x){
			// 		    map[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, map[x, y]);
			// 	}
			// } 


			return map;
		}
		
		public static float Generate1d(float x, float y, float scale) {
			return Mathf.PerlinNoise(x / scale, y / scale);
		}

	}


}