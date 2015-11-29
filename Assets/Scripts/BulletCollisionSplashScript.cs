using UnityEngine;
using System.Collections;

public class BulletCollisionSplashScript : MonoBehaviour {

	public float			physicsKillTime = 2;
	public float			fadeSpeedModifier = 2;
	public GameObject		splashBoxTemplate;
	
	public int				boxCountMin = 2;
	public int				boxCountMax = 5;
	public float			splashForceMin = 1f;
	public float			splashForceMax = 1.2f;
	public float			splashScaleMin = 1f;
	public float 			splashScaleMax = 2.65f;
	public float			splashRandomMultiplier = 2;
	
	
	
	private GameObject[] 	splashBoxesArray;
	private Vector3			splashCentreVector;
	private Vector3			transformPosition;
	
	private bool 			fadeStarted;
	private float			fadeValue;
	private Color			newFadeColor;
	/*
	
	public void Initialize(Transform bulletHitTransform) {
		Debug.Log("BULLETCOLLSPLASH INITIALIZE()");
		splashCentreVector = -this.transform.forward * Random.Range(splashForceMin, splashForceMax);
		Start();
	}
	*/
	
	public void Start () {
		splashBoxesArray = new GameObject[(int)Random.Range(boxCountMin, boxCountMax)];
		
		transformPosition = this.transform.position;
		
		for (int iter = 0; iter < splashBoxesArray.Length; ++iter) {
			splashBoxesArray[iter] = Instantiate(splashBoxTemplate, transformPosition, Quaternion.Euler(Random.Range(-splashRandomMultiplier * 5, splashRandomMultiplier * 7), Random.Range(-splashRandomMultiplier, splashRandomMultiplier), Random.Range(-splashRandomMultiplier *3, splashRandomMultiplier * 3))) as GameObject;
			splashBoxesArray[iter].GetComponent<Rigidbody>().AddForce(splashCentreVector);
			splashBoxesArray[iter].transform.localScale *= Random.Range(splashScaleMin, splashScaleMax);
		}
		
		StartCoroutine("DestroyBoxPhysics");
		
	}

	IEnumerator DestroyBoxPhysics(){
		yield return new WaitForSeconds(physicsKillTime);
			foreach (GameObject box in this.splashBoxesArray){
				Destroy(box.GetComponent<BoxCollider>());
				Destroy(box.GetComponent<MeshFilter>());
				Destroy(box.GetComponent<Rigidbody>());
			}
			Destroy(this.GetComponent<BulletCollisionSplashScript>());
		}
		
	

}











