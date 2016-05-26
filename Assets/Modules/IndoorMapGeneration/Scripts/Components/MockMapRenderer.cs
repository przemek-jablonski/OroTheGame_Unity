using System;
using UnityEngine;

/**
 *	 
 */
public class MockMapRenderer : MonoBehaviour {
	
	public GameObject debugBox;
    public GameObject debugFloorPlane;

    // public float boxSize;

    public void CreateBoxes(bool[,] traversableMap, int terrainWidthX, int terrainDepthY) {
		GameObject column;
        for (int x = 0; x < terrainWidthX; x++) {
            column = new GameObject();
            column.transform.parent = this.transform;
            column.name = "column: " + x;
            for (int y = 0; y < terrainDepthY; y++) {
				if (traversableMap[x,y] == false) {
                    UnityEngine.Object box = Instantiate(debugBox, new Vector3(x - terrainWidthX/2, 0, y - terrainDepthY/2), Quaternion.identity);
                    ((GameObject)box).transform.parent = column.transform;
                    ((GameObject)box).name = "[" + x + "], [" + y + "]";
                }
			}
		}
	}
	
	public void CreatePlane(int terrainWidthX, int terrainDepthY) {
        GameObject plane = (GameObject)Instantiate(debugFloorPlane, new Vector3(0f, -0.5f, 0f), Quaternion.identity);
		plane.transform.parent = this.transform;
        plane.transform.localScale = new Vector3(terrainWidthX/10f, 1, terrainDepthY/10f);
    }
	
}