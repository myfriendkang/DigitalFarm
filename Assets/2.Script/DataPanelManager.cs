using UnityEngine;
using System.Collections;

public class DataPanelManager : MonoBehaviour {
	public GameObject observationPanel;
	public GameObject plantInfoPanel;

	// Use this for initialization
	void Start () {

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
}
