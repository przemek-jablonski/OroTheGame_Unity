using UnityEngine;
using System.Collections;

public class BulletSplashScript : MonoBehaviour {


	public Rigidbody 	splashBrick;
   private Rigidbody[]	splashBricks;
   private Transform	transformRef;
	// Use this for initialization
	void Start () {
		transformRef = this.transform;
		splashBricks = new Rigidbody[10];
		BrickSpawn();
	}
	
	private void BrickSpawn(){
		for (int i = 0; i < splashBricks.Length; ++i){
			Vector3 positionRandomizer = new Vector3(Random.Range(-2, 2), Random.Range(-4,4), 0);
			//splashBricks[i] = Instantiate(splashBrick, transformRef.position + positionRandomizer, Quaternion.Euler(Random.Range(-100,100), Random.Range(-180, 180), Random.Range(-240, 240)));
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
