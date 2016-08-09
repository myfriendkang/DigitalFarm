using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DataPanelManager : MonoBehaviour {
	
	public GameObject archivePanel;
	public GameObject plantInfoPanel;
	public Button myPlantBtn_archivePanel;
	public Button archive_plantPanel;

	void Start(){
		archivePanel.SetActive (false);
		plantInfoPanel.SetActive (true);

	}
	void Update(){
		if (Input.GetMouseButtonDown (1)) {
			//CloseAllWindow ();
		}
	}

	public void OnPlantInfoPanelClicked(){
		if (archivePanel.activeSelf) {
			archivePanel.SetActive (false);
			plantInfoPanel.SetActive (true);
		}
	}

	public void OnArchiveBtnClicked(){
		if (plantInfoPanel.activeSelf) {
			float x = plantInfoPanel.GetComponent<RectTransform> ().position.x;
			float y = plantInfoPanel.GetComponent<RectTransform> ().position.y;
			float z = plantInfoPanel.GetComponent<RectTransform> ().position.z;
			archivePanel.GetComponent<RectTransform> ().position = new Vector3 (x, y, z);
			plantInfoPanel.SetActive (false);
			archivePanel.SetActive (true);
		}
	}

	public void CloseAllWindow(){
		if (archivePanel.activeSelf || plantInfoPanel.activeSelf) {
			archivePanel.SetActive (false);
			plantInfoPanel.SetActive (false);
		}
	}
}
