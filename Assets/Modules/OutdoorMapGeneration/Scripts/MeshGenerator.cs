
public static class MeshGenerator {
	
	//mesh boundary dimensions in 2d (x,y)
	private static int mapDimensionsX;
	private static int mapDimensionsY;
    private static float leftUpperCornerX;
	private static float leftUpperCornerY;
	private static float leftUpperCornerZ;


    public static CustomMesh GenerateTerrainMesh(float[,] heightMap) {
        mapDimensionsX = heightMap.GetLength(0);
		mapDimensionsY = heightMap.GetLength(1);

        leftUpperCornerX = (mapDimensionsX - 1) / -2f;
		leftUpperCornerZ = (mapDimensionsY - 1) / 2f;

        CustomMesh customMesh = new CustomMesh(mapDimensionsX, mapDimensionsY);

        for (int x = 0; x < mapDimensionsX; ++x) {
			for (int y = 0; y < mapDimensionsY; ++y) {
                customMesh.addVertice(x, heightMap[x, y], y);
                customMesh.addUV(x / (float)mapDimensionsX, y / (float)mapDimensionsY);
				
				// not considering right and bottom corner of heightmap
				// since triangles are generated for a rectangle which top left vertice 
				// is actual (x,y) values pair from this two loops above.
				// (which is essentially )
				if ((x < mapDimensionsX - 1) && ( y < mapDimensionsY - 1)) {
                    customMesh.addTriangle(
								customMesh.GetVerticesCount(),
                                customMesh.GetVerticesCount() + mapDimensionsX + 1,
                                customMesh.GetVerticesCount() + mapDimensionsX
								);
                    customMesh.addTriangle(
                                customMesh.GetVerticesCount() + mapDimensionsX + 1,
								customMesh.GetVerticesCount(),
								customMesh.GetVerticesCount() + 1
                                );
                }
            }
		}

        return customMesh;

    }
	
	
	
}
