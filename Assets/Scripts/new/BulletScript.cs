using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
	
	public float bulletKillTime = 3f;
	
	public void Start() {
		StartCoroutine("DestroyBullet");
	}
	
	public void OnTriggerEnter(Collider collider) {
		Debug.Log("ontriggerenter");
		Destroy(this.gameObject);
	}
	
	IEnumerator DestroyBullet(){
		yield return new WaitForSeconds(bulletKillTime);
		Destroy(this.gameObject);
	}
	
}
