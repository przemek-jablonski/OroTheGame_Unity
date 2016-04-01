using UnityEngine;
using System.Collections;

public class OutdoorMapRenderer2DTest : MonoBehaviour {

    public Renderer textureRenderer;
    
    public void DrawTexture(float[,] map) {
        int width = map.GetLength(0);
        int height = map.GetLength(1);
        
        Texture2D texture = new Texture2D(width, height);
        
        Color[] colours = new Color[width * height];
        
        for (int i = 0; i < height; i++)
            for (int j = 0; j < width; j++)
                colours[i*width+j] = Color.Lerp(Color.black, Color.white, map[j,i]);
            
        
        
        texture.SetPixels(colours);
        texture.Apply();
        
        textureRenderer.sharedMaterial.mainTexture = texture;
        textureRenderer.transform.localScale = new Vector3(width, 1, height);
        
        
    }
}
