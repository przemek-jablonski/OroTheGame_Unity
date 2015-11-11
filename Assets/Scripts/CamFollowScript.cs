using UnityEngine;
using System.Collections;


public class CamFollowScript : MonoBehaviour {
	
	
    public Transform 	targetActor;
    public int 			cameraFollowSpeed = 3;
    public int 			zPositionBack = -3;

    private Vector3 	cameraTargetPosition;
    private Transform 	cameraActualTransform;

    // Use this for initialization
    void Start () {
        cameraActualTransform = transform;
        //targetActor ought to be initialized in editor
        
    }
	
	// Update is called once per frame
	void Update () {
        cameraTargetPosition = new Vector3(targetActor.position.x, cameraActualTransform.position.y, targetActor.position.z + zPositionBack);
        cameraActualTransform.position = Vector3.Lerp(cameraActualTransform.position, cameraTargetPosition, Time.deltaTime * cameraFollowSpeed);
	}
}
