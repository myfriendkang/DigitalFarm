using System;
using UnityEngine;

using System.Collections;

public class IslandManager : MonoBehaviour
{

	public GameObject island;
	public RectTransform destination;
	public float floatStrength = 10;
	public float bounceSpeed = 1;
	private float originalY;
	private float originalX;
	private float originalWindowX;
	private bool isFloating;
	private bool isLeft;
	private float speedValue;
	bool isStart;
	bool isTrigger;


	public GameObject ctWindow;
	public GameObject[] alphaChanel;
	public MessageManager mgr;
	public RectTransform ct_OriginalX;
	bool isMoved = false;
	float init;
	bool cellClick;

	void Start ()
	{
		originalWindowX = ctWindow.GetComponent<RectTransform> ().position.x;
		isFloating = true;
		cellClick = false;
		isLeft = false;
		isStart = true;
		isTrigger = false;
		originalY = island.GetComponent<RectTransform> ().position.y;
		originalX = island.GetComponent<RectTransform> ().position.x;

		alphaChanel [0].SetActive (true);
		alphaChanel [1].SetActive (false);
		ctWindow.SetActive (false);
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButton (1) && isLeft == true) {
			isFloating = false;
			isLeft = false;
			//ResetCoordinateY (2);
			StartCoroutine ("showBox");
			MoveBackWindowCT ();
		} else if (isFloating == true) {
			DefaultIslandMovement ();
		} 
		if (Input.GetMouseButton (1) && cellClick == true) {
			ScaleForCell (0);
			SwapAlphaChannel (1, 0);
			cellClick = false;
		}
	}
	public float smoothTime = 0.5F;
	private Vector3 velocity = Vector3.zero;
	void DefaultIslandMovement ()
	{/*
		float crurentPos = ((float)Math.Sin (Time.time * bounceSpeed));
		Debug.Log (crurentPos);
		if (cellClick == false && crurentPos ==0 ) {
			island.GetComponent<RectTransform> ().position = new Vector3 (island.GetComponent<RectTransform> ().position.x,
				(originalY + ((float)Math.Sin (Time.time * bounceSpeed) * floatStrength)),
				island.GetComponent<RectTransform> ().position.z);
		} else {
			do {
				island.GetComponent<RectTransform> ().position = new Vector3 (island.GetComponent<RectTransform> ().position.x,
					(originalY + ((float)Math.Sin (Time.time * bounceSpeed) * floatStrength)),
					island.GetComponent<RectTransform> ().position.z);
			} while(crurentPos == 0);
		}
		*/
		float crurentPos = ((float)Math.Sin (Time.time * bounceSpeed));
		if (cellClick == false) {
			Debug.Log("before = " + (float)Math.Sin (Time.time * bounceSpeed) * floatStrength);
			island.GetComponent<RectTransform> ().position = new Vector3 (island.GetComponent<RectTransform> ().position.x,
				(originalY + ((float)Math.Sin (Time.time * bounceSpeed) * floatStrength)),
				island.GetComponent<RectTransform> ().position.z);
		} 
		if (cellClick == true) {
			
			Vector3 resetPos = new Vector3 (island.GetComponent<RectTransform> ().position.x, originalY, island.GetComponent<RectTransform> ().position.z); 
			if( island.GetComponent<RectTransform> ().position.y != originalY) {
				Debug.Log ("dfasdfasd");
				island.GetComponent<RectTransform> ().position = Vector3.SmoothDamp (island.GetComponent<RectTransform> ().position, resetPos, ref velocity, smoothTime);
			} 
		}

	}
	public void OnCTClcik ()
	{
		if (isMoved == false) {
			isMoved = true;
			isLeft = true;
			cellClick = true;
			//ResetCoordinateY (1);
			MoveCTLeft();
			mgr.HideMessageBox (0);
			StartCoroutine ("MoveCTWindowCT");

			isStart = false;
			StartCoroutine ("EndAnimation");
		}
	}

	public void MoveCTLeft ()
	{
		iTween.MoveTo (island, iTween.Hash ("x", destination.position.x,
			"time", 1.5f,
			"delay", 0.0f,
			"easeType", iTween.EaseType.easeInOutExpo,
			"oncomplete", "DoFloating",
			"oncompletetarget", this.gameObject));
		isMoved = false;

	}


	public void MoveCTCenter ()
	{
		iTween.MoveTo (island, iTween.Hash ("x", originalX,
			"time", 1.5f,
			"delay", 0.0f,
			"easeType", iTween.EaseType.easeInOutExpo,
			"oncomplete", "DoFloating",
			"oncompletetarget", this.gameObject));


	}

	public  void DoFloating ()
	{
		if (isFloating == false) {
			cellClick = false;
			isFloating = true;
		}
	}


	IEnumerator showBox ()
	{
		yield return new WaitForSeconds (1.5f);
		mgr.ShowMessageBox (0);
		SwapAlphaChannel (1, 0);
	}


	IEnumerator MoveCTWindowCT ()
	{
		ctWindow.SetActive (true);
		yield return new WaitForSeconds (0.5f);
		iTween.MoveTo (ctWindow, iTween.Hash ("x", ct_OriginalX.position.x,
			"time", 1.5f,
			"delay", 0.0f,
			"easeType", iTween.EaseType.easeInOutExpo));
	}

	void MoveBackWindowCT ()
	{
		iTween.MoveTo (ctWindow, iTween.Hash ("x", originalWindowX,
			"time", 1.5f,
			"delay", 0.0f,
			"easeType", iTween.EaseType.easeInOutExpo));
	}

	IEnumerator EndAnimation ()
	{
		yield return new WaitForSeconds (1.5f);
		SwapAlphaChannel (0, 1);
	}

	public void CloseCTWindow ()
	{
		MoveBackWindowCT ();
		MoveCTCenter ();
		mgr.ShowMessageBox (0);

		SwapAlphaChannel (1, 0);
	}

	public void SwapAlphaChannel (int from, int to)
	{
		if (alphaChanel [from].activeSelf) {
			alphaChanel [from].SetActive (false);
			alphaChanel [to].SetActive (true);
		}
	}

	public void ResetCoordinateY (int num)
	{
		if (num == 1) {
			
			iTween.MoveTo (island, iTween.Hash ("y", originalY,
				"time", .5f,
				"delay", 0.0f,
				"easeType", iTween.EaseType.easeInSine,
				"oncomplete", "MoveCTLeft",
				"oncompletetarget", this.gameObject));
		} else if (num == 2) {
			iTween.MoveTo (island, iTween.Hash ("y", originalY,
				"time", .5f,
				"delay", 0.0f,
				"easeType", iTween.EaseType.easeInSine,
				"oncomplete", "MoveCTCenter",
				"oncompletetarget", this.gameObject));
		}
	}
	public void ScaleForCell(int i){
		cellClick = true;
		if (i != 0) {
			mgr.HideMessageBox (0);
		}
		switch (i) {
		case 0:
			iTween.MoveTo (island, iTween.Hash ("x", originalX,"y",originalY,
				"time", .5f,
				"easeType", iTween.EaseType.easeInOutSine,
				"oncomplete", "TimeToRest",
				"oncompletetarget", this.gameObject));

			break;

		case 1:
			iTween.MoveTo (island, iTween.Hash ("x", 500,
				"time", .5f,
				"easeType", iTween.EaseType.easeInOutSine,
				"oncomplete", "TimeToScale",
				"oncompletetarget", this.gameObject));
			break;
		case 2:
			iTween.MoveTo (island, iTween.Hash ("x", 60,"y",-200,
				"time", .5f,
				"easeType", iTween.EaseType.easeInOutSine,
				"oncomplete", "TimeToScale",
				"oncompletetarget", this.gameObject));
			break;
		case 3:
			iTween.MoveTo (island, iTween.Hash ("x", 395,"y",-280,
				"time", .5f,
				"easeType", iTween.EaseType.easeInOutSine,
				"oncomplete", "TimeToScale",
				"oncompletetarget", this.gameObject));
			break;
		case 4:
			iTween.MoveTo (island, iTween.Hash ("x", 180,"y",10,
				"time", .5f,
				"easeType", iTween.EaseType.easeInOutSine,
				"oncomplete", "TimeToScale",
				"oncompletetarget", this.gameObject));
			break;
		case 5:
			iTween.MoveTo (island, iTween.Hash ("x", 530,"y",-160,
				"time", .5f,
				"easeType", iTween.EaseType.easeInOutSine,
				"oncomplete", "TimeToScale",
				"oncompletetarget", this.gameObject));
			break;
		}
	
	}
	void TimeToScale(){
		iTween.ScaleTo (island, new Vector3 (2f, 2f, 2f), 3f);

	}
	void TimeToRest(){
		iTween.ScaleTo (island, new Vector3 (1f, 1f, 1f), 1.5f);
		mgr.ShowMessageBox (0);
	}


}
