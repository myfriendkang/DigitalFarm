using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DataPanelManager : MonoBehaviour {
	
	public GameObject observationPanel;
	public GameObject plantInfoPanel;
	void Start(){

	}
	void Update(){
		if (Input.GetMouseButtonDown (1)) {
			//CloseAllWindow ();
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
		}
	}
}
