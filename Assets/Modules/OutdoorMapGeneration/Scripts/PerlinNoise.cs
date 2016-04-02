using UnityEngine;
using System.Collections;

namespace Noises {
public static class PerlinNoise {
    
    //todo:
    //make separate class for 2d visualization of map
    
    public static float[,] Generate2d(int mapX, int mapY, float scale, float octaves, float persistence, float lacunarity) {
        float[,] map = new float[mapX, mapY];
        
        if(scale==0) scale = 0.0001f;
        
        float sampleX, sampleY;
        float perlinNoiseValue;
        float amplitude = 1;
        float frequency = 1;
        float noiseHeight = 0;
        
        for (int x = 0; x < mapX; ++x) {
            for (int y = 0; y < mapY; ++y) {
                amplitude = 1;
                frequency = 1;
                noiseHeight = 0;
                
                for (int o = 0; o < octaves; ++o){
                    sampleX = x / scale * frequency;
                    sampleY = y / scale * frequency;
                
                    perlinNoiseValue = Mathf.PerlinNoise(sampleX, sampleY);
                    
                    //below will transform output of perlinNoise to (-1,1) instead of (0,1)
                    // float perlinNoiseValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 -1;
                    
                    noiseHeight = perlinNoiseValue * amplitude;
                    amplitude *= persistence;
                    frequency *= lacunarity;    
                }

                map[x,y] = noiseHeight;
            }
        }
				


			//todo:
			//make for(){ for() } as a template, like function, that you pass another function into
			//that way: for(){ for(){ dosomething() }}

			// for (int y = 0; y < mapY; ++y) {
			//     for (int x = 0; x < mapX; ++x) {
			//         float sampleX, sampleY;
			//         // sampleX = x;
			//         // sampleY = y;

			//         sampleX = x / scale;
			//         sampleY = y / scale;

			//         float perlinValue = Mathf.PerlinNoise(sampleX, sampleY);
			//         map[x,y]=perlinValue;
			//     }
			// }
        
        
        return map;
    }

}
}