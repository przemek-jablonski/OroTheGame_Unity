using UnityEngine;
using System.Collections.Generic;

public class CellularAutomataScript : MonoBehaviour {

	public  GameObject	groundPrefab;
	public  GameObject  boxPrefab;
	
	public  Vector2		mapSizeVector;
	public  Vector3		mapStartingPosition;
	
	[Range (1,20)]
	public  int			iterationCount = 5;
	[Range (1,100)]
	public  int			birthChance = 50;
	
	[Range (0,8)]
	public int 			limitDeath = 4;
	[Range (0,8)]
	public int 			limitBirth = 3;
	

	[Range (0,100)]
	public float		boxSizePercentage = 100;

	private  float 		groundSideLength;
	private  float		boxSideLength;
	
	//references:

    
	//appearedBoxesArray - initialized firstly to false
	//then converted to true if box appeared
	private  bool 	[,]	appearedBoxesArray;
	
	private  short	[,] populationArray;
	
	//should be queue of objects (from bottom to top?!)
	private  CellularAutomataEnum [,] enumRepresentation;
    private  GameObject layerBoxes;
	private  GameObject generatedMap = null;
	private  GameObject layerGround;
    
    
    private  List<GameObject> spawnedBoxes;
    private  List<GameObject> spawnedGround;
	
	public void Cycle() {
		Debug.Log("cycle()");
		
		generatedMap = new GameObject("Generated Map");
		layerGround = new GameObject("Ground Layer");
        layerBoxes = new GameObject("Boxes Layer");
		
		//set objects ('folders') hierarchy:
        layerGround.transform.parent = generatedMap.transform;
        layerBoxes.transform.parent = generatedMap.transform;
        
        //get map unit of measurement:
		groundSideLength = groundPrefab.transform.localScale.x;
        boxSideLength = boxPrefab.transform.localScale.x * (boxSizePercentage/100);
		
		
		GenerateEnumRepresentationArray();
		GenerateBoxes();
		PrintEnumRep();
		InstantiateEnumRepresentation();
	}
	
    private void Instantiate(){
        generatedMap = new GameObject("Generated Map");
		layerGround = new GameObject("Ground Layer");
        layerBoxes = new GameObject("Boxes Layer");
		
		//set objects ('folders') hierarchy:
        layerGround.transform.parent = generatedMap.transform;
        layerBoxes.transform.parent = generatedMap.transform;
        
        //get map unit of measurement:
		groundSideLength = groundPrefab.transform.localScale.x;
        boxSideLength = boxPrefab.transform.localScale.x * (boxSizePercentage/100);
    }
	
	public void GenerateEnumRepresentationArray() {
        Instantiate();
        
		Debug.Log("1");
        Debug.Log("array: " + mapSizeVector);
		enumRepresentation = new CellularAutomataEnum [(int)mapSizeVector.x, (int)mapSizeVector.y];
		
		for (int x = 0; x < mapSizeVector.x; ++x) 
			for (int y = 0; y < mapSizeVector.y; ++y) 
				enumRepresentation[x,y] = CellularAutomataEnum.Ground;
    }
    
	public void GenerateBoxes() {
		Debug.Log("2");
		for (int x = 0; x < mapSizeVector.x; ++x) 
			for (int y = 0; y < mapSizeVector.y; ++y) {
				
				if (Random.Range(0,100) > birthChance)
					enumRepresentation[x,y] = CellularAutomataEnum.Box;
			}
	}
    
    public void ClearBoxes() {
        
        for (int x = 0; x < mapSizeVector.x; ++x) 
			for (int y = 0; y < mapSizeVector.y; ++y) 
                    if (enumRepresentation[x,y] == CellularAutomataEnum.Box)
                        enumRepresentation[x,y] = CellularAutomataEnum.Ground;
                        
        DestroyImmediate(layerBoxes);
    }
    
    public void DeleteMap() {
        
        for (int x = 0; x < mapSizeVector.x; ++x) 
			for (int y = 0; y < mapSizeVector.y; ++y)
                enumRepresentation[x,y] = CellularAutomataEnum.None;
        
        DestroyImmediate(generatedMap);
    }
	
	public void PrintEnumRep() {
		Debug.Log("3");
		string line = string.Empty;
		
		for (int x = 0; x < mapSizeVector.x; ++x) { 
			for (int y = 0; y < mapSizeVector.y; ++y) {
				if(enumRepresentation[x,y] == CellularAutomataEnum.Ground)
					line += "[G]";
				else
					line += "[B]";
			}
			Debug.Log(line);
			line = string.Empty;
		}
	}
	
	public void InstantiateEnumRepresentation() {
		Debug.Log("4");
        /*
		groundSideLength = groundPrefab.transform.localScale.x;
		boxSideLength = boxPrefab.transform.localScale.x * (boxSizePercentage/100);
		*/
        
          
        //  make it work !!
        /*
        foreach(GameObject gameObject in generatedMap.GetComponents<GameObject>())
            DestroyImmediate(gameObject);
        */
        /*
        foreach(GameObject gameObject in spawnedGround) {
            DestroyImmediate(gameObject);
        }
        
        foreach(GameObject gameObject in spawnedBoxes) {
            DestroyImmediate(gameObject);
        }
        */
        
        DestroyImmediate(generatedMap);
        Instantiate();
        
		
        
		for (int x = 0; x < mapSizeVector.x; ++x) 
			for (int y = 0; y < mapSizeVector.y; ++y){
				
				switch (enumRepresentation[x,y]) {
					case CellularAutomataEnum.Ground:
						InstantiateTileGround(new Vector2(x,y), groundSideLength);
						break;
						
					case CellularAutomataEnum.Box:
						InstantiateTileGround(new Vector2(x,y), groundSideLength);
						InstantiateTileBox(new Vector2(x,y), boxSideLength);
						break;
				
				}
			}
	}
	
	public void InstantiateTileGround(Vector2 coords, float prefabSize) {
		GameObject tile = Instantiate(
                        groundPrefab,
                        new Vector3(mapStartingPosition.x + coords.x * prefabSize + prefabSize/2,
                                    mapStartingPosition.y,
                                    mapStartingPosition.z + coords.y * prefabSize + prefabSize/2),
                        Quaternion.Euler(Vector3.right * 90)
				) as GameObject;
			
                spawnedGround.Add(tile);
				tile.name = GenerateEntityString("Ground", (int)coords.x, (int)coords.y);
				tile.transform.parent = layerGround.transform;
	}
	
	public void InstantiateTileBox(Vector2 coords, float prefabSize) {
		GameObject tile = Instantiate(
                        boxPrefab,
                        new Vector3(mapStartingPosition.x + coords.x * prefabSize + prefabSize/2,
                                    mapStartingPosition.y + prefabSize/2,
                                    mapStartingPosition.z + coords.y * prefabSize + prefabSize/2),
                        Quaternion.Euler(Vector3.right * 90)
				) as GameObject;
			
			//	appearedBoxesArray[(int)coords.x,(int)coords.y] = false;
                spawnedBoxes.Add(tile);
				tile.name = GenerateEntityString("Boxes", (int)coords.x, (int)coords.y);
				tile.transform.parent = layerBoxes.transform;
	}
    
    private string GenerateEntityString(string prefix, int coordx, int coordy) {
		string result = prefix + " [";
		
		if(coordx < 10)
			result += "0" + coordx;
		else
			result += coordx;
		result += "|";
		
		if(coordy < 10)
			result += "0" + coordy;
		else
			result += coordy;
		result += "]";
		
				
		return result;
	}
	
	
	/*
	public void newInstantiateMap() {
		//if map is already generated - delete it and go forward
		if (generatedMap)
			DeleteMap();
		
        //unity GameObject instantiation:
		generatedMap = new GameObject("Generated Map");
		layerGround = new GameObject("Ground Layer");
		appearedBoxesArray = new bool [(int)mapSizeVector.x, (int)mapSizeVector.y];
		
        //set objects ('folders') hierarchy:
        layerGround.transform.parent = generatedMap.transform;
        
        //get map unit of measurement:
		groundSideLength = groundPrefab.transform.localScale.x;
		
		//generate (instantiate) map tiles:
		for (int x = 0; x < mapSizeVector.x ; ++x) 
			for (int y = 0; y < mapSizeVector.y; ++y) {
				GameObject tile = Instantiate(
                        groundPrefab,
                        new Vector3(mapStartingPosition.x + x * groundSideLength + groundSideLength/2,
                                    mapStartingPosition.y,
                                    mapStartingPosition.z + y * groundSideLength + groundSideLength/2),
                        Quaternion.Euler(Vector3.right * 90)
				) as GameObject;
			
				appearedBoxesArray[x,y] = false;
				tile.name = GenerateEntityString("Ground", x, y);
				tile.transform.parent = layerGround.transform;
			}
	}
	*/
	
	//lil problem: how to see if tile has box on it?
		// - spawn map as list of x*y objects (Tile[x|y]) and place
			//objects (grass, boxes) under it
		// - create auxilliary array holding info if this tile has box on it
		// - regex and searching for pattern in name of the object
		// - create script which will hold info about what object tile has
			//and it will persist under every tile object
			//(last one sounds kinda stupid.)

/*
	public void InstantiateMap() {
		//if map is already generated - delete it and go forward
		if (generatedMap)
			DeleteMap();
		
        //unity GameObject instantiation:
		generatedMap = new GameObject("Generated Map");
		layerGround = new GameObject("Ground Layer");
		appearedBoxesArray = new bool [(int)mapSizeVector.x, (int)mapSizeVector.y];
		
        //set objects ('folders') hierarchy:
        layerGround.transform.parent = generatedMap.transform;
        
        //get map unit of measurement:
		groundSideLength = groundPrefab.transform.localScale.x;
		
		//generate (instantiate) map tiles:
		for (int x = 0; x < mapSizeVector.x ; ++x) 
			for (int y = 0; y < mapSizeVector.y; ++y) {
				GameObject tile = Instantiate(
                        groundPrefab,
                        new Vector3(mapStartingPosition.x + x * groundSideLength + groundSideLength/2,
                                    mapStartingPosition.y,
                                    mapStartingPosition.z + y * groundSideLength + groundSideLength/2),
                        Quaternion.Euler(Vector3.right * 90)
				) as GameObject;
			
				appearedBoxesArray[x,y] = false;
				tile.name = GenerateEntityString("Ground", x, y);
				tile.transform.parent = layerGround.transform;
			}
	}
	
	public void CellularAutomataInitialStep() {
		
		//instantiate new layer:
		if(!layerBoxes)
			layerBoxes = new GameObject("Box Layer");
		
		//and assign its hierarchy:
		layerBoxes.transform.parent = generatedMap.transform;
		
		//calculate map unit of measurement:
		boxSideLength = boxPrefab.transform.localScale.x;
		
		for (int x = 0 ; x < mapSizeVector.x; ++x) 
			for (int y = 0 ; y < mapSizeVector.y; ++y) 
				if (Random.Range(0,100) < birthChance) {
					GameObject tile = Instantiate(
						boxPrefab,
						new Vector3(mapStartingPosition.x + x * boxSideLength + boxSideLength/2,
									mapStartingPosition.y + boxSideLength/2,
									mapStartingPosition.z + y * boxSideLength + boxSideLength/2),
						Quaternion.identity
					) as GameObject;
					appearedBoxesArray[x,y] = true;
					tile.name = GenerateEntityString("Box", x, y);
					tile.transform.parent = layerBoxes.transform;
				}
	}
	
	
	public void CellularAutomataIteration() {
		populationArray = new short[(int)mapSizeVector.x, (int)mapSizeVector.y];
		bool[,] newAssignedBoxesArray = new bool[(int)mapSizeVector.x, (int)mapSizeVector.y];
		
		for (int x= 0; x < mapSizeVector.x; ++x) 
			for (int y = 0; y < mapSizeVector.y; ++y) {
				 
				populationArray[x,y] = CalculatePopulation(x, y);
				
				if (appearedBoxesArray[x,y]) {
						if (populationArray[x,y] < limitDeath)
							newAssignedBoxesArray[x,y] = false;
						else	
							newAssignedBoxesArray[x,y] = true; 
				}
				else {
						if (populationArray[x,y] > limitBirth)
							newAssignedBoxesArray[x,y] = true;
						else
							newAssignedBoxesArray[x,y] = false;
				}
			}
		
		
		PrintPopulationArray();
	}
	
	private short CalculatePopulation(int coordx, int coordy) {
		int population = 0;
		
		for (int x = (coordx-1); x < (coordx+2); ++x) 
			for (int y = (coordy-1); y < (coordy+2); ++y)  
				if (!(x == coordx && y == coordy)) {
					//if actual coordinate is not on a map, then count as populated
					//(because why the fuck not)
					if (x >= mapSizeVector.x || x < 0 || y >= mapSizeVector.y || y < 0)
						++population;
					else if(appearedBoxesArray[x,y])
							++population;
				}
		
		return (short)population;
	}
	
	private void PrintPopulationArray(){
		string megastring = "";
		
		for (int x=0; x < mapSizeVector.x; ++x) {
			for (int y=0; y < mapSizeVector.y; ++y) {
				megastring += "[" + populationArray[x,y] + "]";
			}
			Debug.Log(megastring);
			megastring = string.Empty;
		}
				
		
	}
	
	public void ResetCellularAutomata() {
		DeleteBoxesLayer();
		CellularAutomataInitialStep();
	}
	
	public void DeleteMap() {
		DeassignAppearedBoxesArray();
		DestroyImmediate(generatedMap);
		
	}
	
	public void DeleteBoxesLayer(){
		DestroyImmediate(layerBoxes);
		DeassignAppearedBoxesArray();
	}
	
	private void DeassignAppearedBoxesArray() {
		for (int x=0; x < mapSizeVector.x; ++x) {
			for (int y = 0; y < mapSizeVector.y; ++y) {
				appearedBoxesArray[x,y] = false;
			}
		}
	}
	
*/
}