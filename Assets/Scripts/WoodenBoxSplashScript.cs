using UnityEngine;
using System.Collections;

public class WoodenBoxSplashScript : MonoBehaviour {

	public float			physicsKillTime = 7.5f;
	public float			fadeSpeedModifier = 2;
	
	public GameObject		woodenShardTemplate1;
	public GameObject		woodenShardTemplate2;
	public GameObject		woodenShardTemplate3;
	public GameObject		woodenShardTemplate4;
	public GameObject		woodenShardTemplate5;
	private GameObject[]	woodenShardTemplateArray;
	
	
	public int				shardsCountMin = 7;
	public int				shardsCountMax = 10;
	public float			splashForceMin = 1f;
	public float			splashForceMax = 1.1f;
	public float			splashScaleMin = 1f;
	public float 			splashScaleMax = 1f;
	public float			splashRandomMultiplier = 1;
	public float			positionRandomizerMin = 1f;
	public float			positionRandomizerMax = 2f;
	public float			rigidForceRandMin = 1f;
	public float			rigidForceRandMax = 2f;
	public float			plankSpawnYMultiplier = 0.5f;
	
	
	
	private GameObject[] 	woodenShardsArray;
	private Vector3			splashCentreVector;
	private Vector3			transformPosition;
	
	private bool 			fadeStarted;
	private float			fadeValue;
	private Color			newFadeColor;
	
	
	public void Initialize(Transform bulletHitTransform) {
		splashCentreVector = this.transform.forward * Random.Range(splashForceMin, splashForceMax);
		woodenShardTemplateArray = new GameObject[5];
		woodenShardTemplateArray[0] = woodenShardTemplate1;
		woodenShardTemplateArray[1] = woodenShardTemplate2;
		woodenShardTemplateArray[2] = woodenShardTemplate3;
		woodenShardTemplateArray[3] = woodenShardTemplate4;
		woodenShardTemplateArray[4] = woodenShardTemplate5;
		Start();
	}
	
	
	public void Start () {
		woodenShardsArray = new GameObject[(int)Random.Range(shardsCountMin, shardsCountMax)];
		woodenShardTemplateArray = new GameObject[5];
		woodenShardTemplateArray[0] = woodenShardTemplate1;
		woodenShardTemplateArray[1] = woodenShardTemplate2;
		woodenShardTemplateArray[2] = woodenShardTemplate3;
		woodenShardTemplateArray[3] = woodenShardTemplate4;
		woodenShardTemplateArray[4] = woodenShardTemplate5;
		
		transformPosition = this.transform.position;
		
		for (int iter = 0; iter < woodenShardsArray.Length; ++iter) {
			woodenShardsArray[iter] = Instantiate(woodenShardTemplateArray[Random.Range(0,4)], 
										//	transformPosition * Random.Range(positionRandomizerMin, positionRandomizerMax), 
										transformPosition * Random.Range(positionRandomizerMin, positionRandomizerMax) + Vector3.up * Random.Range(0f, plankSpawnYMultiplier * 0.6f),
											Quaternion.Euler(Random.Range(-360, 360), 
											Random.Range(-360, 360), Random.Range(-360, 360))) as GameObject;
												
			woodenShardsArray[iter].GetComponent<Rigidbody>().AddForce(splashCentreVector * Random.Range(rigidForceRandMin, rigidForceRandMax)
																	+ Vector3.up * Random.Range(0.5f, plankSpawnYMultiplier));
			woodenShardsArray[iter].transform.localScale *= Random.Range(splashScaleMin, splashScaleMax);
		}
		
		StartCoroutine("DestroyBoxPhysics");
		
	}

	IEnumerator DestroyBoxPhysics(){
		yield return new WaitForSeconds(physicsKillTime);
			foreach (GameObject box in this.woodenShardsArray){
				Destroy(box.GetComponent<BoxCollider>());
				Destroy(box.GetComponent<MeshFilter>());
				Destroy(box.GetComponent<Rigidbody>());
			}
			Destroy(this.GetComponent<WoodenBoxSplashScript>());
		}
		
	

}











