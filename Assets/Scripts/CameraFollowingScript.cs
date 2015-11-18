using UnityEngine;

public class CameraFollowingScript : MonoBehaviour {

	public GameObject 	targetActor;
	public int			cameraFollowSpeed = 5;
	
	private Transform	transformRef;
	
	private Vector3 	camInitialPosition;
	private Vector3		camTargetPosition;
	
	
	
	void Start () {
		transformRef = this.transform;
		
		camInitialPosition = transformRef.position;
		camTargetPosition = camInitialPosition;
	}
	
	
	void Update () {
		camTargetPosition.x = targetActor.transform.position.x + camInitialPosition.x;
		camTargetPosition.z = targetActor.transform.position.z + camInitialPosition.z;
		//not changing y axis position, because zooming-in or -out is not desired.
		
		transformRef.position = Vector3.Lerp(transformRef.position, camTargetPosition, cameraFollowSpeed * Time.deltaTime);
	}
}
