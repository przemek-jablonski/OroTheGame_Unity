using UnityEngine;
using System;
using System.Collections;

public class TerrainIndoorGenerator : MonoBehaviour {

      //max value of total x coordinates
      public int 		terrainWidth = 150;
      //max value of total y coordinates
      public int		terrainDepth = 150;
    //max value of total z coordinates
    public int terrainHeight = 1;

    [RangeAttribute(0, 1)]
      public float         fillPercent = 0.4f;

      public int          iterationCount = 4;
      public string 	randomSeed = "sample seed";
      public bool 	      randomizeSeed = true;


      //todo: logic module shouldnt be here i suppose?
      bool[,] terrain;
      System.Random random;


      //todo: refactor to be able to generate terrain inside editor as well as in-game


      public void Start() {
            CreateMap();
            FillMapRandom();
            
            if (randomizeSeed) {
                  RandomizeSeed();
            }

            random = new System.Random(randomSeed.GetHashCode());
      }
      
      public void Update() {
            if (Input.anyKey) {
                  CellularAutomataIteration();
            }
      }
      
      private void CreateMap() {
            terrain = new bool[terrainWidth, terrainHeight];
      }
      
      private void FillMapRandom() { 
            for (int x = 0; x < terrainWidth; x++) {
                  for (int y = 0; y < terrainHeight; y++) {
                        
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
                  if (terrainWidth < 10)
                        terrainWidth = 10;
                  if (terrainHeight < 10)
                        terrainHeight = 10;
                  if (iterationCount < 1)
                        iterationCount = 1;
                  if (randomSeed == string.Empty)
                        randomSeed = "sample seed";
      }
            

}
