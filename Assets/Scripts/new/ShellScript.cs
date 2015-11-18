using UnityEngine;
using System.Collections;


public class ShellScript : MonoBehaviour {
	
	public float sleepTimer = 1f;

	void OnTriggerEnter(Collider collider){
		
		if (collider.tag == "Ground")
			StartCoroutine("PutShellToSleep");
			
	}
	
	IEnumerator PutShellToSleep() {
		yield return new WaitForSeconds(sleepTimer);
		Destroy(this.GetComponent<Rigidbody>());
		Destroy(this.GetComponent<CapsuleCollider>());
		Destroy(this.GetComponent<BoxCollider>());
		Destroy(this.GetComponent<ShellScript>());
		Destroy(this.GetComponent<MeshFilter>());
	}
	
}
