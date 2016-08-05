using UnityEngine;
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
	public GameObject profile;
	float originalX;

	public bool selectCell = false;  // for Camera Movement;
	public bool clickCell = false;   // control Slider from Each Cell

	private CellInfo[] cells = new CellInfo[5];
    GameObject _greenCellSelected;

	string rePlay;
	float p;
	string str;

	public Sprite[] plantImage;
	public Text platName;
	public GameObject imageObj;

	public GameObject waterScript;
	public GameObject phScript;

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
			cells [0] = new CellInfo (1,  "First", "07.12.2016", 90,  greenCells[0].GetComponent<DisplayCellStatus>().ph, 10,  3.0f, 12, "", false);
			cells [1] = new CellInfo (2, "Second", "07.21.2016",  120,  greenCells[1].GetComponent<DisplayCellStatus>().ph,  3,  2.0f,  3, "", false);
			cells [2] = new CellInfo (3,  "Thrid", "07.14.2016",  73,  greenCells[2].GetComponent<DisplayCellStatus>().ph, 12,  1.0f,  3, "", false);
			cells [3] = new CellInfo (4, "Fourth", "07.15.2016",  220, greenCells[3].GetComponent<DisplayCellStatus>().ph,  1, 30.0f,  3, "", false);
			cells [4] = new CellInfo (5,  "Fifth", "07.04.2016",  295, greenCells[4].GetComponent<DisplayCellStatus>().ph, 43, 40.0f,  2, "", false);
		}
		for (int i = 0; i <= 4; i++) {
			greenCells [i].GetComponent<DisplayCellStatus> ().SetData (cells [i].Name, cells [i].Date, cells [i].ID, cells [i].Water, cells [i].Ingredient, cells [i].PH, cells [i].Height ,cells [i].Leaves,cells [i].Text,cells [i].Select);
		}
	}

	void Update () { 
		if(Input.GetMouseButtonDown(1)){
			if (alphaChanel [1].activeSelf) {
				ctButton.GetComponent<Button> ().interactable = true;
			}
			if (selectCell == true) {
				StartCoroutine ("ShowProfile");
				waterScript.GetComponent<WaterControl> ().coolingDown = false;
				phScript.GetComponent<PHControl> ().coolingDown = false;
				islandManager.GetComponent<IslandManager> ().ScaleForCell (0);
				islandManager.GetComponent<IslandManager> ().cellClick = false;
				for (int i = 0; i < greenCells.Length; i++) {
					if (i != (plantID-1)) {
						greenCells [i].GetComponent<Button> ().interactable = true;
					}
				}
				selectCell = false;
			}
			SwapAlphaChannel (1, 0);
		}
	}

	public void OnGreenCellClick()
	{
		str= "Cell" + plantID.ToString ();
		clickCell = true;
		if (alphaChanel [0].activeSelf) {
			SwapAlphaChannel (0, 1);
		}
		StartCoroutine ("HideProfile");
		StartCoroutine ("WaterAnimation");
		StartCoroutine ("PHAnimation");
		_greenCellSelected = greenCells[plantID-1];
		SetIamge (plantID-1);
		SetName (plantID - 1);
		islandMgr.GetComponent<IslandManager> ().ScaleForCell (plantID); 
		islandMgr.GetComponent<IslandManager> ().cellClick = true;
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

	IEnumerator WaterAnimation(){
		yield return new WaitForSeconds (1.0f);
		waterScript.GetComponent<WaterControl> ().coolingDown = true;
	}

	IEnumerator PHAnimation(){
		yield return new WaitForSeconds (1.0f);
		phScript.GetComponent<PHControl> ().coolingDown = true;
	}

	void SetName(int i){
		switch (i) {
		case 0:
			platName.text = "AURORA";
			break;
		case 1:
			platName.text = "BRANDON";
			break;
		case 2:
			platName.text = "APRIL";
			break;
		case 3:
			platName.text = "FLELIX";
			break;
		case 4:
			platName.text = "JEREMY";
			break;
		}
	}

	void SetIamge(int i){
		imageObj.GetComponent<Image> ().sprite = plantImage [i];
	}

	IEnumerator ShowProfile(){
		yield return new WaitForSeconds (0.6f);
		profile.SetActive (true);
	}

	IEnumerator HideProfile(){
		yield return new WaitForSeconds (0.1f);
		profile.SetActive (false);
	}

	void FocusCell(int i){
		islandMgr.GetComponent<IslandManager> ().ScaleForCell (i);
	}

	public void SetTheSelectNumber(int num){
		plantID = num;
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
		StartCoroutine ("ShowProfile");
		waterScript.GetComponent<WaterControl> ().coolingDown = false;
		phScript.GetComponent<PHControl> ().coolingDown = false;
		ctButton.GetComponent<Button> ().interactable = true;
		islandManager.GetComponent<IslandManager> ().ScaleForCell (0);
		islandManager.GetComponent<IslandManager> ().cellClick = false;
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
