using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayCellStatus : MonoBehaviour {


	// Use this for initialization
	public string name;
	public string date;
	public int id;
	public int water;
	public int nutrient;
	public float ph;
	public bool selected;
	public Sprite[] images;
	public GameObject cellManager;
	public InputField[] displayStatus;
	public GameObject slider;

	public GameObject[] displayInfo;

	public void SetData(string strName, string strDate, int numID, int numWater, int numNutrient, float fPH, bool boolSelect){
		name = strName;
		date = strDate;
		id = numID;
		water = numWater;
		nutrient = numNutrient;
		ph = fPH;
		selected = boolSelect;
	}
	void setup(){
		CloseDisplayPanel ();
	}
	void update(){
		if (Input.GetMouseButtonDown (1)) {

		}
	}
	public void SetPH(float _ph){
		ph = _ph;
	}
	public void ShowDefault()
	{
		this.gameObject.GetComponent<Image> ().sprite = images [0];
	}
	public void ShowOutline()
	{
		this.gameObject.GetComponent<Image> ().sprite = images [1];
	}
	public void ShowSelected()
	{
		this.gameObject.GetComponent<Image> ().sprite = images [2];
	}

	public void OnPlantClicked(){
		slider.GetComponent<SliderManager> ()._phVal = ph;
		ShowStatus ();
		cellManager.GetComponent<CellManager> ().SetTheSelectNumber (id);
		ShowPlantInfoDisplay ();
	}
	void ShowStatus(){
		displayStatus [0].GetComponentInChildren<Text> ().text = "Water : " + water.ToString ();
		displayStatus [1].GetComponentInChildren<Text> ().text = "Nutrient : " + nutrient.ToString ();
		displayStatus [2].GetComponentInChildren<Text> ().text = "PH : " + ph.ToString ("f1");
	}
	void CloseDisplayPanel(){
		if (displayInfo[0].activeSelf || displayInfo[1].activeSelf) {
			for (int i = 0; i <= 1; i++) {
				displayInfo [i].SetActive (false);
			}
		}
	}
	void ShowPlantInfoDisplay(){
		displayInfo[0].SetActive (true);
		displayInfo[1].SetActive (false);
	}

	public void SwapDisplayInfo(int from, int to){
		if (displayInfo [from].activeSelf) {
			displayInfo [from].SetActive (false);
			displayInfo [to].SetActive (true);
		}
	}



}

