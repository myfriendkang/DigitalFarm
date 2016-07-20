using UnityEngine;
using System.Collections;

public class ControlCamera : MonoBehaviour {

	public Camera mainCamera;
	public Transform[] targetObjs;
	public float smoothTime = 2F;
	private Vector3 velocity = Vector3.zero;
	Vector3 originPos;
	Vector3 targetPosition1;
	Vector3 targetPosition2;
	Vector3 targetPosition3;
	Vector3 targetPosition4;
	Vector3 targetPosition5;

	// Use this for initialization
	void Start () {
		originPos = new Vector3 (1,0,-453);
	    targetPosition1 = new Vector3 (-150, 30, -236);
		targetPosition2 = new Vector3 (1, 140, -236);
		targetPosition3 = new Vector3 (-85.6f, 140, -236);
		targetPosition4 = new Vector3 (-12.2f, 35.7f, -236);
	    targetPosition5 = new Vector3 (-128.4f, 89.7f, -236);
	}	

	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (1)) {
			DefaultCameraPos ();
		}
		
	}
	public void FocusObj(int objNum){
		if (objNum == 1) {
			StopAllCoroutines ();
			StartCoroutine ("ChangeMove",targetPosition1);
		} else if (objNum == 2) {
			StopAllCoroutines ();
			StartCoroutine ("ChangeMove",targetPosition2);
		} else if (objNum == 3) {
			StopAllCoroutines ();
			StartCoroutine ("ChangeMove",targetPosition3);
		} else if (objNum == 4) {
			StopAllCoroutines ();
			StartCoroutine ("ChangeMove",targetPosition4);
		} else if (objNum == 5) {
			StopAllCoroutines ();
			StartCoroutine ("ChangeMove",targetPosition5);
		}
	}
    void DefaultCameraPos(){
		StopAllCoroutines ();
		mainCamera.transform.transform.position = originPos;
	}

	IEnumerator ChangeMove(Vector3 pos){
		
		Vector3 targetPosition = pos;
		while(Vector3.Distance(mainCamera.transform.position, targetPosition)>0.05f){
			mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position,targetPosition, Time.deltaTime * 2.5f);//Vector3.SmoothDamp (mainCamera.transform.position, targetPosition, ref velocity, smoothTime * Time.deltaTime);
			yield return null;
		}

	}
}
