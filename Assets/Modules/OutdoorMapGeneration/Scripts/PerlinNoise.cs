using UnityEngine;
using System.Collections;

namespace Noises {
	
	public class PerlinNoiseToUpdate {
		
		
        private float[,] noiseMap;
        private int dimensionX, dimensionY;
        private float maxNoiseHeight;
        private float minNoiseHeight;

        private float noiseScale;
		
        private float randomSeed;
        


        public PerlinNoiseToUpdate(int dimensionX, int dimensionY, int seed, float scale) {
            maxNoiseHeight = int.MinValue;
            minNoiseHeight = int.MaxValue;

            this.dimensionX = dimensionX;
			this.dimensionY = dimensionY;
            randomSeed = seed;
            noiseScale = scale;
			
        }
		
		// public PerlinNoise InsertNoiseValues(float [,] noiseValues) {
		// 	if (noiseValues.GetLength(0) != dimensionX || noiseValues.GetLength(1) != dimensionY) throw (new DimensionMismatchException(noiseValues));
			
        //     for (int x = 0; x < dimensionX; x++) {
		// 		for (int y = 0; y < dimensionY; y++) {
        //             noiseMap[x, y] = noiseValues[x, y];
        //         }
		// 	}
			
			
        //     return this;
        // }
		
		public float[,] getNoiseMap() {
            return noiseMap;
        }
		
		
		public int[] getNoiseMapDimensions() {
			return new int[2]{dimensionX, dimensionY};
        }
		
		public int getNoiseMapDimensionX() {
            return dimensionX;
        }
		
		public int getNoiseMapDimensionY() {
            return dimensionY;
        }		


    }
	
	
	public class SimplexNoise {
		//different variant of perlin noise
	}
	
	
	public class StaticNoise {
		//for usage in cellular automata
	}
	
	
	
	public static class PerlinNoise {

        //TODO:
        //make separate class for 2d visualization of map
        public static float[,] Generate2d(int mapX, int mapY, int seed, float scale, int octaves, float persistence, float lacunarity, Vector2 manualOffset) {
			
			float[,] map = new float[mapX, mapY];
			System.Random random = new System.Random(seed);
			Vector2[] octaveOffsets = new Vector2[octaves];
			float sampleX, sampleY;
			float perlinNoiseValue;
            float maxNoiseHeight = 0;
            float minNoiseHeight = float.MaxValue;
            float maxNormalizedHeight = 0;
            float minNormalizedHeight = float.MaxValue;
            float normalizedHeight;
            if(scale==0) scale = 0.0001f;

			
			for (int i=0 ; i < octaves; ++i) octaveOffsets[i] = new Vector2(random.Next(-10000, 1000) + manualOffset.x, random.Next(-1000, 10000) + manualOffset.y);

			for (int x = 0; x < mapX; ++x) {
				for (int y = 0; y < mapY; ++y) {
					
					float amplitude = 1;
					float frequency = 1;
					float noiseHeight = 0;   

					for (int o = 0; o < octaves; ++o) {
						sampleX = (x - mapX/2f) / scale * frequency + octaveOffsets[o].x;
                        sampleY = (y - mapY/2f) / scale * frequency + octaveOffsets[o].y;
						
                        perlinNoiseValue = Mathf.PerlinNoise(sampleX, sampleY);

						noiseHeight += perlinNoiseValue * amplitude;
						amplitude *= persistence;
						frequency *= lacunarity;
					}
					
					if(noiseHeight > maxNoiseHeight) 
						maxNoiseHeight = noiseHeight;
					else if (noiseHeight < minNoiseHeight) 
						minNoiseHeight = noiseHeight;


                    normalizedHeight = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseHeight);
					if(normalizedHeight > maxNormalizedHeight)
                        maxNormalizedHeight = normalizedHeight;
					else if (normalizedHeight < minNormalizedHeight)
                        minNormalizedHeight = normalizedHeight;
						
						
                    map[x, y] = normalizedHeight;
					
					
					//debugging purposes only:
					if( x == 0 || y == 0
					|| x == 1 || y == 1
					|| x == 2 || y == 2
					|| x == 3 || y == 3
					|| x == 4 || y == 4) 
                        map[x, y] = 1f;
                        
                     else {
						 for (int i =0; i <30; ++i) {
                            map[i + 15, i + 15] = 0f;
							map[i + 15, i + 15 + 1] = 0f;
							map[i + 15 + 1, i + 15 + 1] = 0f;
							map[i + 15 + 1, i + 15] = 0f;
                        }
					 }
					
						
                    

                }
			} 
            Debug.Log("new noise, max: " + maxNoiseHeight + ", min: " + minNoiseHeight);
			Debug.Log("normalized, max: " + maxNormalizedHeight + ", min: " + minNormalizedHeight);
            return map;
		}



		public static float[,] Generate2d(int mapX, int mapY, float scale, int octaves, float persistence, float lacunarity) {
        	return Generate2d(mapX, mapY, 1, scale, octaves, persistence, lacunarity, new Vector2(0,0));
    	}
		
		public static float[,] Generate2d(int mapX, int mapY, float scale, int octaves, float persistence, float lacunarity, Vector2 manualOffset) {
        	return Generate2d(mapX, mapY, 1, scale, octaves, persistence, lacunarity, manualOffset);
    	}

		public static float[,] Generate2d(int mapX, int mapY, int seed, float scale, int octaves, float persistence, float lacunarity) {
        	return Generate2d(mapX, mapY, seed, scale, octaves, persistence, lacunarity, new Vector2(0,0));
    	}
		
		public static float Generate1d(float x, float y, float scale) {
			return Mathf.PerlinNoise(x / scale, y / scale);
		}
		
	

}}