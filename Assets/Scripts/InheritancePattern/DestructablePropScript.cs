using UnityEngine;
using System.Collections;

public class DestructablePropScript : OroLivingActor {

	//new public float startHealth = 20;
	//ddawdawd
	public GameObject lootPouch;
	

	// Use this for initialization
	public override void Start () {
		base.Start();
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
	}
}
