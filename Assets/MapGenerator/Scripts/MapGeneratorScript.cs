using UnityEngine;
using System.Collections;
using System.Collections.Generic;

class MapGeneratorScript : MonoBehaviour {

	public  GameObject 	groundTilePrefab;
	public  GameObject	boxPrefab;
	public  Vector2 	mapSize;

	public  int			boxesCount = 100;
	public  Vector3 	spawnStartPosition;
	private ArrayList	tileContainer;
	
	private float		tileSideLength;
	private GameObject	generatedMap;
	private GameObject  groundLayer;
	private GameObject  boxLayer;
	private List<Vector2> usedCoordinates = new List<Vector2>();

	public void GenerateMap() {
		generatedMap = new GameObject("Generated Map");
		groundLayer = new GameObject("Ground Layer");
		groundLayer.transform.parent = generatedMap.transform;
		
		tileSideLength = groundTilePrefab.transform.localScale.x;
		
		for (int x = 0; x < mapSize.x ; ++x)
			for (int y = 0; y < mapSize.y; ++y) {
				(Instantiate(groundTilePrefab,
							new Vector3(spawnStartPosition.x + tileSideLength * x, 
										spawnStartPosition.y, 
										spawnStartPosition.z + tileSideLength * y),
							Quaternion.Euler(Vector3.right * 90))  as GameObject).transform.parent = groundLayer.transform;
				
				
			}
	}	
	
	public void SimpleFillWithBoxes() {
		//doesnt fucking work
		/*
		while(usedTiles.Count <= boxesCount){
			Debug.Log("count: " + usedTiles.Count);
			
			Vector2 newTilePosition = new Vector2(Random.Range(0,mapSize.x), Random.Range(0, mapSize.y));
			
			if (EmptyTileCheck(newTilePosition, usedTiles))
				Instantiate(
					boxPrefab, 
					new Vector3(newTilePosition.x, spawnStartPosition.y, newTilePosition.y),
					Quaternion.identity
					);
			else 
				SimpleFillWithBoxes();
		}
		*/
	}
	
	public void EvenSimplerFillWithBoxes(){
		/*
		for (int count = 0; count < boxesCount; ++count) {
			Vector2 newTilePosition = new Vector2(Random.Range(0,mapSize.x), Random.Range(0, mapSize.y));
			
			if (EmptyTileCheck(newTilePosition, usedTiles))
				Instantiate(
					boxPrefab, 
					new Vector3(newTilePosition.x, spawnStartPosition.y, newTilePosition.y),
					Quaternion.identity
					);
		}
		*/
	}
	
	public void LittleMoreComplexFillWithBoxes() {
		
		boxLayer = new GameObject("Box Layer");
		usedCoordinates = new List<Vector2>();
		boxLayer.transform.parent = generatedMap.transform;
		
		while(usedCoordinates.Count <= boxesCount){
			//Debug.Log("count: " + usedCoordinates.Count);
			
			Vector2 newTilePosition = new Vector2(Random.Range(0,mapSize.x), Random.Range(0, mapSize.y));
			
			if (EmptyTileCheck(newTilePosition, usedCoordinates)){
				usedCoordinates.Add(newTilePosition);
				GameObject newTileObject = Instantiate(
					boxPrefab, 
					new Vector3(newTilePosition.x, spawnStartPosition.y + 0.5f, newTilePosition.y),
					Quaternion.identity
					) as GameObject;
				newTileObject.transform.parent = boxLayer.transform;
			}
			else 
				LittleMoreComplexFillWithBoxes();
			
		}
	}
	
	private bool EmptyTileCheck(Vector2 tileToCheck, List<Vector2> usedTiles){
		foreach (Vector2 coordinate in usedTiles) {
			if (tileToCheck.x == coordinate.x && tileToCheck.y == coordinate.y) {
				Debug.Log(tileToCheck + " is in usedTiles");
				return false;
			}
		}
		Debug.Log(tileToCheck + " is not in usedTiles");
		return true;
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
