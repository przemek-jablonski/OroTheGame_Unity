using UnityEngine;
using System.Collections;

public class MapGeneratorScript : MonoBehaviour {

	public GameObject groundQuad;
	public GameObject fillingPrefab;
	public GameObject ground;
	public Vector2 mapSize;
	
	public void Start(){
		MapGeneration();
	}
	
	public void MapGeneration() {
		for (int x = 0; x < mapSize.x; ++x) {
			for (int y = 0 ; y < mapSize.y; ++y) {
				Vector3 tilePosition = new Vector3(-mapSize.x/2 + 0.5f + x, 0 , -mapSize.y/2 + 0.5f + y);
				Instantiate(groundQuad, tilePosition, Quaternion.identity);
			}
		}
	}
}
