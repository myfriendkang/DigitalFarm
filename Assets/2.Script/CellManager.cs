using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CellManager : MonoBehaviour {

	public GameObject[] greenCells;
	private GameObject _greenCellSelected;
	public bool selectCell = false;
	private CellInfo[] cells = new CellInfo[5];


	public string nameStr;
	public string dateStr;
	public int waterLevel;
	public int phLevel;
	public int ingredientLevel;
	public int plantID;

	public InputField[] plantInfo;
	public GameObject cameraManager;
	public GameObject cellInfoDisplay;
	public GameObject sliderInfo;

	void Awake(){
	    //CellInfo(int id, string name, string date, int water, float ph, int ingredient, bool selected)
		cells [0] = new CellInfo (1, "First",  "07.12.2016", 12, 3.4f,  10, false);
		cells [1] = new CellInfo (2, "Second", "07.21.2016", 1,  1.0f,  3,  false);
		cells [2] = new CellInfo (3, "Thrid",  "07.14.2016", 0,  6.7f,  12, false);
		cells [3] = new CellInfo (4, "Fourth", "07.15.2016", 14, 9.0f,  1,  false);
		cells [4] = new CellInfo (5, "Fifth",  "07.04.2016", 31, 13.5f, 43, false);
		for (int i = 0; i <= 4; i++) {
			greenCells [i].GetComponent<DisplayCellStatus> ().SetData (cells [i].Name, cells [i].Date, cells [i].ID, cells [i].Water, cells [i].Ingredient, cells [i].PH, cells [i].Select);
		}
	}

	void Start () {
	}
		
	void Update () { 
		
		CheckSelectOrNot ();
		DisplayPH ();
	}
	void CheckSelectOrNot(){
		if (selectCell == true) {
			cameraManager.GetComponent<ControlCamera> ().FocusObj (plantID);
			selectCell = false;
		}	
	}
	void DisplayPH(){
		float p = sliderInfo.GetComponent<Slider> ().value;
		plantInfo [1].GetComponentInChildren<Text> ().text ="PH    : " + p.ToString("f1");
	}
	public void OnGreenCellClick()
	{
		cameraManager.GetComponent<ControlCamera> ().FocusObj (plantID);
	}
	public void SetTheSelectNumber(int num){
		plantID = num;
	}

}
