using UnityEngine;
using System.Collections;

public class OutdoorMapRenderer2DTest : MonoBehaviour {

    public Renderer textureRenderer;
	Color colorRed = new Color(1,0,0,1);
	Color colorOrange = new Color(1,0.5f,0.2f,1);
	Color colorBlue = new Color(0,0,1,1);
	Color colorLightBlue = new Color(0,0.5f,0.7f,1);
    
    public void DrawTexture(float[,] map) {
        int width = map.GetLength(0);
        int height = map.GetLength(1);
        
        Texture2D texture = new Texture2D(width, height);
        
        Color[] colours = new Color[width * height];
        
        for (int i = 0; i < height; i++)
			for (int j = 0; j < width; j++) {
				
				if(map[j,i] >= 1) 
					colours[i*width+j] = Color.Lerp(colorOrange, colorRed, map[j,i]);
				 else if (map[j,i] <= 0) 
					colours[i*width+j] = Color.Lerp(colorBlue, colorLightBlue, map[j,i]);
				
				 else 
                	colours[i*width+j] = Color.Lerp(Color.black, Color.white, map[j,i]);
			}
            
        
        
        texture.SetPixels(colours);
        texture.Apply();
        
        textureRenderer.sharedMaterial.mainTexture = texture;
        textureRenderer.transform.localScale = new Vector3(width, 1, height);
        
        
    }
}
