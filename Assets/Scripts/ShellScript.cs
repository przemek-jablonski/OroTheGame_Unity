using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class ShellScript : MonoBehaviour {

	void OnTriggerEnter(Collider collider){
		
		if (collider.tag == "Ground") 
			StartCoroutine("PutShellToSleep");
			
	}
	
	IEnumerator PutShellToSleep() {
		yield return new WaitForSeconds(1);
		GetComponent<Rigidbody>().Sleep();
	}
	
}
