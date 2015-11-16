using UnityEngine;
using System.Collections;

public class GunScript : MonoBehaviour {
	
	
	public float 		raycastDistance = 50;
	public Color		raycastColor = Color.yellow;
	public float		raycastDuration = 0.5f;
	
	public float 		bulletSpeed = 100f;
	public float		bulletFadeTime = 5;
	
	
	private Ray 		raycast;
	private RaycastHit 	raycastHit;
	private float 		raycastRealDistance;
	
	
//   private LineRenderer tracer;
	public AudioSource  gunSound;
	public Rigidbody 	shell;
	public Rigidbody 	bullet;
	public Transform 	shellEjectionPoint;
	public Transform 	bulletSpawnPoint;

	public void Start(){
		raycastRealDistance = raycastDistance;
	//	tracer = GetComponent<LineRenderer>();
	}

	public void Shoot(){
		
		raycast = new Ray(bulletSpawnPoint.position, bulletSpawnPoint.forward);
		
		if(Physics.Raycast(raycast, out raycastHit, raycastDistance)) raycastRealDistance = raycastHit.distance;
			else raycastRealDistance = raycastDistance;
		
		gunSound.Play();
//		StartCoroutine("RenderTracer");
		//Debug.DrawRay(raycast.origin, raycast.direction * raycastDistance, raycastColor, raycastDuration);
		
		Rigidbody newShell = Instantiate(shell, shellEjectionPoint.position, Quaternion.identity) as Rigidbody;
		newShell.AddForce(shellEjectionPoint.forward * Random.Range(90f, 290f) + bulletSpawnPoint.forward * Random.Range(-15f, 10f));
		
		Rigidbody newBullet = Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation) as Rigidbody;
		newBullet.AddForce(bulletSpawnPoint.forward * 75f);
		StartCoroutine("DestroyBullet", newBullet);
		
	}
	
	IEnumerator DestroyBullet(Rigidbody destroyable){
		yield return new WaitForSeconds(bulletFadeTime);
		Destroy(destroyable);
		
	}


/*	
	IEnumerator RenderTracer() {
		tracer.enabled = true;
		tracer.SetPosition(0, bulletSpawnPosition.position);
		tracer.SetPosition(1, bulletSpawnPosition.position + raycast.direction * raycastRealDistance);
		yield return null;
		tracer.enabled = false;
	}
*/

	
}
