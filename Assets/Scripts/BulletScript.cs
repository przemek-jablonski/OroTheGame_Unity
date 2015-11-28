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
		if(Physics.Raycast(ray, out raycastHit, this.GetComponent<Rigidbody>().velocity.magnitude * 0.033f, destroyableMask, QueryTriggerInteraction.Collide))
			BulletCollided(raycastHit);
	
	}
	
	private void BulletCollided(RaycastHit raycastHit) {
		IDamageable damaged = raycastHit.collider.GetComponent<IDamageable>();
		if (damaged != null) {
			//object which has Damageable interface has been hit
			damaged.Hit(Random.Range(1,4));
		}
		else {
			//object which is not damageable has been hit
			Instantiate(collisionSplashPrefab, transformRef.position, Quaternion.identity);
		}
		
		Destroy(this.gameObject);
	}
	
	IEnumerator DestroyBullet(){
		yield return new WaitForSeconds(bulletKillTime);
		Destroy(this.gameObject);
	}
	
}
