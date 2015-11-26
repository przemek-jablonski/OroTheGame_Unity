using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
	
	public float 		bulletKillTime = 3f;
	public float		baseDamage = 3;
	public LayerMask	destroyableMask;
	public GameObject collisionSplashPrefab;
	
	private IDamageable actorHit;
	private Transform 	transformRef;
	private float		bulletSpeed;

	public void Start() {
		actorHit = null;
		transformRef = this.transform;
		//bulletSpeed = this.GetComponent<Rigidbody>().velocity.magnitude;
		StartCoroutine("DestroyBullet");
	}
	
	public void Update() {
		CheckRaycastCollision();
	}
	
	private void CheckRaycastCollision() {
		Ray ray = new Ray (transformRef.position, transformRef.forward);
		RaycastHit raycastHit;
		if(Physics.Raycast(ray, out raycastHit, this.GetComponent<Rigidbody>().velocity.magnitude * Time.deltaTime, destroyableMask, QueryTriggerInteraction.Collide))
			BulletCollided(raycastHit);
	
	}
	
	private void BulletCollided(RaycastHit raycastHit) {
		IDamageable damaged = raycastHit.collider.GetComponent<IDamageable>();
		if (damaged != null) {
			//object which has Damageable interface has been hit
			damaged.HitBehaviour(Random.Range(3,5));
		}
		else {
			//object which is not damageable has been hit
			Instantiate(collisionSplashPrefab, transformRef.position, Quaternion.identity);
		}
		
		Destroy(this.gameObject);
	}
	
	
	private void RaycastCollision(RaycastHit raycastHit) {
		Debug.Log("RAYCAST HIT SOMFYN");
		//raycastHit.collider.GetComponent<IDamageable>().HitBehaviour(2)
		Destroy(this.gameObject);
	}
	
	/*
	public void OnTriggerEnter(Collider collider) {
		if (collider.tag != "Bullet") {
			actorHit = collider.gameObject.GetComponent<IDamageable>();
			if(actorHit != null) actorHit.HitBehaviour(baseDamage + Random.Range(-2,2), collider.gameObject);
			
			Destroy(this.gameObject);
			Instantiate(collisionSplashPrefab, this.transform.position, Quaternion.identity);
		}
	}
	*/
	
	IEnumerator DestroyBullet(){
		yield return new WaitForSeconds(bulletKillTime);
		Destroy(this.gameObject);
	}
	
}
