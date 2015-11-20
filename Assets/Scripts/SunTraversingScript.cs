using UnityEngine;
using System.Collections;

public class SunTraversingScript : MonoBehaviour {

	public float			speedModifier = 2;
	private Transform		transformRef;
	
	void Start () {
		transformRef = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		transformRef.up += Vector3.Lerp(transformRef.up, transformRef.up/2, Time.deltaTime * speedModifier);
	}
}
