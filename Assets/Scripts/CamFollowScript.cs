using UnityEngine;
using System.Collections;


public class CamFollowScript : MonoBehaviour {

    public Transform   targetActor;
    public float       camFollowSpeed = 5;

    private Vector3     camInitialPosition;
    private Vector3     camTargetPosition;
    private Transform 	transformRef;

    // Use this for initialization
    void Start () {
        transformRef = this.transform;
        camInitialPosition = transformRef.position;
        camTargetPosition = camInitialPosition;
        
        
    }
	
	// Update is called once per frame
	void Update () {
        camTargetPosition.x = targetActor.position.x + camInitialPosition.x;
        camTargetPosition.z = targetActor.position.z + camInitialPosition.z;
        transformRef.position = Vector3.Lerp(transformRef.position, camTargetPosition, Time.deltaTime * camFollowSpeed);
	}
}
