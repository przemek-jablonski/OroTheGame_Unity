using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class ShellScript : MonoBehaviour {
	
	public float sleepTimer = 1f;

	void OnTriggerEnter(Collider collider){
		
		if (collider.tag == "Ground") 
			StartCoroutine("PutShellToSleep");
			
	}
	
	IEnumerator PutShellToSleep() {
		yield return new WaitForSeconds(sleepTimer);
		GetComponent<Rigidbody>().Sleep();
	}
	
}
