using UnityEngine;
using System.Collections;

/*
ModelViewController Design System:
	MODEL LAYER.
	(receives raw input from Controller and translates it
	into character logic)
*/
[RequireComponent (typeof (CharacterController))]
public class CharacterModelScript : MonoBehaviour {

	public float		walkingSpeed = 5;
	public float 		runningSpeed = 7;

	private CharacterController characterController;
	
	private Vector3 	movementVector;
	private Vector3		gravityVector;

	//constructor	
	public void Start () {
		characterController = GetComponent<CharacterController>();
		movementVector = Vector3.zero;
		gravityVector = Vector3.up * -9.81f;
	}
	
	//frame update
	/*
	public void Update () {
	
	}
	*/
	
	
	
	//_________________________________________________
	//MODEL LAYER methods:
	
	/*
	Move():
		- Making character walk to desired position
		- Receives keyboard/gamepad axis input value
		- Translates input value into character desired position 
	*/
	public void Move(float inputX, float inputZ) {
		Debug.Log("inputX: " + inputX + ", inputZ: " + inputZ);
		movementVector.x = inputX;
		movementVector.z = inputZ;
		movementVector.y = gravityVector.y;
		
		if(Mathf.Abs(movementVector.x) > 0 && Mathf.Abs(movementVector.z) >0)
			movementVector *= 0.7f;
		
		movementVector *= walkingSpeed;
		
		characterController.Move(movementVector * Time.deltaTime);
	}
	
	
	/*
	Run():
		- Making character run to desired position
		- Receives keyboard/gamepad axis input value
		- Translates input value into character desired position 
	*/
	public void Run(float inputX, float inputZ) {
		
		movementVector.x = inputX;
		movementVector.z = inputZ;
		movementVector.y = gravityVector.y;
		
		if(Mathf.Abs(movementVector.x) > 0 && Mathf.Abs(movementVector.z) > 0)
			movementVector *= 0.7f;
		
		movementVector *= runningSpeed;
		
		characterController.Move(movementVector * Time.deltaTime);
	}
	
	
	/*
	Look():
		- Make character look (rotate) in certain direction
		- Receive mouse movement
		- OR receive gamepad's right stick movement
		- Translate it to characters rotation
	*/
	public void Look(){
		
	}
	
	
	/*
	Shoot():
		- Force character to shoot his gun
		- Receive shootButton boolean value
		- OR receive gamepad's right trigger force
		- Force gun to shoot missle
	*/
	public void Shoot() {
		
	}
	
	
	/*
	Reload():
		- Make character reload his currently equipped gun
		- Receive no data
		- Reload active gun
	*/
	public void Reload() {
		
	}
	
	
	/*
	SwitchGun():
		- Quickly switch equipped gun
		- Receive switchForwardButton / switchBackwardButton
		- Switch gun to next/previous gun in queue
	*/
	public void SwitchGun() {
		
	}
	
	
	/*
	PeekInventory():
		- Open character's inventory screen
		- Receive no data
		- Pause gameplay (maybe?) and switch to inventory screen
	*/
	public void PeekInventory() {
		
	}
	
	
	/*
	FastTravelToCity():
		- Check if it's possible to fast travel back to city and if so, do it
		- Receive no data
		- Open screen informing of travel cost and whether you agree
	*/
	public void FastTravelToCity() {
		
	}
	
}