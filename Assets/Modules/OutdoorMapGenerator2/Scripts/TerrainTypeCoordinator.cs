using UnityEngine;
using System.Collections;

public class TerrainTypeCoordinator {


    private TerrainType[] terrains;
    
    
    public TerrainTypeCoordinator() {
        TerrainType terrain = new TerrainType();
        terrains = new TerrainType[5];
        // terrains[0] = terrain.createWater();
        // terrains[1] = terrain.createLand();
        // terrains[2] = terrain.createGrass();
        // terrains[3] = terrain.createRocks();
        // terrains[4] = terrain.createMountains();
		terrains[0] = new TerrainType().createWater();
        terrains[1] = new TerrainType().createLand();
        terrains[2] = new TerrainType().createGrass();
        terrains[3] = new TerrainType().createRocks();
        terrains[4] = new TerrainType().createMountains();
    }
    
    
    
    
    public TerrainType assignHeightToTerrain(float height) {    
        for (int t = 0; t < terrains.Length; t++) {
            if (height >= terrains[t].getHeightInterval().x
                && height <= terrains[t].getHeightInterval().y)
                return terrains[t];
        }
        Debug.LogError("ERROR, HEIGHT ASSIGNED TO NULL (val:" + height + ").");
        return null;
    }
    
    
    public Color assignHeightToColour(float height) {
        TerrainType terrain = assignHeightToTerrain(height);
        return Color.Lerp(terrain.getColorInterval()[0], terrain.getColorInterval()[1], height);
    }    
    

}
