using UnityEngine;
using System.Collections;

/*
ModelViewController Design System:
	CONTROLLER LAYER.
	(understanding player's input and sending it to model layer properly)
*/
public class CharacterControllerScript : MonoBehaviour {


	public  CharacterModelScript 	characterModelScript;
	public 	ControlScheme			controlScheme = ControlScheme.Keyboard;
	public 	enum ControlScheme 		{ Keyboard, KeyboardAndMouse, Gamepad };
	
	private bool					anyAxisTouched;
	private HandleAxisDelegate		HandleAxis;
	
	delegate void HandleAxisDelegate();

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
		
		if(anyAxisTouched) HandleRunButton();
		
		anyAxisTouched = false;
	}
	
	
	
	//_________________________________________________
	//CONTROLLER LAYER methods:
	
	
	private void HandleAxisKeyboard() {
		
		if (Input.GetAxisRaw("KeyboardAxisHorizontal") != 0 || Input.GetAxisRaw("KeyboardAxisVertical") != 0){
			anyAxisTouched = true;
			Debug.Log("HandleAxis() as handleaxiskeyboard()");
		}
	}
	
	
	private void HandleAxisKeyboardMouse() {
		//to be done
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
