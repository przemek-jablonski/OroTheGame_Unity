using UnityEngine;
using System.Collections;

public class BulletCollisionSplashScript : MonoBehaviour {

	public float			physicsKillTime = 5;
	public GameObject		splashBoxTemplate;
	
	
	private GameObject[] 	splashBoxesArray;
	private Vector3			splashCentreVector;
	private Vector3			transformPosition;
	
	
	public void Initialize(Transform bulletHitTransform) {
		splashCentreVector = -this.transform.forward;
		Start();
	}
	
	
	public void Start () {
		splashBoxesArray = new GameObject[(int)Random.Range(1, 3)];
		transformPosition = this.transform.position;
		
		for (int iter = 0; iter < splashBoxesArray.Length; ++iter) {
			splashBoxesArray[iter] = Instantiate(splashBoxTemplate, transformPosition, Quaternion.Euler(Random.Range(-25, 45), Random.Range(-5, 5), Random.Range(-15, 15))) as GameObject;
			splashBoxesArray[iter].GetComponent<Rigidbody>().AddForce(splashCentreVector + new Vector3 (Random.Range(-12, 12), Random.Range(-5, 20), 0));
			splashBoxesArray[iter].transform.localScale *= Random.Range(0.9f,2.5f);
		}
		
		StartCoroutine("DestroyBoxPhysics");
		
	}

	IEnumerator DestroyBoxPhysics(){
		yield return new WaitForSeconds(physicsKillTime);
			foreach (GameObject box in this.splashBoxesArray){
				Destroy(box.GetComponent<BoxCollider>());
				Destroy(box.GetComponent<BoxCollider>());
				Destroy(box.GetComponent<MeshFilter>());
				Destroy(box.GetComponent<Rigidbody>());
			}
			Destroy(this.GetComponent<BulletCollisionSplashScript>());
		}
	

}
