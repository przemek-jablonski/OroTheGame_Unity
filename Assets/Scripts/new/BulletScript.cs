using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	
	// Use this for initialization
	void Start () {
	
	}
	
	public void OnTriggerEnter(Collider collider) {
		Debug.Log("BULLET: Collision triggered!");
	}
	
}
