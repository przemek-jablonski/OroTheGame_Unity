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
	
	private Light		shootLight;
	
	public void Start() {
		shootLight = GetComponentInChildren<Light>();
		shootLight.enabled = false;
	}
	
	public void Shoot() {
		
		
		BulletSpawn(Instantiate(bullet, bulletEjectionPoint.transform.position, bulletEjectionPoint.transform.rotation) as GameObject);
		BulletShellSpawn(Instantiate(bulletShell, shellEjectionPoint.transform.position, shellEjectionPoint.transform.rotation) as GameObject);
		PlayWeaponSound();
		StartCoroutine("TurnLightOn");
		
	}
	
	
	private void BulletSpawn(GameObject bullet) {
		
		//creating bullet force as multiplying actual bulletEjectionPoint forward vector
		//by bulletSpeed value. Added Random.Ranges for little more random behaviour 
		bullet.GetComponent<Rigidbody>().AddForce(
				bulletEjectionPoint.transform.forward * (bulletSpeed + Random.Range(-7,7))
				+ new Vector3(Random.Range(-2,2), Random.Range(-3,3), Random.Range(-5,5)));
	}
	
	
	
	private void BulletShellSpawn(GameObject bulletShell) {
		//creating bullet force as multiplying actual shellEjectionPoint forward vector
		//by shellSpeed value. Added Random.Ranges for little more random behaviour 
		bulletShell.GetComponent<Rigidbody>().AddForce(
			shellEjectionPoint.transform.forward * (bulletShellSpeed + Random.Range(-100, 100))
			+ shellEjectionPoint.transform.right * Random.Range(-50, 10));
		
	} 

	
	
	private void PlayWeaponSound() {
		/*
		(in future) here should be system responsible for randomizing sample playback
		(every gun should have multiple samples which playback should be randomized)
		*/
		weaponSound.Play();
	}
	
	IEnumerator TurnLightOn() {
		
		shootLight.enabled = true;
		yield return new WaitForSeconds(0.05f);
		shootLight.enabled = false;
		
	}
	
	
}
