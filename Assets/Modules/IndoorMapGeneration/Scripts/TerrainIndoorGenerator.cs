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

	[RangeAttribute(0, 1)]
	public float  	fillPercent = 0.45f;

	public int    	iterationCount = 4;
	public string 	randomSeed = "sample seed";
	public bool 	randomizeSeed = true;


	//todo: logic module shouldnt be here i suppose?
	bool[,] terrain;
	System.Random random;


	//todo: refactor to be able to generate terrain inside editor as well as in-game


	public void Start() {
		random = new System.Random(randomSeed.GetHashCode());
		if (randomizeSeed) { 
			RandomizeSeed();
		}

		CreateMap();
		FillMapRandom();
	}

	public void Update() {
		if (Input.anyKey) {
		      CellularAutomataIteration();
		}
	}

	private void CreateMap() {
		terrain = new bool[terrainWidthX, terrainDepthY];
	}

	private void FillMapRandom() { 
		for (int x = 0; x < terrainWidthX; x++) {
		      for (int y = 0; y < terrainDepthY; y++) {
				if (x == 0 || y == 0 || x == terrainWidthX - 1 || y == terrainDepthY - 1) {
					terrain [x, y] = true;
				} else {
					terrain [x, y] = Utils.randomBool (fillPercent);
				}
		    }
		}

	}

	private void FillMapPerlinNoise() {
		//...
	}

	private void FillMapSimplex() {
		//...
	}

	private void CellularAutomataIteration() {

	}


	private void RandomizeSeed() {
		randomSeed = (DateTime.Now.Ticks * (UnityEngine.Random.value +1)).ToString();
	}


	public void OnValidate() {
		if (terrainWidthX < 10)
		    terrainWidthX = 10;
		if (terrainDepthY < 10)
			terrainDepthY = 10;
		if (terrainHeightZ != 1)
		    terrainHeightZ = 1;
		if (iterationCount < 1)
		    iterationCount = 1;
		if (randomSeed == string.Empty)
		    randomSeed = "sample seed";
	}

	void OnDrawGizmos() {
		//todo: exception here instead of this check?
		if (terrain != null) {
			for (int x = 0; x < terrainWidthX; x ++) {
				for (int y = 0; y < terrainDepthY; y ++) {
					Gizmos.color = (terrain[x,y] == true)?Color.black:Color.white;
					Vector3 pos = new Vector3(-terrainWidthX/2 + x + .5f,0, -terrainDepthY/2 + y+.5f);
					Gizmos.DrawCube(pos,Vector3.one);
				}
			}
		}
	}

}
