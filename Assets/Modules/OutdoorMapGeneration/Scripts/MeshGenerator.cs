﻿using UnityEngine;

public static class MeshGenerator {
	
	//mesh boundary dimensions in 2d (x,y)
    
    //minecraft - obczaic algorytm
    
	private static int mapDimensionsX;
	private static int mapDimensionsY;
    
    private static float leftUpperCornerX;
	private static float leftUpperCornerZ;


    public static CustomMesh GenerateTerrainMesh(float[,] heightMap) {
        mapDimensionsX = heightMap.GetLength(0);
		mapDimensionsY = heightMap.GetLength(1);

        leftUpperCornerX = (mapDimensionsX - 1) / -2f;
		leftUpperCornerZ = (mapDimensionsY - 1) / 2f;

        CustomMesh customMesh = new CustomMesh(mapDimensionsX, mapDimensionsY);

        int index = 0;

       /** for (int x = 0; x < mapDimensionsX; ++x) {
			for (int y = 0; y < mapDimensionsY; ++y) {
                // customMesh.addVertice(x, heightMap[x, y], y);
                // customMesh.addUV(x / (float)mapDimensionsX, y / (float)mapDimensionsY);

                customMesh.arrayVertices[index] = new Vector3(leftUpperCornerX + x, heightMap[x, y] * 100f, leftUpperCornerZ - y);
                customMesh.arrayUVs[index] = new Vector2(
                                                    x / (float)mapDimensionsX,
                                                    y / (float)mapDimensionsY);
													
													
                // not considering right and bottom corner of heightmap
                // since triangles are generated for a rectangle which top left vertice 
                // is actual (x,y) values pair from this two loops above.
                // (which is essentially )
                if ((x < mapDimensionsX - 1) && ( y < mapDimensionsY - 1)) {
                    customMesh.addTriangle(
						index, 
						index + mapDimensionsX + 1, 
						index + mapDimensionsX);
					customMesh.addTriangle(
						index + mapDimensionsX + 1, 
						index,
						index + 1);

                }
            }

            ++index;

        } **/
        
        for (int y = 0; y < mapDimensionsY; y++) {
            for (int x = 0; x < mapDimensionsX; x++) {
                
        // for (int y = 0; y < mapDimensionsY; y++) {
            // for (int x = 0; x < mapDimensionsX; x++) {
                

                customMesh.arrayVertices[index] = new Vector3(leftUpperCornerX + x, heightMap[x, y] * 10f, leftUpperCornerZ - y);
                customMesh.arrayUVs[index] = new Vector2(x / (float)mapDimensionsX, x / (float)mapDimensionsY);
                
                if (x < mapDimensionsX -1 && y < mapDimensionsY - 1) {
                    customMesh.addTriangle(index, index + mapDimensionsY + 1, index + mapDimensionsY);
                    customMesh.addTriangle(index + mapDimensionsY + 1, index, index + 1);
                }

                ++index;
            }
        }

        return customMesh;

    }
	
	
	
}
