using UnityEngine;

/*
ModelViewController Design System: MODEL LAYER.
	(receives raw input from Controller and translates it into character logic)
*/
[RequireComponent (typeof (CharacterController))]
[RequireComponent (typeof (WeaponScript))]
public class CharacterModelScript : MonoBehaviour {

	public float			walkingSpeed = 4.5f;
	public byte 			runningSpeed = 7;
	public ushort			rotationSpeed = 500;
	public Camera			mainCamera;
	

	private CharacterController characterController;
	private WeaponScript	weaponScript;
	private Transform		transformRef;
	
	private Vector3 		movementVector;
	private Vector3			lookVector;
	private Vector3			gravityVector;
	private Quaternion  	characterTargetRotation;
	
	private bool 			actualShot;
	private bool 			previousShot;

	//constructor	
	public void Start () {
		characterController = GetComponent<CharacterController>();
		weaponScript = GetComponentInChildren<WeaponScript>();
		transformRef = this.transform;
		
		movementVector = Vector3.zero;
		gravityVector = Vector3.up * -9.81f;
		characterTargetRotation = Quaternion.identity;
		
		actualShot = false;
		previousShot = false;
	}


	
	
	
	//_________________________________________________
	//MODEL LAYER methods:
	
	/*
	Move():
		- Making character walk to desired position
		- Receives keyboard/gamepad axis input value
		- Translates input value into character desired position 
	*/
	public void Move(float inputX, float inputZ) {
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
		
		//make some crazy ass clever solution, so that code in Move()
		//and in Run() isnt almost exactly the same, goddamnit
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
	public void Look(float inputX, float inputZ) {
		
		movementVector.x = inputX;
		movementVector.y = 0;
		movementVector.z = inputZ;
		characterTargetRotation = Quaternion.LookRotation(movementVector);
		transformRef.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transformRef.eulerAngles.y, characterTargetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
		
	}
	
	public void Look(Vector3 mousePosition) {
		
		lookVector = mousePosition;
		lookVector = mainCamera.ScreenToWorldPoint(new Vector3(lookVector.x, lookVector.y, mainCamera.transform.position.y - transformRef.position.y));
		characterTargetRotation = Quaternion.LookRotation(lookVector - new Vector3(transformRef.position.x, 0, transformRef.position.z));
		transformRef.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transformRef.eulerAngles.y, characterTargetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
		
	}
	
	
	/*
	Shoot():
		- Force character to shoot his gun
		- Receive data shootButton up or down value
		- OR receive gamepad's right trigger force
		- Force gun to shoot missle
	*/
	public void Shoot(bool isTriggerPressed) {
		if (isTriggerPressed) 
			actualShot = true;
		else 
			actualShot = false;
		
		if(actualShot && !previousShot)
			weaponScript.Shoot(); 
			
		previousShot = actualShot;
		actualShot = false;
		
	}
	
	
	/*
	Reload():
		- Make character reload his currently equipped gun
		- Receive no data
		- Reload active gun
	*/
	public void Reload() {
		//to do soon?
	}
	
	
	/*
	SwitchGun():
		- Quickly switch equipped gun
		- Receive switchForwardButton / switchBackwardButton
		- Switch gun to next/previous gun in queue
	*/
	public void SwitchGun() {
		//to do in near future
	}
	
	
	/*
	PeekInventory():
		- Open character's inventory screen
		- Receive no data
		- Pause gameplay (maybe?) and switch to inventory screen
	*/
	public void PeekInventory() {
		//to do next iteration
	}
	
	
	/*
	FastTravelToCity():
		- Check if it's possible to fast travel back to city and if so, do it
		- Receive no data
		- Open screen informing of travel cost and whether you agree
	*/
	public void FastTravelToCity() {
		//to do next iteration
	}
	
}





