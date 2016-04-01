using UnityEngine;
using System.Collections;

namespace Noises {
public static class PerlinNoise {
    
    //todo:
    //make separate class for 2d visualization of map
    
    public static float[,] Generate2d(int mapX, int mapY, float scale) {
        float[,] map = new float[mapX, mapY];
        
        if(scale<=0) scale = 0.001f;
        
        
        //todo:
        //make for(){ for() } as a template, like function, that you pass another function into
        //that way: for(){ for(){ dosomething() }}
        
        for (int y = 0; y < mapY; ++y) {
            for (int x = 0; x < mapX; ++x) {
                float sampleX, sampleY;
                // sampleX = x;
                // sampleY = y;
                
                sampleX = x / scale;
                sampleY = y / scale;
                
                float perlinValue = Mathf.PerlinNoise(sampleX, sampleY);
                map[x,y]=perlinValue;
            }
        }
        
        
        return map;
    }

}
}