using UnityEngine;
using System.Collections;

class MapGeneratorScript : MonoBehaviour {

	public  GameObject 	groundTilePrefab;
	public  Vector2 	mapSize;
	public  Vector3 	spawnStartPosition;
	private ArrayList	tileContainer;
	
	private float		tileSideLength;
	private GameObject	generatedMap;

	public void GenerateMap() {
		generatedMap = new GameObject("Generated Map");
		/*
		GameObject rows = new GameObject("Rows");
		GameObject columns = new GameObject("Columns");	
		*/
		
		/*
		rows.transform.parent = generatedMap.transform.parent;
		columns.transform.parent = generatedMap.transform.parent;
		*/
		
		
		tileContainer = new ArrayList();
		tileSideLength = groundTilePrefab.transform.localScale.x;
		
		for (int x = 0; x < mapSize.x ; ++x)
			for (int y = 0; y < mapSize.y; ++y) {
				GameObject tile = (Instantiate(groundTilePrefab,
							new Vector3(spawnStartPosition.x + tileSideLength * x, 
										spawnStartPosition.y, 
										spawnStartPosition.z + tileSideLength * y),
							Quaternion.Euler(Vector3.right * 90))  as GameObject);
				tile.transform.parent = generatedMap.transform;
				tileContainer.Add(tile);
				
			}
	}	
	
	public void DeleteTiles() {
		DestroyImmediate(generatedMap);
		tileContainer = new ArrayList();
	}
	
	public void CalculateQuadSide() {
		tileSideLength = groundTilePrefab.transform.localScale.x;
		Debug.Log(tileSideLength);
	}

}
