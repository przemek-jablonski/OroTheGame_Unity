using UnityEngine;
using System.Collections;

[RequireComponent (typeof (NavMeshAgent))]
public class EnemyModelScript : OroLivingActor {
	
	private NavMeshAgent navMeshAgent;
	public Transform 	 targetObject;
	public float		 pathSeekRefresh = 0.30f;
	public GameObject    onHitParticle;
	public GameObject	 enemyDeathSplashPrefab;

	public override void Start () {
		base.Start();
		navMeshAgent = this.GetComponent<NavMeshAgent>();
		StartCoroutine(UpdateNavigation());
	}
	
	
	 public override void HitBehaviour() {
		 Debug.Log("EnemyModelScript.HitBehaviour() called");
		//base.HitBehaviour(damage);
		GameObject particle = Instantiate(onHitParticle, transform.position, Quaternion.identity) as GameObject;
	}
	
	public override void DeathBehaviour(){
		Instantiate(enemyDeathSplashPrefab, transform.position, Quaternion.identity);
	}
	
	IEnumerator UpdateNavigation() {
		while (targetObject.gameObject != null) {
			navMeshAgent.SetDestination(targetObject.position);
			yield return new WaitForSeconds(pathSeekRefresh);
		}
		
	}

	//_________________________________________________
	//MODEL LAYER methods:
	
	/*
	Move():
		- Making character walk to desired position
		- Receives keyboard/gamepad axis input value
		- Translates input value into character desired position 
	*/
	public void Move(float inputX, float inputZ){}
	
	
	/*
	Run():
		- Making character run to desired position
		- Receives keyboard/gamepad axis input value
		- Translates input value into character desired position 
	*/
	public void Run(float inputX, float inputZ){}
	
	
	/*
	Look():
		- Make character look (rotate) in certain direction
		- Receive mouse movement
		- OR receive gamepad's right stick movement
		- Translate it to characters rotation
	*/
	public void Look(float inputX, float inputZ){}
	
	public void Look(Vector3 mousePosition){}
	
	
	/*
	Shoot():
		- Force character to shoot his gun
		- Receive data shootButton up or down value
		- OR receive gamepad's right trigger force
		- Force gun to shoot missle
	*/
	public void Shoot(bool isTriggerPressed){}
	
	
	/*
	Reload():
		- Make character reload his currently equipped gun
		- Receive no data
		- Reload active gun
	*/
	public void Reload(){}
	
	
	/*
	SwitchGun():
		- Quickly switch equipped gun
		- Receive switchForwardButton / switchBackwardButton
		- Switch gun to next/previous gun in queue
	*/
	public void SwitchGun(){}  //?
	
}
