using UnityEngine;
using System.Collections;

public class CellularAutomataScript : MonoBehaviour {

	public  GameObject	groundPrefab;
	public  GameObject  boxPrefab;
	
	public  Vector2		mapSize;
	public  Vector3		mapStartingPosition;
	
	[Range (1,25)]
	public  int			iterationCount = 5;
	[Range (1,100)]
	public  int			birthChance = 50;


	private  float 		groundSideLength;
	private  float		boxSideLength;
	private  GameObject generatedMap;
	

	public void CreateMap() {
		if (generatedMap) DeleteMap();
		
		GameObject groundLayer = new GameObject("Ground Layer");
		generatedMap = new GameObject("Generated Map");
		groundLayer.transform.parent = generatedMap.transform;
		groundSideLength = groundPrefab.transform.localScale.x;
		
		for (int x = 0; x < mapSize.x ; ++x) {
			for (int y = 0; y < mapSize.y; ++y) {
				GameObject tile = Instantiate(
					groundPrefab,
					new Vector3(mapStartingPosition.x + x * groundSideLength + groundSideLength/2,
								mapStartingPosition.y,
								mapStartingPosition.z + y * groundSideLength + groundSideLength/2),
					Quaternion.Euler(Vector3.right * 90)
				) as GameObject;
				
				tile.transform.parent = groundLayer.transform;
				tile.name = "Ground (" + x + "/" + y + ")";
			}
		}
	}
	
	public void DeleteMap() {
		DestroyImmediate(generatedMap);
	}
	
	public void SpawnBoxes() {
		boxSideLength = boxPrefab.transform.localScale.x;
		
		GameObject boxLayer = new GameObject("Box Layer");
		boxLayer.transform.parent = generatedMap.transform;
		
		for (int x = 0 ; x < mapSize.x; ++x) {
			for (int y = 0 ; y < mapSize.y; ++y) {
				if (Random.Range(0,100) < birthChance) {
					GameObject tile = Instantiate(
						boxPrefab,
						new Vector3(mapStartingPosition.x + x * boxSideLength + boxSideLength/2,
									mapStartingPosition.y + boxSideLength/2,
									mapStartingPosition.z + y * boxSideLength + boxSideLength/2),
						Quaternion.identity
					) as GameObject;
					tile.name = "box (" + x + "/" + y  + ")";
					tile.transform.parent = boxLayer.transform;
				}
			}
		}
	}

}
