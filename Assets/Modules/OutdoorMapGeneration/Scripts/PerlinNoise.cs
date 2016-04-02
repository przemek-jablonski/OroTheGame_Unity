using UnityEngine;
using System.Collections;

namespace Noises {
	
	
	public static class PerlinNoise {
		
		//todo:
		//make separate class for 2d visualization of map
		
		public static float[,] Generate2d(int mapX, int mapY, int seed, float scale, int octaves, float persistence, float lacunarity) {
			
			float[,] map = new float[mapX, mapY];
            System.Random random = new System.Random(seed);
            Vector2[] octaveOffsets = new Vector2[octaves];
			
			for (int i=0 ; i < octaves; ++i) {
                float offsetX = random.Next(-10000, 10000);
                float offsetY = random.Next(-10000, 10000);
                octaveOffsets[i] = new Vector2(offsetX, offsetY);
            }
			

            if(scale==0) 
				scale = 0.0001f;

			float sampleX, sampleY;
			float perlinNoiseValue;
			float maxNoiseHeight;
			float minNoiseHeight;


            maxNoiseHeight = 0;
            minNoiseHeight = float.MinValue;

			Debug.Log("Debugging values to interpolate:");
			Debug.Log("maxNoiseHeight: " + maxNoiseHeight + ", minNoiseHeight: " + minNoiseHeight);

			for (int x = 0; x < mapX; ++x) {
				for (int y = 0; y < mapY; ++y) {
					
					float amplitude = 1;
					float frequency = 1;
					float noiseHeight = 0;

					for (int o = 0; o < octaves; ++o){
						sampleX = x / scale * frequency + octaveOffsets[o].x;
                        sampleY = y / scale * frequency + octaveOffsets[o].y;

                        perlinNoiseValue = Mathf.PerlinNoise(sampleX, sampleY);

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
					
					if(noiseHeight > maxNoiseHeight) maxNoiseHeight = noiseHeight;

                    map[x,y] = noiseHeight;
				}
			}

            // for (int y= 0; y < mapY; ++y){
            // 	for (int x = 0 ; x < mapX;  ++x){
            // 		    map[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, map[x, y]);
            // 	}
            // } 

            Debug.Log("noise map created, max: " + maxNoiseHeight);
            return map;
		}
		
		public static float Generate1d(float x, float y, float scale) {
			return Mathf.PerlinNoise(x / scale, y / scale);
		}

	}


}