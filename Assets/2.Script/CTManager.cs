using UnityEngine;
using System.Collections;

public class CTManager : MonoBehaviour {

	public GameObject island;

	public GameObject ctWindow;
	public GameObject messageMgr;
	public GameObject[] alphaChanel;
	public MessageManager mgr;

	private Animation anim;
	bool isMoved = false;
	// Use this for initialization
	void Start () {
		alphaChanel [0].SetActive (true);
		alphaChanel [1].SetActive (false);
		anim = island.GetComponent<Animation> () as Animation;
	    mgr = messageMgr.GetComponent<MessageManager> ();
		ctWindow.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (1)) {
			if (isMoved == true) {
				anim.Play ("MovingBackCT");	
				isMoved = false;
				mgr.ShowMessageBox (0);
				if (ctWindow.activeSelf) {
					ctWindow.SetActive (false);
				}
				SwapAlphaChannel (1, 0);
			}
			/*
			if (plantDisplay.activeSelf || observationDisplay.activeSelf) {
				plantDisplay.SetActive(false);
		    	observationDisplay.SetActive (false);
			}
			*/
		}
	}

	public void OnCTClcik(){
		if (isMoved == false) {
			anim.Play ("MovingCT");	
			isMoved = true;
			mgr.HideMessageBox (0);

			StartCoroutine ("EndAnimation");
			//plantDisplay.SetActive (true);
		}
	}

	IEnumerator EndAnimation(){
		yield return new WaitForSeconds (0.8f);
		ctWindow.SetActive (true);
		SwapAlphaChannel (0, 1);
	}

	public void CloseCTWindow(){
		if (ctWindow.activeSelf) {
			ctWindow.SetActive (false);
				if (isMoved == true) {
					anim.Play ("MovingBackCT");	
					isMoved = false;
					mgr.ShowMessageBox (0);
				}
			SwapAlphaChannel (1, 0);
		}
	}

	public void SwapAlphaChannel(int from, int to){
		if (alphaChanel [from].activeSelf) {
			alphaChanel [from].SetActive (false);
			alphaChanel [to].SetActive (true);
		}
	}

}
