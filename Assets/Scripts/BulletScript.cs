using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
	
	public float 		bulletKillTime = 3f;
	public GameObject collisionSplashPrefab;
	
	public void Start() {
		StartCoroutine("DestroyBullet");
	}
	
	public void OnTriggerEnter(Collider collider) {
		if (collider.tag != "Bullet") {
			Destroy(this.gameObject);
			Instantiate(collisionSplashPrefab, this.transform.position, Quaternion.identity);
		}
	}
	
	IEnumerator DestroyBullet(){
		yield return new WaitForSeconds(bulletKillTime);
		Destroy(this.gameObject);
	}
	
}
