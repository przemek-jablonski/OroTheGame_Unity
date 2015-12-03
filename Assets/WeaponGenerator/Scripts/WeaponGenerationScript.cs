using UnityEngine;
using System.Collections;

public class WeaponGenerationScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void ButtonClick() {
		Debug.Log("WeaponGenerationScript Button pressed!");
	}
	
	public void GenerateReceiver() {
		Instantiate(Resources.Load("WeaponGenerator/Prefabs/Receivers/receiver_m16a2"), transform.position, Quaternion.identity);
		Debug.Log("Instantiated (hopefully) Receiver for m16a2");
	}
}
