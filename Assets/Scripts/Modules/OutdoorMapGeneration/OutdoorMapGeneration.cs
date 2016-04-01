using UnityEngine;
using System.Collections;
using Noises;

public class OutdoorMapGeneration : MonoBehaviour {

    public int mapX = 20;
    public int mapY = 20;
    public float noiseScale = 1;
    public bool isAutoUpdatable;
    
    
    public void Generate() {
        if(mapX < 2) mapX = 10;
        if(mapY < 2) mapY = 10;
        float[,] map = PerlinNoise.Generate2d(mapX,mapY, noiseScale);
        
        
        OutdoorMapRenderer2DTest renderer = FindObjectOfType<OutdoorMapRenderer2DTest>();
        renderer.DrawTexture(map);
    }
    
    
    
}
