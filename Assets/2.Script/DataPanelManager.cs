using UnityEngine;
using System.Collections;

public class DataPanelManager : MonoBehaviour {
	public GameObject observationPanel;
	public GameObject plantInfoPanel;

	// Use this for initialization
	void Start () {

	}
	void Update(){
		if (Input.GetMouseButtonDown (1)) {
			Debug.Log ("asdfaD");
			CloseAllWindow ();
		}
	}
	public void OnPlantInfoPanelClicked(){
		if (!plantInfoPanel.activeSelf) {
			observationPanel.SetActive (false);
			plantInfoPanel.SetActive (true);
		}

	}
	public void OnObservationPanelClicked(){
		if (!observationPanel.activeSelf) {
			observationPanel.SetActive (true);
			plantInfoPanel.SetActive (false);
		}
	}

	void CloseAllWindow(){
		if (observationPanel.activeSelf || plantInfoPanel.activeSelf) {
			observationPanel.SetActive (false);
			plantInfoPanel.SetActive (false);
			Debug.Log ("dfadsf");
		}
	}
}
