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
	private  GameObject generatedMap;
	
	private void CalculateGroundTileSideLength() {
		groundSideLength = groundPrefab.transform.localScale.x;
	}

	public void CreateMap() {
		if (generatedMap)
			DeleteMap();
		
		generatedMap = new GameObject("Generated Map");
		
		for (int x = 0; x < mapSize.x ; ++x) {
			for (int y = 0; y < mapSize.y; ++y) {
				(Instantiate(
					groundPrefab,
					new Vector3(mapStartingPosition.x + x * groundSideLength,
								mapStartingPosition.y,
								mapStartingPosition.z + y * groundSideLength),
					Quaternion.Euler(Vector3.right * 90)
				) as GameObject).transform.parent = generatedMap.transform;
			}
		}
	}
	
	public void DeleteMap() {
		DestroyImmediate(generatedMap);
	}

}
