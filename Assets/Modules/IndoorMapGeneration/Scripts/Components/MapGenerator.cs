using System;
using UnityEngine;
using AssemblyCSharp;

public class MapGenerator : MonoBehaviour {
	
	[RangeAttribute(0, 1)]
	public float  	 fillPercent = 0.45f;
	
	[RangeAttribute(1, 14)]
    public int 		iterationCount = 4;

    public bool customRules = true;
    public string randomSeed = "indoors";
    public bool useRandomSeed = false;


    //traversableMap - terrain values:
    //true - traversable terrain; false - non traversable
    private bool[,] traversableMap;
    private System.Random random;

    private int terrainWidthX;
    private int terrainDepthY;


    public MapGenerator() {
		random = new System.Random(randomSeed.GetHashCode());
    }
	
	public void UpdateTerrainDimensions(int terrainWidthX, int terrainDepthY) {
		this.terrainWidthX = terrainWidthX;
        this.terrainDepthY = terrainDepthY;
	}
	
	public bool[,] GenerateMap() {
		if (useRandomSeed)
            randomSeed = Utils.randomSeedString();

        InstantiateMap();
        FillMapRandomly();
        return traversableMap;
    }
	
	
	public bool[,] IterateMap(int iterations) {
        for (int i = 0; i < iterations; ++i) {
            CellularAutomataIteration();
        }
        return traversableMap;
    }

	private void InstantiateMap() {
        traversableMap = new bool[terrainWidthX, terrainDepthY];
    }

	private void FillMapRandomly() {		
		for (int x = 0; x < terrainWidthX; x++) 
			for (int y = 0; y < terrainDepthY; y++) 
				if (x == 0 || y == 0 || x == terrainWidthX - 1 || y == terrainDepthY - 1) 
					traversableMap [x, y] = false;
				else
					traversableMap [x, y] = !Utils.randomBool(fillPercent);
	}
	
	
	private void FillMapPerlinNoise() {/**...*/}

	private void FillMapSimplex() {/**...*/}

	private void CellularAutomataIteration() {
        for (int x = 0; x < terrainWidthX; ++x) {
			for (int y = 0; y < terrainDepthY; ++y) {				
				if (x == 0 || y == 0 || x == terrainWidthX-1 || y == terrainDepthY - 1) {
                    traversableMap[x, y] = false;
                } else {
					if (customRules)
						CellularAutomataRulesCustom(x, y, CheckTraversableNeighboursLevel1(x, y));
					else 
						CellularAutomataRulesClassic(x, y, CheckTraversableNeighboursLevel1(x, y));
				}
            }
		}
	}
	
	private int CheckTraversableNeighboursLevel1(int coordX, int coordY) {
        int neighbours = 0;
        for (int x = coordX-1; x <= coordX+1; ++x) {
			for (int y = coordY-1; y <= coordY+1; ++y) {
				if (x == coordX && y == coordY) { 
					continue; 
				}
				if (CheckTraversableNeighbour(x,y) == true) {
                    ++neighbours;
                }
			}
		}
        return neighbours;
    }	
	
	private bool CheckTraversableNeighbour(int coordX, int coordY) {
		if (coordX <= 0 || coordY <= 0 || coordX >= terrainWidthX || coordY >= terrainDepthY) {
            return false;
        }
        return traversableMap[coordX, coordY];
    }


    //USE DELEGATE HERE AND INVOKE JUST CELLULARAUTOMATARULES() FROM CELLULARAUTOMATAITERATION() METHOD.

	private void CellularAutomataRulesClassic(int coordX, int coordY, int neighbours) {
		//CLASSIC RULES FROM CONWAY'S GAME OF LIFE 
		//if we are looking at a cell that is traversable
		if(traversableMap[coordX, coordY] == true) {	
            if (neighbours < 2 || neighbours > 3) 
                traversableMap[coordX, coordY] = false;
        } else {
			//if we are looking at a cell that is not traversable
            if (neighbours == 3) 
                traversableMap[coordX, coordY] = true;
        }
    }
	
	private void CellularAutomataRulesCustom(int coordX, int coordY, int neighbours) {
		//CUSTOM RULES
		//if we are looking at a cell that is traversable (alive)
		if(traversableMap[coordX, coordY] == true) {
            if (neighbours <= 3) 
                traversableMap[coordX, coordY] = false;
        } else {
			//if we are looking at a cell that is not traversable (dead)
            if (neighbours > 5) 
                traversableMap[coordX, coordY] = true;
        }
	}
	
	private void CellularAutomataRulesInspector(int coordX, int coordY, int neighbours) {
		
	}
	
	
    public bool[,] GetTraversableMap() {
        return traversableMap;
    }

	public void OnValidate() {
		if (randomSeed.Length == 0) {
            randomSeed = "indoors";
        }
	}

}