using UnityEngine;
using System.Collections;

public class DestructablePropScript : OroLivingActor {

	//new public float startHealth = 20;
	//ddawdawd
	public GameObject lootPouch;
	public GameObject boxDeathSplashPrefab;
	

	// Use this for initialization
	public override void Start () {
		base.Start();
		Debug.Log("DestructProp start health: " + startHealth + ", actual: " + actualHealth);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public override void HitBehaviour() {
		// none
	}
	
	public override void DeathBehaviour() {
		// spawn some wooden planks
		// spawn loot
		// spawn some smoke effect
		// spawn particle on loot (loot sparkling) but not here anyway
		
		Instantiate(boxDeathSplashPrefab, this.transform.position, Quaternion.identity);
		//Instantiate(lootPouch, this.transform.position, Quaternion.identity);
	}
}
