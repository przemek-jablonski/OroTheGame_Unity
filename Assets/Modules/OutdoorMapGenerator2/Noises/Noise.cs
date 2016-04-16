using UnityEngine;

namespace OroNoises {
    public class Noise  {
        
        public float[,]     noiseTable;
        private int         mapDimensionsX;
        private int         mapDimensionsY;
        private NoiseType   noiseType { get; set; }



        public Noise(Vector2Int mapDimensions) : this((int)mapDimensions.GetVector()[0], (int)mapDimensions.GetVector()[1]){
            
        }
        
        public Noise(int mapDimensionsX, int mapDimensionsY) {
            
            //todo: convert that stuff below into exception wrapper class
            if (mapDimensionsX <= 1 || mapDimensionsY <= 1)
                Debug.LogError("NO CHYBA NIE, PRZESLALES ZA MALY ROZMIAR MAPY");

            //todo: setting type should not be hardcoded - need fix
            noiseType = NoiseType.PERLIN_NOISE;
            
            this.mapDimensionsX = mapDimensionsX;
            this.mapDimensionsY = mapDimensionsY;
            noiseTable = new float[mapDimensionsX, mapDimensionsY];
        }
        
       
        public float[,] GetNoiseTable() {
            return noiseTable;
        } 
        
        
        public void SetNoiseTable(float[,] noiseTable) {
            this.noiseTable = noiseTable;
        } 
        
        public void SetNoiseTableCell(int x, int y, float valueNoise) {
            noiseTable[x, y] = valueNoise;
        }
        
        
        public Vector2Int GetTableDimensions() {
            return new Vector2Int(mapDimensionsX, mapDimensionsY);
        }
        

    }
}