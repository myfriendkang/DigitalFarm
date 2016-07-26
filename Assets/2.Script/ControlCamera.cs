using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlCamera : MonoBehaviour {

	public Camera mainCamera;
	public Transform[] targetObjs;
	public float smoothTime = 2F;
	public Sprite[] images;
	private Vector3 velocity = Vector3.zero;
	public GameObject displayInfo;
	public GameObject placeholderImage;
	private bool _isReady;
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
		targetPosition2 = new Vector3 (-38, 140, -236);
		targetPosition3 = new Vector3 (-117f, 140, -236);
		targetPosition4 = new Vector3 (-31f, 35.7f, -236);
	    targetPosition5 = new Vector3 (-163.4f, 89.7f, -236);
	}	

	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (1)) {
			DefaultCameraPos ();
			if (displayInfo.activeSelf) {
				displayInfo.SetActive (false);
			}
		}
		
	}
	public void DefaultCamera(){
		DefaultCameraPos ();
		if (displayInfo.activeSelf) {
			displayInfo.SetActive (false);
		}
	}
	public void FocusObj(int objNum){
		SetDisplayCoordinate (objNum);
		SetImage (objNum);
		if (objNum == 1 ){
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
		_isReady = false;
		if (displayInfo.activeSelf) {
			displayInfo.SetActive (false);
		}
		Vector3 targetPosition = pos;
		while(Vector3.Distance(mainCamera.transform.position, targetPosition)>0.05f){
			if(Vector3.Distance(mainCamera.transform.position, targetPosition) < 20.0f){
				displayInfo.SetActive (true);
				_isReady = true;
			}
			mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position,targetPosition, Time.deltaTime * 2.5f);//Vector3.SmoothDamp (mainCamera.transform.position, targetPosition, ref velocity, smoothTime * Time.deltaTime);
			yield return null;

		}
	}
	void SetDisplayCoordinate(int num){
		float coordX;
		float coordY;
		if (num == 1) {
			coordX = targetPosition1.x + (-50.0f);
			coordY = targetPosition1.y - 10; 
			displayInfo.transform.position = new Vector3 (coordX, coordY, 0);
		} else if (num == 2) {
			coordX = targetPosition2.x + (-50.0f);
			coordY = targetPosition2.y - 10; 
			displayInfo.transform.position = new Vector3 (coordX, coordY, 0);
		} else if (num == 3) {
			coordX = targetPosition3.x + (-50.0f);
			coordY = targetPosition3.y - 10; 
			displayInfo.transform.position = new Vector3 (coordX, coordY, 0);	
		} else if (num == 4) {
			coordX = targetPosition4.x + (-50.0f);
			coordY = targetPosition4.y - 10; 
			displayInfo.transform.position = new Vector3 (coordX, coordY, 0);
		} else if (num == 5) {
			coordX = targetPosition5.x + (-50.0f);
			coordY = targetPosition5.y - 10; 
			displayInfo.transform.position = new Vector3 (coordX, coordY, 0);
		}

		
	}
	void SetImage(int num){
		switch (num) {
		case 1:
			placeholderImage.GetComponent<Image>().sprite = images [0];
			break;
		case 2:
			placeholderImage.GetComponent<Image>().sprite = images [1];
			break;
		case 3:
			placeholderImage.GetComponent<Image>().sprite = images [2];
			break;
		case 4:
			placeholderImage.GetComponent<Image>().sprite = images [3];
			break;
		case 5:
			placeholderImage.GetComponent<Image>().sprite = images [4];
			break;
		}
	}
}
