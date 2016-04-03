using UnityEngine;
using System.Collections;

public class OutdoorMapRenderer2DTest : MonoBehaviour {

    public Renderer textureRenderer;
    private TerrainTypeCoordinator terrainTypeCoordinator;
    private bool isTerrainGenerated = false;


    public void DrawTexture(float[,] map, FilterMode textureFilering) {
		// if(!isTerrainGenerated) {
            terrainTypeCoordinator = new TerrainTypeCoordinator();
            // isTerrainGenerated = true;
        // }
		
        int width = map.GetLength(0);
        int height = map.GetLength(1);
        
        Texture2D texture = new Texture2D(width, height);
        // texture.filterMode = FilterMode.Point;
		texture.filterMode = textureFilering;


        Color[] colours = new Color[width * height];
        
        for (int i = 0; i < height; i++)
			for (int j = 0; j < width; j++) {

                // colours[i*width+j] = Color.Lerp(Color.black, Color.white, map[j,i]);
                colours[i * width + j] = DrawTerrainColour(map[j, i]);



                if (map[j, i] > 1) colours[i * width + j] = Color.red;
                else if (map[j, i] < 0) colours[i * width + j] = Color.blue;
                
            }

        texture.wrapMode = TextureWrapMode.Clamp;
        texture.SetPixels(colours);
        texture.Apply();
        
        textureRenderer.sharedMaterial.mainTexture = texture;
        textureRenderer.transform.localScale = new Vector3(width, 1, height);
    }
	
	
	
	private void DrawTerrainColours(float[,] map) {
		//...todo
	}
	
	
	
	private Color DrawTerrainColour(float height) {
        return terrainTypeCoordinator.assignHeightToColour(height);
    }
}
