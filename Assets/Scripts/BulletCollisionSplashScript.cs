using UnityEngine;
using System.Collections;

public class BulletCollisionSplashScript : MonoBehaviour {

	public float			physicsKillTime = 2;
	public float			fadeSpeedModifier = 2;
	public GameObject		splashBoxTemplate;
	
	
	private GameObject[] 	splashBoxesArray;
	private Vector3			splashCentreVector;
	private Vector3			transformPosition;
	
	private bool 			fadeStarted;
	private float			fadeValue;
	private Color			newFadeColor;
	
	
	public void Initialize(Transform bulletHitTransform) {
		splashCentreVector = -this.transform.forward * Random.Range(1,1.2f);
		Start();
	}
	
	
	public void Start () {
		splashBoxesArray = new GameObject[(int)Random.Range(2, 5)];
		
		transformPosition = this.transform.position;
		
		for (int iter = 0; iter < splashBoxesArray.Length; ++iter) {
			splashBoxesArray[iter] = Instantiate(splashBoxTemplate, transformPosition, Quaternion.Euler(Random.Range(-25, 45), Random.Range(-5, 5), Random.Range(-15, 15))) as GameObject;
			splashBoxesArray[iter].GetComponent<Rigidbody>().AddForce(splashCentreVector);
			splashBoxesArray[iter].transform.localScale *= Random.Range(1,2.65f);
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











