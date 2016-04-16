

public interface IWrapper {
	//static classes cannot implement interfaces.
	//sheit.

    OroNoises.Noise InstantiateNoise(Vector2Int noiseDimensions);
	OroNoises.Noise InstantiateNoise(int noiseDimensionX, int noiseDimensionY);

    float[,] getNoiseTable();

}