using UnityEngine;
using System.Collections;


public class WeaponScript : MonoBehaviour {

	public GameObject 	bullet;
	public GameObject 	bulletShell;
	public GameObject 	bulletEjectionPoint;
	public GameObject 	shellEjectionPoint;
	public AudioSource 	weaponSound;
	
	public byte			bulletSpeed = 100;
	public ushort		bulletShellSpeed = 250;
	public float		bulletKillTime = 2;
	public float		bulletShellSleepTime = 1.2f;
	public ushort 		roundsPerMinute = 120;
	
	private bool		actualShot = false;
	private bool 		previousShot = false;	
	
	
	public void Shoot() {
		
		BulletSpawn(Instantiate(bullet, bulletEjectionPoint.transform.position, bulletEjectionPoint.transform.rotation) as GameObject);
		BulletShellSpawn(Instantiate(bulletShell, shellEjectionPoint.transform.position, shellEjectionPoint.transform.rotation) as GameObject);
		PlayWeaponSound();
		
	}
	
	
	private void BulletSpawn(GameObject bullet) {
		
		//creating bullet force as multiplying actual bulletEjectionPoint forward vector
		//by bulletSpeed value. Added Random.Ranges for little more random behaviour 
		bullet.GetComponent<Rigidbody>().AddForce(
				bulletEjectionPoint.transform.forward * (bulletSpeed + Random.Range(-7,7))
				+ new Vector3(Random.Range(-2,2), Random.Range(-3,3), Random.Range(-5,5)));
					
		//Starting Coroutine which will remove the bullet from the game after bulletKillTime (secs) elapsed
		//(gameplay optimisation related stuff)
		StartCoroutine("DestroyBullet", bullet);
	}
	
	IEnumerator DestroyBullet(GameObject bullet) { 
		yield return new WaitForSeconds(bulletKillTime);
		Destroy(bullet);
	}
	
	
	private void BulletShellSpawn(GameObject bulletShell) {
		//creating bullet force as multiplying actual shellEjectionPoint forward vector
		//by shellSpeed value. Added Random.Ranges for little more random behaviour 
		bulletShell.GetComponent<Rigidbody>().AddForce(
			shellEjectionPoint.transform.forward * (bulletShellSpeed + Random.Range(-100, 100))
			+ shellEjectionPoint.transform.right * Random.Range(-50, 10));
		
		BoxCollider box = bulletShell.GetComponent<BoxCollider>();
		
	//	StartCoroutine("DestroyBulletShellPhysics", bulletShell);
	} 
	
	IEnumerator DestroyBulletShellPhysics(GameObject bulletShell) {
		yield return new WaitForSeconds(bulletShellSleepTime);
		Destroy(bulletShell.GetComponent<Rigidbody>());
	}
	
	
	private void PlayWeaponSound() {
		/*
		(in future) here should be system responsible for randomizing sample playback
		(every gun should have multiple samples which playback should be randomized)
		*/
		weaponSound.Play();
	}
	
	
	
}
