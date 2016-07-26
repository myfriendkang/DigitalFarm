using UnityEngine;
using System.Collections;

public class CTManager : MonoBehaviour {

	public GameObject island;
	public GameObject plantDisplay;
	public GameObject observationDisplay;

	private Animation anim;
	bool isMoved = false;

	// Use this for initialization
	void Start () {
		anim = island.GetComponent<Animation> () as Animation;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (1)) {
			if (isMoved == true) {
				anim.Play ("MovingBackCT");	
				isMoved = false;
			}
			if (plantDisplay.activeSelf || observationDisplay.activeSelf) {
				plantDisplay.SetActive(false);
				observationDisplay.SetActive (false);
			}
		}
	}

	public void OnCTClcik(){
		if (isMoved == false) {
			anim.Play ("MovingCT");	
			plantDisplay.SetActive (true);
			isMoved = true;
		}
	}

}
