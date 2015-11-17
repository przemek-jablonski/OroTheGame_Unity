using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterController))]
public class PawnController : MonoBehaviour {

    public int rotationSpeed = 500;
    public int walkSpeed = 5;
    public int runSpeed = 8;

    private CharacterController     characterController;
    private Vector3                 movementVector;
    private Quaternion              targetRotation;
    private Transform               transformRef;


    //gravity 'system'
    private Vector3 gravityVector = new Vector3();


    // Use this for initialization
    void Start () {
        characterController = GetComponent<CharacterController>();
        movementVector = new Vector3(0, 0, 0);
        transformRef = this.transform;
        gravityVector = Vector3.up * -9.81f;
    }
	
	// Update is called once per frame
	void Update () {
        movementVector = new Vector3(Input.GetAxisRaw("MoveHorizontal"), 0, Input.GetAxisRaw("MoveVertical"));

        LookPawn();
        MovePawn();
        /*
                movementVector += gravity;
                movementVector *= walkSpeed;
                characterController.Move(movementVector);
        */

    }
    
    private void LookPawn() {
        if(movementVector != Vector3.zero) {
            targetRotation = Quaternion.LookRotation(movementVector);
            transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
        }
    }
    
    private void MovePawn() {
        movementVector += gravityVector;
        if (Mathf.Abs(movementVector.x) > 0 && Mathf.Abs(movementVector.y) > 0)
            movementVector *= 0.7f;

        movementVector *= walkSpeed;
        characterController.Move(movementVector * Time.deltaTime);
    }
    
}
