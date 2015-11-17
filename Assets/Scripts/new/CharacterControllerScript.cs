using UnityEngine;

/*
ModelViewController Design System: CONTROLLER LAYER.
	(decoding player's input and sending it to model layer properly)
*/
public class CharacterControllerScript : MonoBehaviour {


	public  CharacterModelScript 	characterModelScript;
	public 	ControlScheme			controlScheme = ControlScheme.Keyboard;
	public 	enum ControlScheme 		{ Keyboard, KeyboardAndMouse, Gamepad };
	
	private bool					anyAxisTouched;
	private HandleAxisDelegate		HandleAxis;
	

	//constructor
	public void Start() {
		anyAxisTouched = false;
		
		//c# delegates (callback) system
		//'overriding' method HandleAxis according to ControlScheme selected
		switch(controlScheme) {
			case ControlScheme.Keyboard:
				HandleAxis = HandleAxisKeyboard;
				break;
			case ControlScheme.KeyboardAndMouse:
				HandleAxis = HandleAxisKeyboardMouse;
				break;
			case ControlScheme.Gamepad:
				HandleAxis = HandleAxisGamepad;
				break;
		}
	}
	
	
	/*
	Update():
		- Performing input checks every frame / loop iteration
		- Check(s) of similar type grouped into methods
	*/
	public void Update() {
		HandleAxis();
		
		if(anyAxisTouched) 
			HandleRunButton();
		
		HandleShootButton();
		
		
		anyAxisTouched = false;
	}
	
	
	
	//_________________________________________________
	//CONTROLLER LAYER methods:
	
	private void HandleShootButton() {
		if (Input.GetButton("ShootButton"))
			characterModelScript.Shoot();
	}
	
	delegate void HandleAxisDelegate();
	
	private void HandleAxisKeyboard() {
		
		if (Input.GetAxisRaw("KeyboardAxisHorizontal") != 0 || Input.GetAxisRaw("KeyboardAxisVertical") != 0){
			anyAxisTouched = true;
			characterModelScript.Look(Input.GetAxisRaw("KeyboardAxisHorizontal"), Input.GetAxisRaw("KeyboardAxisVertical"));
		}
	}
	
	
	private void HandleAxisKeyboardMouse() {
		//to do really soon
	}
	
	
	private void HandleAxisGamepad() {
		
		if (Input.GetAxisRaw("GamepadAxisHorizontal") > 0 || Input.GetAxisRaw("GamepadAxisVertical") > 0)
			characterModelScript.Move(Input.GetAxisRaw("GamepadAxisHorizontal"), 
											Input.GetAxisRaw("GamepadAxisVertical"));
	}
	
	private void HandleRunButton() {
		if (Input.GetButton("RunButton"))
			characterModelScript.Run(Input.GetAxisRaw("KeyboardAxisHorizontal"),Input.GetAxisRaw("KeyboardAxisVertical"));
		else
			characterModelScript.Move(Input.GetAxisRaw("KeyboardAxisHorizontal"),Input.GetAxisRaw("KeyboardAxisVertical"));
	}
	
}
