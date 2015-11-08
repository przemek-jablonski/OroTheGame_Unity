using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterController))]
public class PawnController : MonoBehaviour {

    public 

    private CharacterController     characterController;
    private Vector3                 movementVector;
    private Quaternion              targetRotation;


    // Use this for initialization
    void Start () {
        characterController = GetComponent<CharacterController>();
        movementVector = new Vector3(0, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {

        movementVector = new Vector3(Input.GetAxisRaw("MoveHorizontal"), 0, Input.GetAxisRaw("MoveVertical"));
        Debug.Log("x: " + movementVector.x + " | y: " + movementVector.y);
        
        if(movementVector != Vector3.zero){
            targetRotation = Quaternion.LookRotation(movementVector);
            this.transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
        }
        
        
		

    }
}
