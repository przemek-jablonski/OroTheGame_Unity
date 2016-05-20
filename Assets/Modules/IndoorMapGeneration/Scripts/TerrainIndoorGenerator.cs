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
	public float  	 fillPercent = 0.45f;

	public int    	iterationCount = 4;
	public string 	randomSeed = "sample seed";
	public bool 	randomizeSeed = true;

    public GameObject debugBox;
    public GameObject debugFloorPlane;


    //todo: logic module shouldnt be here i suppose?


    //terrain values:
    //	true - for obstacle
    //	false - for open space (free to roam for the player)
    bool[,] 		obstacleMap;
	System.Random 	random;


	//todo: refactor to be able to generate terrain inside editor as well as in-game


	public void Start() {
		random = new System.Random(randomSeed.GetHashCode());
		if (randomizeSeed) { 
			RandomizeSeed();
		}

        CreateMap();
        DestroyChildren();
        FillMapRandom();
        for (int i = 0; i < iterationCount; i++){
        	CellularAutomataIteration();
        }

		//debug 'drawing':
        CreatePlane();
        CreateBoxes();
    }

	public void Update() {
		if (Input.GetMouseButtonDown(0)) {
            Debug.Log("mouse button 0 down");
            // CellularAutomataIteration();
            Start();
        }
	}

	private void CreateMap() {
		obstacleMap = new bool[terrainWidthX, terrainDepthY];
	}

	private void FillMapRandom() { 
		for (int x = 0; x < terrainWidthX; x++) {
		      for (int y = 0; y < terrainDepthY; y++) {
				if (x == 0 || y == 0 || x == terrainWidthX - 1 || y == terrainDepthY - 1) {
					obstacleMap [x, y] = true;
				} else {
					obstacleMap [x, y] = Utils.randomBool (fillPercent);
				}
		    }
		}

	}


	private void FillMapPerlinNoise() {/**...*/}

	private void FillMapSimplex() {/**...*/}



	private void CellularAutomataIteration() {
		for (int x = 0; x < terrainWidthX; x++) {
			for (int y = 0; y < terrainDepthY; y++) {
				
				if (CheckNeighboursLevel1(x, y) > 4) {
					obstacleMap[x, y] = true;
				}
				if (CheckNeighboursLevel1(x, y) < 3) {
                    obstacleMap[x, y] = false;
                }
				
			}
		}
	}

	
	private int CheckNeighboursLevel1(int coordX, int coordY) {
        int neighbours = 0;
		
        for (int x = coordX-1; x < coordX+1; ++x) {
			for (int y = coordY-1; y < coordY+1; ++y) {
				if (x == coordX && y == coordY) { break; }
				if (CheckNeighbour(coordX, coordY)) { ++neighbours; }
			}
		}

        return neighbours;
    }
	

	private int CheckNeighboursLevel2(int coordX, int coordY) {
        int neighbours = 0;
		
		for (int x = coordX - 2; x < coordX + 2; x++) {
			for (int y = coordY - 2; y < coordY + 2; y++) {	
                if (x == coordX && y == coordY) { break; }
                if (CheckNeighbour(coordX, coordY)) { ++neighbours; }
			}
		}

        return neighbours;
    }
	
	
	private bool CheckNeighbour(int coordX, int coordY) {
		if (coordX <= 0 || coordY <= 0) {
            return true;
        }
		return obstacleMap[coordX, coordY];
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
	
	private void CreateBoxes() {
        GameObject column;

        for (int x = 0; x < terrainWidthX; x++) {
            column = new GameObject();
            column.transform.parent = this.transform;
            column.name = "column: " + x;
            for (int y = 0; y < terrainDepthY; y++) {
				if (obstacleMap[x,y] == true) {
                    UnityEngine.Object box = Instantiate(debugBox, new Vector3(x - terrainWidthX/2, 0, y - terrainDepthY/2), Quaternion.identity);
                    ((GameObject)box).transform.parent = column.transform;
                    ((GameObject)box).name = "[" + x + "], [" + y + "]";
                }
			}
		}
	}
	
	private void CreatePlane() {
		GameObject plane = (GameObject) Instantiate(debugFloorPlane, new Vector3(0f, -0.5f, 0f), Quaternion.identity);
        plane.transform.parent = this.transform;
        plane.transform.localScale = new Vector3(terrainWidthX/10f, 1, terrainDepthY/10f);
    }
	
	private void DestroyChildren() {
		foreach (Transform child in this.transform) {
            Destroy(child.gameObject);
        }
	}

	// void OnDrawGizmos() {
	// 	//todo: exception here instead of this null check?
	// 	if (terrain != null) {
	// 		for (int x = 0; x < terrainWidthX; x ++) {
	// 			for (int y = 0; y < terrainDepthY; y ++) {
	// 				Gizmos.color = (terrain[x,y] == true)?Color.black:Color.white;
	// 				Vector3 pos = new Vector3(-terrainWidthX/2 + x + .5f,0, -terrainDepthY/2 + y+.5f);
	// 				Gizmos.DrawCube(pos,Vector3.one);
	// 			}
	// 		}
	// 	}
	// }

}
