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

    // [RangeAttribute(0, 1)]
    // public float  	 fillPercent = 0.45f;

    // public int    	iterationCount = 4;
    // public bool 	useCustomRules = false;
    // public int 		

    // public string 	randomSeed = "sample seed";
    // public bool 	randomizeSeed = true;

    private MapGenerator mapGenerator;
    private MockMapRenderer mockMapRenderer;
    private bool[,] map;


    //todo: logic module shouldnt be here i suppose?

    // private bool[,] 		traversableMap;
    // private System.Random 	random;


    //todo: refactor to be able to generate terrain inside editor as well as in-game


	public TerrainIndoorGenerator() {
		if (mapGenerator == null)
        	mapGenerator = gameObject.AddComponent<MapGenerator>();
		if (mockMapRenderer == null)
        	mockMapRenderer = gameObject.AddComponent<MockMapRenderer>();
    }

    public void Start() {
        // random = new System.Random(randomSeed.GetHashCode());
        // if (randomizeSeed) { 
        // 	RandomizeSeed();
        // }

        // CreateMap();
        // DestroyChildren();
        // FillMapRandom();
        // for (int i = 0; i < iterationCount; i++){
        // 	CellularAutomataIteration();
        // }

        //debug 'drawing':
        // CreatePlane();
        // CreateBoxes();


        //todo: create this at the moment of attaching script to object,
        //		not on game start!
        //		maybe in constructor?

        // mapGenerator = gameObject.AddComponent<MapGenerator>();
        // mockMapRenderer = gameObject.AddComponent<MockMapRenderer>();

        DestroyChildren();
        mapGenerator = GetComponent<MapGenerator>();
        mockMapRenderer = GetComponent<MockMapRenderer>();

        mapGenerator.UpdateTerrainDimensions(terrainWidthX, terrainDepthY);
        map = mapGenerator.GenerateMap();
		mockMapRenderer.CreatePlane(terrainWidthX, terrainDepthY);
        mockMapRenderer.CreateBoxes(map, terrainWidthX, terrainDepthY);
    }

	public void Update() {
		if (Input.GetMouseButtonDown(0)) {
            Debug.Log("mouse button 0 down");
			
            DestroyChildren();
			mapGenerator.UpdateTerrainDimensions(terrainWidthX, terrainDepthY);
            map = mapGenerator.IterateMap(1);
            mockMapRenderer.CreatePlane(terrainWidthX, terrainDepthY);
			mockMapRenderer.CreateBoxes(map, terrainWidthX, terrainDepthY);
            // CellularAutomataIteration();
            // DestroyChildren();
            // CreatePlane();
            // CreateBoxes();
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
	
	

	// private void FillMapRandom() { 
	// 	for (int x = 0; x < terrainWidthX; x++) {
	// 	      for (int y = 0; y < terrainDepthY; y++) {
	// 			if (x == 0 || y == 0 || x == terrainWidthX - 1 || y == terrainDepthY - 1) {
	// 				traversableMap [x, y] = false;
	// 			} else {
	// 				traversableMap [x, y] = !Utils.randomBool(fillPercent);
	// 			}
	// 	    }
	// 	}

	// }




	// private void CellularAutomataIteration() {
    //     int neighbours;
    //     for (int x = 0; x < terrainWidthX; ++x) {
	// 		for (int y = 0; y < terrainDepthY; ++y) {
				
	// 			if (x == 0 || y == 0 || x == terrainWidthX-1 || y == terrainDepthY - 1) {
    //                 traversableMap[x, y] = false;
    //             } else {
	// 				// CellularAutomataRulesClassic(x, y, CheckTraversableNeighboursLevel1(x, y));
	// 				CellularAutomataRulesCustom(x, y, CheckTraversableNeighboursLevel1(x, y));	
	// 			}

    //         }
	// 	}
	// }
	
	
	//USE DELEGATE HERE AND INVOKE JUST CELLULARAUTOMATARULES() FROM CELLULARAUTOMATAITERATION() METHOD.
	
	
	// private void CellularAutomataRulesClassic(int coordX, int coordY, int neighbours) {
	// 	//CLASSIC RULES FROM CONWAY'S GAME OF LIFE 
	// 	//if we are looking at a cell that is traversable
	// 	if(traversableMap[coordX, coordY] == true) {
			
    //         if (neighbours < 2 || neighbours > 3) 
    //             traversableMap[coordX, coordY] = false;
			
    //     } else {
	// 		//if we are looking at a cell that is not traversable
    //         if (neighbours == 3) 
    //             traversableMap[coordX, coordY] = true;
    //     }
    // }
	
	
	// private void CellularAutomataRulesCustom(int coordX, int coordY, int neighbours) {
	// 	//CUSTOM RULES
	// 	//if we are looking at a cell that is traversable (alive)
	// 	if(traversableMap[coordX, coordY] == true) {
			
    //         if (neighbours <= 3) 
    //             traversableMap[coordX, coordY] = false;
			
    //     } else {
	// 		//if we are looking at a cell that is not traversable (dead)
    //         if (neighbours > 5) 
    //             traversableMap[coordX, coordY] = true;
    //     }
	// }
	
	private void CellularAutomataRulesInspector(int coordX, int coordY, int neighbours) {
		
	}

	
	// private int CheckTraversableNeighboursLevel1(int coordX, int coordY) {
    //     int neighbours = 0;
    //     for (int x = coordX-1; x <= coordX+1; ++x) {
	// 		for (int y = coordY-1; y <= coordY+1; ++y) {
	// 			if (x == coordX && y == coordY) { 
	// 				continue; 
	// 			}
	// 			if (CheckTraversableNeighbour(x,y) == true) {
    //                 ++neighbours;
    //             }
				
	// 		}
	// 	}
    //     return neighbours;
    // }
	

	// private int CheckDeadNeighboursLevel2(int coordX, int coordY) {
    //     int neighbours = 0;
		
	// 	for (int x = coordX - 2; x < coordX + 2; x++) {
	// 		for (int y = coordY - 2; y < coordY + 2; y++) {	
    //             if (x == coordX && y == coordY) { continue; }
    //             if (CheckDeadNeighbour(coordX, coordY)) { ++neighbours; }
	// 		}
	// 	}

    //     return neighbours;
    // }
	
	
	// private bool CheckDeadNeighbour(int coordX, int coordY) {
	// 	if (coordX <= 0 || coordY <= 0 || coordX >= terrainWidthX || coordY >= terrainDepthY) {
    //         return true;
    //     }
	// 	return obstacleMap[coordX, coordY];
    // }

	// private bool CheckTraversableNeighbour(int coordX, int coordY) {
	// 	if (coordX <= 0 || coordY <= 0 || coordX >= terrainWidthX || coordY >= terrainDepthY) {
    //         return false;
    //     }

    //     return traversableMap[coordX, coordY];
    // }


	// private void RandomizeSeed() {
	// 	randomSeed = (DateTime.Now.Ticks * (UnityEngine.Random.value +1)).ToString();
	// }

	public void OnValidate() {
		if (terrainWidthX < 10)
		    terrainWidthX = 10;
			
		if (terrainDepthY < 10)
			terrainDepthY = 10;
			
		if (terrainHeightZ != 1)
		    terrainHeightZ = 1;
			
		// if (iterationCount < 1)
		//     iterationCount = 1;
			
		// if (randomSeed == string.Empty)
		//     randomSeed = "sample seed";
	}
	
	
	
	// private void CreateBoxes() {
    //     GameObject column;
    //     for (int x = 0; x < terrainWidthX; x++) {
    //         column = new GameObject();
    //         column.transform.parent = this.transform;
    //         column.name = "column: " + x;
    //         for (int y = 0; y < terrainDepthY; y++) {
	// 			if (traversableMap[x,y] == false) {
    //                 UnityEngine.Object box = Instantiate(debugBox, new Vector3(x - terrainWidthX/2, 0, y - terrainDepthY/2), Quaternion.identity);
    //                 ((GameObject)box).transform.parent = column.transform;
    //                 ((GameObject)box).name = "[" + x + "], [" + y + "]";
    //             }
	// 		}
	// 	}
	// }
	
	// private void CreatePlane() {
	// 	GameObject plane = (GameObject) Instantiate(debugFloorPlane, new Vector3(0f, -0.5f, 0f), Quaternion.identity);
    //     plane.transform.parent = this.transform;
    //     plane.transform.localScale = new Vector3(terrainWidthX/10f, 1, terrainDepthY/10f);
    // }
	


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
