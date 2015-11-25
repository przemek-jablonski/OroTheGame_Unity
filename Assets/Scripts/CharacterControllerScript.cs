using UnityEngine;

/*
ModelViewController Design System: CONTROLLER LAYER.
	(decoding player's input and sending it to model layer properly)
*/
public class CharacterControllerScript : MonoBehaviour, IController{


	public  CharacterModelScript 	characterModelScript;
	public 	ControlScheme			controlScheme = ControlScheme.Keyboard;
	public 	enum ControlScheme 		{ Keyboard, KeyboardAndMouse, Gamepad };
	
	private bool					anyAxisTouched;
	private Vector3					mousePosition;
	private HandleAxisDelegate		HandleAxis;
	

	//constructor
	public void Start() {
		Application.targetFrameRate = 60;
		anyAxisTouched = false;
		mousePosition = Vector3.zero;
		
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
	
	delegate void HandleAxisDelegate();
	
	public void HandleAxisKeyboard() {
		
		if (Input.GetAxisRaw("KeyboardAxisHorizontal") != 0 || Input.GetAxisRaw("KeyboardAxisVertical") != 0) {
			anyAxisTouched = true;
			characterModelScript.Look(Input.GetAxisRaw("KeyboardAxisHorizontal"), Input.GetAxisRaw("KeyboardAxisVertical"));
		}
	}
	
	
	public void HandleAxisKeyboardMouse() {
		if (Input.GetAxisRaw("KeyboardAxisHorizontal") != 0 || Input.GetAxisRaw("KeyboardAxisVertical") != 0) {
			anyAxisTouched = true;
		}
		if(Input.mousePosition != Vector3.zero) {
			characterModelScript.Look(Input.mousePosition);
		}
		
	}
	
	
	public void HandleAxisGamepad() {
		
		if (Input.GetAxisRaw("GamepadAxisHorizontal") > 0 || Input.GetAxisRaw("GamepadAxisVertical") > 0)
			characterModelScript.Move(Input.GetAxisRaw("GamepadAxisHorizontal"), 
											Input.GetAxisRaw("GamepadAxisVertical"));
	}
	
	
	public void HandleRunButton() {
		if (Input.GetButton("RunButton"))
			characterModelScript.Run(Input.GetAxisRaw("KeyboardAxisHorizontal"),Input.GetAxisRaw("KeyboardAxisVertical"));
		else
			characterModelScript.Move(Input.GetAxisRaw("KeyboardAxisHorizontal"),Input.GetAxisRaw("KeyboardAxisVertical"));
	}
	
	
	public void HandleShootButton() {
		if (Input.GetButtonDown("ShootButton"))
			characterModelScript.Shoot(true);
		else if(Input.GetButtonUp("ShootButton"))
			characterModelScript.Shoot(false);
	}
	
}
