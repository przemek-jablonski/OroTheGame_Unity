using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
	
	public float 		bulletKillTime = 3f;
	public float		baseDamage = 3;
	public GameObject collisionSplashPrefab;
	
	private IDamageable actorHit;
	
	public void Start() {
		actorHit = null;
		StartCoroutine("DestroyBullet");
	}
	
	public void OnTriggerEnter(Collider collider) {
		if (collider.tag != "Bullet") {
			actorHit = collider.gameObject.GetComponent<IDamageable>();
			if(actorHit != null) actorHit.HitBehaviour(baseDamage + Random.Range(-2,2));
			
			Destroy(this.gameObject);
			Instantiate(collisionSplashPrefab, this.transform.position, Quaternion.identity);
		}
	}
	
	IEnumerator DestroyBullet(){
		yield return new WaitForSeconds(bulletKillTime);
		Destroy(this.gameObject);
	}
	
}
