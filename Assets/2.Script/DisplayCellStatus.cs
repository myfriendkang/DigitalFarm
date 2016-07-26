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
	public GameObject CellManager;
	public InputField[] displayStatus;
	public GameObject slider;

	public void SetData(string strName, string strDate, int numID, int numWater, int numNutrient, float fPH, bool boolSelect){
		name = strName;
		date = strDate;
		id = numID;
		water = numWater;
		nutrient = numNutrient;
		ph = fPH;
		selected = boolSelect;
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
		//CellManager.GetComponent<CellManager> ().SetTheSelectNumber (id);
		//CellManager.GetComponent<CellManager> ().selectCell = true;
		slider.GetComponent<SliderManager> ()._phVal = ph;
		ShowStatus ();
	}
	void ShowStatus(){
		displayStatus [0].GetComponentInChildren<Text> ().text = "Water : " + water.ToString ();
		displayStatus [1].GetComponentInChildren<Text> ().text = "Nutrient : " + nutrient.ToString ();
		displayStatus [2].GetComponentInChildren<Text> ().text = "PH : " + ph.ToString ("f1");
	}
}

