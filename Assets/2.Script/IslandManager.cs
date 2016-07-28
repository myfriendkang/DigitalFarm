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
	float startTime;
	float elapsedTime;
	bool isTrigger;
	bool check;
	float sTime;

	public GameObject ctWindow;
	public GameObject messageMgr;
	public GameObject[] alphaChanel;
	public MessageManager mgr;
	public RectTransform ct_OriginalX;
	bool isMoved = false;
	float init;
	void Start ()
	{
		originalWindowX = ctWindow.GetComponent<RectTransform>().position.x;
		isFloating = true;
		isLeft = false;
		isStart = true;
		isTrigger = false;
		originalY = island.GetComponent<RectTransform> ().position.y;
		originalX = island.GetComponent<RectTransform> ().position.x;
		check = false;

		alphaChanel [0].SetActive (true);
		alphaChanel [1].SetActive (false);
		mgr = messageMgr.GetComponent<MessageManager> ();
		ctWindow.SetActive (false);
	}

	// Update is called once per frame
	void Update ()
	{
		
	  if (Input.GetMouseButton (1) && isLeft == true) {
			isFloating = false;
			isLeft = false;
			ResetCoordinateY (2);
			StartCoroutine ("showBox");
			MoveBackWindowCT ();
			/*
			if (ctWindow.activeSelf) {
				ctWindow.SetActive (false);
			}
			*/
	
		} else if (isFloating == true) {
			DefaultIslandMovement ();
		}
	}
	IEnumerator showBox(){
		yield return new WaitForSeconds (1.5f);
		mgr.ShowMessageBox (0);
		SwapAlphaChannel (1, 0);
	}
	public void OnCTClcik(){
		check = true;
		if (isMoved == false) {
			isMoved = true;
			isLeft = true;
			ResetCoordinateY (1);
			mgr.HideMessageBox (0);
			StartCoroutine ("MoveCTWindowCT");
	
			isStart = false;
			StartCoroutine ("EndAnimation");
		}
	}
	IEnumerator MoveCTWindowCT(){
		ctWindow.SetActive (true);
		yield return new WaitForSeconds (0.5f);
		iTween.MoveTo (ctWindow, iTween.Hash ("x",ct_OriginalX.position.x ,
			"time", 1.5f,
			"delay", 0.0f,
			"easeType", iTween.EaseType.easeInOutExpo));
	}
	void MoveBackWindowCT(){
		iTween.MoveTo (ctWindow, iTween.Hash ("x",originalWindowX ,
			"time", 1.5f,
			"delay", 0.0f,
			"easeType", iTween.EaseType.easeInOutExpo));
	}
	IEnumerator EndAnimation(){
		yield return new WaitForSeconds (1.5f);
		//ctWindow.SetActive (true);
		SwapAlphaChannel (0, 1);
	}

	public void CloseCTWindow(){
		MoveBackWindowCT ();
		MoveCTCenter ();
		mgr.ShowMessageBox (0);

		SwapAlphaChannel (1, 0);
	}

	public void SwapAlphaChannel(int from, int to){
		if (alphaChanel [from].activeSelf) {
			alphaChanel [from].SetActive (false);
			alphaChanel [to].SetActive (true);
		}
	}


	void DefaultIslandMovement ()
	{
		

		if (check == false) {
			startTime += Time.time;
			sTime = Time.time;
		} else {
			sTime =Time.time -  startTime + 1.0f;
		//	sTime = Time.time % startTime - 2.0f;
		}
		island.GetComponent<RectTransform> ().position = new Vector3 (island.GetComponent<RectTransform> ().position.x,
			(originalY + ((float)Math.Sin (sTime * bounceSpeed) * floatStrength)),
			island.GetComponent<RectTransform> ().position.z);
	}


	void MoveCTLeft ()
	{
		iTween.MoveTo (island, iTween.Hash ("x", destination.position.x,
			"time", 1.5f,
			"delay", 0.0f,
			"easeType", iTween.EaseType.easeInOutExpo,
			"oncomplete", "DoFloating",
			"oncompletetarget", this.gameObject));
		
		isMoved = false;
	}


	void MoveCTCenter ()
	{
		iTween.MoveTo (island, iTween.Hash ("x", originalX,
			"time", 1.5f,
			"delay", 0.0f,
			"easeType", iTween.EaseType.easeInOutExpo,
			"oncomplete", "DoFloating",
			"oncompletetarget", this.gameObject));
		check = false;
	}

	void DoFloating ()
	{
		if (isFloating == false) {
			isFloating = true;
		}
	}

	void ResetCoordinateY (int num)
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


}
