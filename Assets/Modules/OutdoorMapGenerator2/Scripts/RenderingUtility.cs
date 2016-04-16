using UnityEngine;
using System.Collections;

public class RenderingUtility : MonoBehaviour {

	public Renderer textureRenderer;
	
	
	public Texture2D CreateNonColourTexture(OroNoises.Noise noise, Vector2Int customScale, FilterMode textureFiltering) {
        Debug.Log("RenderingUtility: CreateNonColourTexture()");

        //    textureRenderer = FindObjectOfType<MeshRenderer>();

        float[,] noiseTable = noise.GetNoiseTable();
        int noiseDimensionX = noise.GetTableDimensions().GetVector()[0];
		int noiseDimensionY = noise.GetTableDimensions().GetVector()[1];

        Texture2D texture = new Texture2D(noiseDimensionX, noiseDimensionY);
        Color[] pixels = new Color[noiseDimensionX * noiseDimensionY];

        for (int x = 0; x < noiseDimensionX; x++) {
			for (int y = 0; y < noiseDimensionY; y++) {
				
				if (noiseTable[x,y] > 1 || noiseTable[x,y] < 0)
					pixels[x * noiseDimensionY + y] = Color.red;	
				else 
				if (x == 0 || y == 0)
                    pixels[x * noiseDimensionY + y] = Color.green; //testing purposes only
				else
                	pixels[x * noiseDimensionY + y] = Color.Lerp(Color.black, Color.white, noiseTable[x, y]);
					
            }
		}

        texture.filterMode = textureFiltering;
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.SetPixels(pixels);
        texture.Apply();

        // textureRenderer.material.mainTexture = texture;
        textureRenderer.sharedMaterial.mainTexture = texture;
        textureRenderer.transform.localScale = new Vector3(customScale.GetVector()[0], 1, customScale.GetVector()[1]);

        return texture;
    }
	
	
	
}