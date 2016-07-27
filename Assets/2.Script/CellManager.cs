using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CellManager : MonoBehaviour {

	public GameObject[] greenCells;
	private GameObject _greenCellSelected;
	public bool selectCell = false;  // for Camera Movement;
	public bool clickCell = false;   // control Slider from Each Cell
	private CellInfo[] cells = new CellInfo[5];


	public string nameStr;
	public string dateStr;
	public int waterLevel;
	public int phLevel;
	public int ingredientLevel;
	public int plantID;

	public InputField[] plantInfo;
	public GameObject cameraManager;
	public GameObject sliderInfo;

	public GameObject islandItself;
	private Animation anim;
	bool animPlayed;
	public GameObject[] alphaChanel;
	public GameObject ctButton;
	//public GameObject plantDisplay;
	//public GameObject observationDisplay;



	void Awake(){
		anim = islandItself.GetComponent<Animation> ();
		animPlayed = false;
	    //CellInfo(int id, string name, string date, int water, float ph, int ingredient, bool selected)
		if (greenCells[0].GetComponent<DisplayCellStatus>().ph==0) {
			cells [0] = new CellInfo (1, "First", "07.12.2016", 12, 3.4f, 10, false);
			cells [1] = new CellInfo (2, "Second", "07.21.2016", 1, 1.0f, 3, false);
			cells [2] = new CellInfo (3, "Thrid", "07.14.2016", 0, 6.7f, 12, false);
			cells [3] = new CellInfo (4, "Fourth", "07.15.2016", 14, 9.0f, 1, false);
			cells [4] = new CellInfo (5, "Fifth", "07.04.2016", 31, 13.5f, 43, false);
		} else {
			cells [0] = new CellInfo (1, "First", "07.12.2016", 12, greenCells[0].GetComponent<DisplayCellStatus>().ph, 10, false);
			cells [1] = new CellInfo (2, "Second", "07.21.2016", 1, greenCells[1].GetComponent<DisplayCellStatus>().ph, 3, false);
			cells [2] = new CellInfo (3, "Thrid", "07.14.2016", 0, greenCells[2].GetComponent<DisplayCellStatus>().ph, 12, false);
			cells [3] = new CellInfo (4, "Fourth", "07.15.2016", 14, greenCells[3].GetComponent<DisplayCellStatus>().ph, 1, false);
			cells [4] = new CellInfo (5, "Fifth", "07.04.2016", 31, greenCells[4].GetComponent<DisplayCellStatus>().ph, 43, false);
		}
		for (int i = 0; i <= 4; i++) {
			greenCells [i].GetComponent<DisplayCellStatus> ().SetData (cells [i].Name, cells [i].Date, cells [i].ID, cells [i].Water, cells [i].Ingredient, cells [i].PH, cells [i].Select);
		}
	}

	void Update () { 
		DisplayPH ();
		//CheckSelectOrNot ();
		if(Input.GetMouseButtonDown(1)){
			ResetPos();
			if (alphaChanel [1].activeSelf) {
				SwapAlphaChannel (1, 0);
				ctButton.GetComponent<Button> ().interactable = true;
			}
			if (selectCell == true) {
				for (int i = 0; i < greenCells.Length; i++) {
					if (i != (plantID-1)) {
						Debug.Log (i);
						greenCells [i].GetComponent<Button> ().interactable = true;
					}
				}
				selectCell = false;
			}
			GameObject.Find ("ControlTower").GetComponent<CTManager> ().mgr.ShowMessageBox (0);
		}
		
	}
//	void CheckSelectOrNot(){
//		if (selectCell == true) {
//			cameraManager.GetComponent<ControlCamera> ().FocusObj (plantID);
//			selectCell = false;
//		}	
//	}
	void DisplayPH(){
		float p = sliderInfo.GetComponent<Slider> ().value;
		plantInfo [1].GetComponentInChildren<Text> ().text ="PH    : " + p.ToString("f1");
	}
	string str;
	public void OnGreenCellClick()
	{
		str= "Cell" + plantID.ToString ();
		anim.Play (str);
		clickCell = true;
		animPlayed = true;
		if (alphaChanel [0].activeSelf) {
			SwapAlphaChannel (0, 1);
		}
		Debug.Log (plantID);
		ctButton.GetComponent<Button> ().interactable = false;
		if (selectCell == false) {
			selectCell = true;
		}
		for (int i = 0; i < greenCells.Length; i++) {
			if (i != (plantID-1)) {
				greenCells [i].GetComponent<Button> ().interactable = false;
			}
		}
		GameObject.Find ("ControlTower").GetComponent<CTManager> ().mgr.HideMessageBox (0);
	}
	public void SetTheSelectNumber(int num){
		plantID = num;
	}
	string rePlay;
	public void ResetPos(){
		if (animPlayed == true) {
			rePlay = "R" + str;
			anim.Play (rePlay);
			animPlayed = false;
		}
	}

	float p;
	public void OnSetButtonClick(){
		p = sliderInfo.GetComponent<Slider> ().value;
		//Debug.Log (plantID);
		greenCells [plantID-1].GetComponent<DisplayCellStatus> ().SetPH (p);
		cameraManager.GetComponent<ControlCamera> ().DefaultCamera ();
	}
	public void OnCancelButtonClick(){
		cameraManager.GetComponent<ControlCamera> ().DefaultCamera ();
	}
	public void SwapAlphaChannel(int from, int to){
		if (alphaChanel [from].activeSelf) {
			alphaChanel [from].SetActive (false);
			alphaChanel [to].SetActive (true);
		}
	}



}
