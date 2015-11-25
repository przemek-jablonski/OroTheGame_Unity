
using UnityEngine;

/*
ModelViewController Design System: CONTROLLER LAYER.
	(decoding player's input and sending it to model layer properly)
*/
public interface IController {

	//constructor
	void Start();
	
	
	/*
	Update():
		- Performing input checks every frame / loop iteration
		- Check(s) of similar type grouped into methods
	*/
	void Update();
	
	
	//_________________________________________________
	//CONTROLLER LAYER methods:
	
	//void HandleAxisDelegate();
	
	void HandleAxisKeyboard();
	
	
	void HandleAxisKeyboardMouse();
	
	
	void HandleAxisGamepad();
	
	
	void HandleRunButton();
	
	
	void HandleShootButton();
	
}
