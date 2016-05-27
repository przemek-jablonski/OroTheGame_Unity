using UnityEngine;
using System;
using System.Collections;
using UnityEditor;
using AssemblyCSharp;

public class TerrainIndoorGenerator : MonoBehaviour {

	//max value of total x coordinates
	public int 		terrainWidthX = 150;
	//max value of total y coordinates
	public int		terrainDepthY = 150;
	//max value of total z coordinates
	public int 		terrainHeightZ = 1;

    public MapGenerator mapGenerator;
    // public MockMapRenderer mockMapRenderer;
    public OroIndoorMapGeneratorModule.MeshGenerator meshGenerator;
    private bool[,] map;

    //todo: refactor (here?) to be able to generate terrain inside editor as well as in-game


	public TerrainIndoorGenerator() {
		// if (mapGenerator == null)
        // 	mapGenerator = gameObject.AddComponent<MapGenerator>();
		// if (mockMapRenderer == null)
        // 	mockMapRenderer = gameObject.AddComponent<MockMapRenderer>();
    }

    public void Start() {

        DestroyChildren();
        mapGenerator = GetComponent<MapGenerator>();
        // mockMapRenderer = GetComponent<MockMapRenderer>();
        meshGenerator = GetComponent<OroIndoorMapGeneratorModule.MeshGenerator>();

        mapGenerator.UpdateTerrainDimensions(terrainWidthX, terrainDepthY);
        map = mapGenerator.GenerateMap();
        
        // mockMapRenderer.CreatePlane(terrainWidthX, terrainDepthY);
        // mockMapRenderer.CreateBoxes(map, terrainWidthX, terrainDepthY);
		meshGenerator.generateMesh(map);
    }

	public void Update() {
		if (Input.GetMouseButtonDown(0)) {
            Debug.Log("mouse button 0 down");
			
            DestroyChildren();
			mapGenerator.UpdateTerrainDimensions(terrainWidthX, terrainDepthY);
            map = mapGenerator.IterateMap(1);
			
            // mockMapRenderer.CreatePlane(terrainWidthX, terrainDepthY);
			// mockMapRenderer.CreateBoxes(map, terrainWidthX, terrainDepthY);
			meshGenerator.generateMesh(map);
        }
		if (Input.GetMouseButtonDown(1)) {
			Debug.Log("mouse button 1 down");
			Start();
		}
	}
	
	private void DestroyChildren() {
		foreach (Transform child in this.transform) {
            Destroy(child.gameObject);
        }
	}

	public void OnValidate() {
		if (terrainWidthX < 10)
		    terrainWidthX = 10;
			
		if (terrainDepthY < 10)
			terrainDepthY = 10;
			
		if (terrainHeightZ != 1)
		    terrainHeightZ = 1;
	}

}
