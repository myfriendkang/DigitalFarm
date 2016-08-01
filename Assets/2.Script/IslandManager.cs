using System;
using UnityEngine;
using UnityEngine.UI;
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

	private float speedValue;

	private bool isFloating;
	private bool isLeft; //Message
	public bool cellClick;
	bool ctClicked;
	bool startLeftfloating;
	bool isMoved = false; //lock function
	bool stop = false;
	bool isLeftStop = false;
	public GameObject ctWindow;
	public GameObject[] alphaChanel;
	public MessageManager mgr;
	public RectTransform ct_OriginalX;
	public GameObject cManager;
	public GameObject profile;

	float startTime;
	float tTime;
	bool isReseted ;
	void Start ()
	{
		profile.SetActive (true);
		startTime = 0.0f;
		tTime = 0.0f;
		originalWindowX = ctWindow.GetComponent<RectTransform> ().position.x;
		isFloating = true;
		cellClick = false;
		isLeft = false;
		ctClicked = false;
		startLeftfloating = false;
		originalY = island.GetComponent<RectTransform> ().position.y;
		originalX = island.GetComponent<RectTransform> ().position.x;

		alphaChanel [0].SetActive (true);
		alphaChanel [1].SetActive (false);
		ctWindow.SetActive (false);
		isReseted = false;
	}

	// Update is called once per frame
	void Update ()
	{
		if (ctClicked == true) {
			for (int i = 0; i <= 4; i++) {
				cManager.GetComponent<CellManager> ().greenCells [i].GetComponent<Button> ().interactable = false;
			}
		}
		else{
			for (int i = 0; i <= 4; i++) {
				cManager.GetComponent<CellManager> ().greenCells [i].GetComponent<Button> ().interactable = true;
			}
		}

		if (Input.GetMouseButton (1) && isLeft == true) {

			ctClicked = false; 
			isLeft = false;
			isLeftStop = true;
			resetTpostCT ();
			
			//ResetCoordinateY (2);
			StartCoroutine ("showBox");
			MoveBackWindowCT ();

		}
		/*if (Input.GetMouseButton (1 ) && cellClick == true) {
			Debug.Log ("what");
			ScaleForCell (0);
			SwapAlphaChannel (1, 0);
			cellClick = false;
		}
		*/
		if (cellClick == false) {
			if (startLeftfloating) {

				LeftFloating ();
			} else {
				CenterFloating ();
			}
		}
	}
	void CenterFloating ()
	{
		if (stop == false) {
			startTime += Time.deltaTime;
			island.GetComponent<RectTransform> ().position = new Vector3 (island.GetComponent<RectTransform> ().position.x,
				(originalY + ((float)Math.Sin (startTime * bounceSpeed) * floatStrength)),
				island.GetComponent<RectTransform> ().position.z);
		}
	}


	void LeftFloating(){
		if (isLeftStop == false) {
			tTime = tTime + Time.deltaTime;
			island.GetComponent<RectTransform> ().position = new Vector3 (island.GetComponent<RectTransform> ().position.x,
				(originalY + ((float)Math.Sin (tTime * bounceSpeed) * floatStrength)),
				island.GetComponent<RectTransform> ().position.z);
		}
	}

	public void OnCTClcik ()
	{
		if (isMoved == false) {
			
			isMoved = true;
			isLeft = true;
			stop = true;
			ctClicked = true;
			reseTPost ();
			mgr.HideMessageBox (0);
			StartCoroutine ("MoveCTWindowCT");
			StartCoroutine ("EndAnimation");
		}
	}

	public void MoveCTLeft ()
	{
		iTween.MoveTo (island, iTween.Hash ("x", destination.position.x,"y",originalY,//island.GetComponent<RectTransform>().position.y,
			"time", 1.5f,
			"delay", 0.0f,
			"easeType", iTween.EaseType.easeInOutExpo,
			"oncomplete", "FlagForTransition",
			"oncompletetarget", this.gameObject));
		isMoved = false;


	}


	public void MoveCTCenter ()
	{
		iTween.MoveTo (island, iTween.Hash ("x", originalX,"y",originalY,
			"time", 1.0f,
			"delay", 0.0f,
			"easeType", iTween.EaseType.easeInOutExpo,
			"oncomplete", "FlagForCT",
			"oncompletetarget", this.gameObject));

		StartCoroutine ("ShowProfile");

	}
	IEnumerator ShowProfile(){
		yield return new WaitForSeconds (0.8f);
		profile.SetActive (true);
	}
	void FlagForTransition(){
		tTime = 0;
		isLeftStop = false;
		startLeftfloating = true;
	}
	void FlagForCT(){
		startTime = 0;
		stop = false;
		startLeftfloating = false;
	}
	void resetTpostCT(){
		iTween.MoveTo (island, iTween.Hash ("y",originalY,
			"time", 0.5f,
			"delay", 0.0f,
			"easeType", iTween.EaseType.linear,
			"oncomplete", "MoveCTCenter",
			"oncompletetarget", this.gameObject));
	}

	void reseTPost(){
		iTween.MoveTo (island, iTween.Hash ("y",originalY,
			"time", 0.5f,
			"delay", 0.0f,
			"easeType", iTween.EaseType.easeInOutBack,
			"oncomplete", "MoveCTLeft",
			"oncompletetarget", this.gameObject));
		
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
			"easeType", iTween.EaseType.easeInOutExpo));
	}

	void MoveBackWindowCT ()
	{
		iTween.MoveTo (ctWindow, iTween.Hash ("x", originalWindowX,
			"time", 1.5f,
			"easeType", iTween.EaseType.easeInOutExpo));
	}

	IEnumerator EndAnimation ()
	{
		yield return new WaitForSeconds (1.5f);
		SwapAlphaChannel (0, 1);
		profile.SetActive (false);
	}

	public void CloseCTWindow ()
	{
		resetTpostCT ();
		//tartCoroutine ("What");
		MoveBackWindowCT ();
		for (int i = 0; i <= 4; i++) {
			cManager.GetComponent<CellManager> ().greenCells [i].GetComponent<Button> ().interactable = true;
		}
		ctClicked = false;
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
		
	public void ScaleForCell(int i){
			if (i != 0) {
				mgr.HideMessageBox (0);
			}
			switch (i) {
			case 0:
				iTween.MoveTo (island, iTween.Hash ("x", originalX, "y", originalY,
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
				iTween.MoveTo (island, iTween.Hash ("x", 60, "y", -200,
					"time", .5f,
					"easeType", iTween.EaseType.easeInOutSine,
					"oncomplete", "TimeToScale",
					"oncompletetarget", this.gameObject));
				break;
			case 3:
				iTween.MoveTo (island, iTween.Hash ("x", 395, "y", -280,
					"time", .5f,
					"easeType", iTween.EaseType.easeInOutSine,
					"oncomplete", "TimeToScale",
					"oncompletetarget", this.gameObject));
				break;
			case 4:
				iTween.MoveTo (island, iTween.Hash ("x", 180, "y", 10,
					"time", .5f,
					"easeType", iTween.EaseType.easeInOutSine,
					"oncomplete", "TimeToScale",
					"oncompletetarget", this.gameObject));
				break;
			case 5:
				iTween.MoveTo (island, iTween.Hash ("x", 530, "y", -160,
					"time", .5f,
					"easeType", iTween.EaseType.easeInOutSine,
					"oncomplete", "TimeToScale",
					"oncompletetarget", this.gameObject));
				break;
			}
	}
	void TimeToScale(){
		iTween.ScaleTo (island,iTween.Hash("scale", new Vector3 (2f, 2f, 2f),"time",.5f,
			"easeType", iTween.EaseType.linear));

	}
	void StopItween(){
		iTween.Stop ();
	}
	void TimeToRest(){
		iTween.ScaleTo (island, iTween.Hash("scale", new Vector3 (1f, 1f, 1f),"time",.5f,
			"easeType", iTween.EaseType.linear));
		mgr.ShowMessageBox (0);
	}


}
