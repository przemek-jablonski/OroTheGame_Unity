using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterController))]
public class PawnControllerScript : MonoBehaviour {

    public int rotationSpeed = 500;
    public int walkSpeed = 5;
    public int runSpeed = 8;
    public GunScript gunScript;

    private CharacterController     characterController;
    private Camera                  camera;
    
    private Vector3                 movementVector;
    private Quaternion              targetRotation;
    private Transform               transformRef;
    
    private Vector3 mousePosition;


    //gravity 'system'
    private Vector3 gravityVector = new Vector3();


    // Use this for initialization
    void Start () {
        Application.targetFrameRate = 30;
        characterController = GetComponent<CharacterController>();
        movementVector = new Vector3(0, 0, 0);
        transformRef = this.transform;
        gravityVector = Vector3.up * -9.81f;
        
    }
	
	// Update is called once per frame
	void Update () {
        movementVector = new Vector3(Input.GetAxisRaw("MoveHorizontal"), 0, Input.GetAxisRaw("MoveVertical"));
        
        if(Input.GetButtonDown("Shoot"))
            gunScript.Shoot();

        LookPawn();
        MovePawn();
       //   TestMovement();
          
    }
    
    private void TestMovement() {
        /*
       mousePosition = Input.mousePosition;
       mousePosition = camera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y,
                                        camera.transform.position.y - transformRef.position.y));
                                        
           */
       
    }
    
    
    
    private void LookPawn() {
        if(movementVector != Vector3.zero) {
            targetRotation = Quaternion.LookRotation(movementVector);
            transformRef.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
        }
    }
    
    private void MovePawn() {
        
        movementVector *= walkSpeed;
        movementVector += gravityVector;
        if (Mathf.Abs(movementVector.x) > 0 && Mathf.Abs(movementVector.y) >0 ) movementVector *= 0.7f;
        
        characterController.Move(movementVector * Time.deltaTime);
    }
    
}
