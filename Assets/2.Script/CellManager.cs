﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CellManager : MonoBehaviour {
	
	public GameObject[] greenCells;
	public string nameStr;
	public string dateStr;
	public int    waterLevel;
	public int    phLevel;
	public int    ingredientLevel;
	public int    plantID;
	public float  height;
	public int    leaves;
	public string text;
	public InputField[] plantInfo;
	public GameObject   sliderInfo;
	public GameObject[] alphaChanel;
	public GameObject   ctButton;
	public GameObject   islandItself;
	public GameObject   islandMgr;
	public GameObject   displayInfo;
	public GameObject   islandManager;
	float originalX;

	public bool selectCell = false;  // for Camera Movement;
	public bool clickCell = false;   // control Slider from Each Cell

	private CellInfo[] cells = new CellInfo[5];
    GameObject _greenCellSelected;

	string rePlay;
	float p;
	string str;


	void Awake(){
		originalX = displayInfo.GetComponent<RectTransform> ().position.x;
	    //CellInfo(int id, string name, string date, int water, float ph, int ingredient, bool selected)
		if (greenCells[0].GetComponent<DisplayCellStatus>().ph==0) {
			cells [0] = new CellInfo (1,  "First",  "07.12.2016", 12,  3.4f,  10,  10.0f, 2, "", false);
			cells [1] = new CellInfo (2, "Second",  "07.21.2016",  1,  1.0f,   3,  20.0f, 4, "", false);
			cells [2] = new CellInfo (3,  "Thrid",  "07.14.2016",  0,  6.7f,  12,  30.0f, 2, "", false);
			cells [3] = new CellInfo (4, "Fourth",  "07.15.2016", 14,  9.0f,   1,  40.0f, 3, "", false);
			cells [4] = new CellInfo (5,  "Fifth",  "07.04.2016", 31, 13.5f,  43,  50.0f, 2, "", false);
		} else {
			cells [0] = new CellInfo (1,  "First", "07.12.2016", 12,  greenCells[0].GetComponent<DisplayCellStatus>().ph, 10,  3.0f, 12, "", false);
			cells [1] = new CellInfo (2, "Second", "07.21.2016",  1,  greenCells[1].GetComponent<DisplayCellStatus>().ph,  3,  2.0f,  3, "", false);
			cells [2] = new CellInfo (3,  "Thrid", "07.14.2016",  0,  greenCells[2].GetComponent<DisplayCellStatus>().ph, 12,  1.0f,  3, "", false);
			cells [3] = new CellInfo (4, "Fourth", "07.15.2016",  14, greenCells[3].GetComponent<DisplayCellStatus>().ph,  1, 30.0f,  3, "", false);
			cells [4] = new CellInfo (5,  "Fifth", "07.04.2016",  31, greenCells[4].GetComponent<DisplayCellStatus>().ph, 43, 40.0f,  2, "", false);
		}
		for (int i = 0; i <= 4; i++) {
			greenCells [i].GetComponent<DisplayCellStatus> ().SetData (cells [i].Name, cells [i].Date, cells [i].ID, cells [i].Water, cells [i].Ingredient, cells [i].PH, cells [i].Height ,cells [i].Leaves,cells [i].Text,cells [i].Select);
		}
	}

	void Update () { 
		DisplayPH ();
		if(Input.GetMouseButtonDown(1)){
			if (alphaChanel [1].activeSelf) {
				ctButton.GetComponent<Button> ().interactable = true;
			}
			if (selectCell == true) {
				for (int i = 0; i < greenCells.Length; i++) {
					if (i != (plantID-1)) {
						greenCells [i].GetComponent<Button> ().interactable = true;
					}
				}
				selectCell = false;
			}
		}
	}

	void DisplayPH(){
		//plantInfo [1].GetComponentInChildren<Text> ().text ="PH    : " + p.ToString("f1");
	}

	public void OnGreenCellClick()
	{
		str= "Cell" + plantID.ToString ();
		clickCell = true;
		if (alphaChanel [0].activeSelf) {
			SwapAlphaChannel (0, 1);
		}
		_greenCellSelected = greenCells[plantID-1];
		islandMgr.GetComponent<IslandManager> ().ScaleForCell (plantID); 
		ctButton.GetComponent<Button> ().interactable = false;
		if (selectCell == false) {
			selectCell = true;
		}
		for (int i = 0; i < greenCells.Length; i++) {
			if (i != (plantID-1)) {
				greenCells [i].GetComponent<Button> ().interactable = false;
			}
		}
	}
	void FocusCell(int i){
		islandMgr.GetComponent<IslandManager> ().ScaleForCell (i);
	}

	public void SetTheSelectNumber(int num){
		plantID = num;
	}
		
	public void OnSetButtonClick(){
		p = sliderInfo.GetComponent<Slider> ().value;
		greenCells [plantID-1].GetComponent<DisplayCellStatus> ().SetPH (p);
		greenCells [plantID - 1].GetComponent<DisplayCellStatus> ().CloseDisplayPanel ();
		for (int i = 0; i < greenCells.Length; i++) {
			if (i != (plantID-1)) {
				greenCells [i].GetComponent<Button> ().interactable = true;
			}
		}
	}

	public void OnCancelButtonClick(){
		greenCells [plantID - 1].GetComponent<DisplayCellStatus> ().CloseDisplayPanel ();
		for (int i = 0; i < greenCells.Length; i++) {
			if (i != (plantID-1)) {
				greenCells [i].GetComponent<Button> ().interactable = true;
			}
		}
	}

	public void SwapAlphaChannel(int from, int to){
		if (alphaChanel [from].activeSelf) {
			alphaChanel [from].SetActive (false);
			alphaChanel [to].SetActive (true);
		}
	}

	public void SaveButtonClick(){
		greenCells [plantID-1].GetComponent<DisplayCellStatus> ().SetHeight (height);
		greenCells [plantID - 1].GetComponent<DisplayCellStatus> ().SetLeaves (leaves);
		greenCells [plantID - 1].GetComponent<DisplayCellStatus> ().SetText (text);
		greenCells [plantID - 1].GetComponent<DisplayCellStatus> ().ShowDefault ();
		greenCells [plantID - 1].GetComponent<DisplayCellStatus> ().cellClicked = false;
		ResetAnimation ();
		ctButton.GetComponent<Button> ().interactable = true;
		islandManager.GetComponent<IslandManager> ().ScaleForCell (0);
		for (int i = 0; i < greenCells.Length; i++) {
			if (i != (plantID-1)) {
				greenCells [i].GetComponent<Button> ().interactable = true;

			}
		}
		SwapAlphaChannel (1, 0);
	}

	void ResetAnimation(){
		iTween.MoveTo (displayInfo, iTween.Hash ("x", originalX,
				"time", 1.0f,
				"delay", 0.0f,
				"easeType", iTween.EaseType.easeOutExpo));

	}
}
