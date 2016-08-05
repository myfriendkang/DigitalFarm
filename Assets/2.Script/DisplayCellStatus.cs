using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayCellStatus : MonoBehaviour {

	public Sprite[] images;
	public GameObject cellManager;
	public Text[] displayStatus;
	public GameObject[] displayInfo;
	public RectTransform displayOringialX;
	public RectTransform displayDestinationX;
	public GameObject messageCtrl;
	float destinationX;
	float originalX;
	public string name;
	public string date;
	public int id;
	public int water;
	public int nutrient;
	public float ph;
	public float height;
	public int leaves;
	public string text;
	public bool selected;
	public bool cellClicked;
	private MessageManager mgrBox;
	public GameObject ctButton;

	public void SetData(string _strName, string _strDate, int _numID, int _numWater, int _numNutrient, float _fPH, float _height, int _leaves, string _text ,bool _boolSelect){
		name = _strName;
		date = _strDate;
		id = _numID;
		water = _numWater;
		nutrient = _numNutrient;
		ph = _fPH;
		selected = _boolSelect;
		height = _height;
		leaves = _leaves;
		text = _text;
	}

	void Start(){
		mgrBox = messageCtrl.GetComponent<MessageManager> ();
		cellClicked = false;
		originalX = displayInfo [0].GetComponent<RectTransform> ().position.x;
		CloseDisplayPanel ();
		mgrBox.HideMessageBox (1);
	}

	void Update(){
		if (Input.GetMouseButtonDown (1) && cellClicked==true ) {
			ResetAnimation ();
			ShowDefault ();
			ctButton.GetComponent<Button> ().interactable = true;
		}
		if (cellClicked) {
			ShowOutline ();
		}
	}

	public void SetPH(float _ph){
		ph = _ph;
	}
	public void SetHeight(float _h){
		height = _h;
	}
	public void SetLeaves(int _L){
		leaves = _L;
	}
	public void SetText(string _s){
		text = _s;
	}
	public void SetWater(int _w){
		water = _w;
	}
	public void ShowDefault(){
		this.gameObject.GetComponent<Image> ().sprite = images [0];
		messageCtrl.GetComponent<MessageManager> ().HideMessageBox (1);
	}

	public void ShowOutline(){
		this.gameObject.GetComponent<Image> ().sprite = images [1];
		messageCtrl.GetComponent<MessageManager> ().ShowMessageEachCell (id);
	}

	public void ShowSelected(){
		this.gameObject.GetComponent<Image> ().sprite = images [2];
	}

	public void OnPlantClicked(){
		ShowStatus ();
		cellManager.GetComponent<CellManager> ().SetTheSelectNumber (id);
		ShowPlantInfoDisplay ();
		DisplayAnimation ();
	}

	void DisplayAnimation(){
		cellClicked = true;
		iTween.MoveTo (displayInfo [0], iTween.Hash ("x", displayDestinationX.position.x,
			"time", 1.5f,
			"delay", 0.0f,
			"easeType", iTween.EaseType.easeInOutExpo));
	}
	void ResetAnimation(){
		if (cellClicked == true) {
			iTween.MoveTo (displayInfo [0], iTween.Hash ("x", originalX,
				"time", 1.0f,
				"delay", 0.0f,
				"easeType", iTween.EaseType.easeOutExpo));
			cellClicked = false;
		}
	}

	void ShowStatus(){
		displayStatus [0].text = nutrient.ToString ();
		displayStatus [1].text = ph.ToString ("f1");
	}

	public void CloseDisplayPanel(){
		if (displayInfo[0].activeSelf) {
			displayInfo [0].SetActive (false);
		}
	}

	public void ShowPlantInfoDisplay(){
		displayInfo[0].SetActive (true);
	}

	public void SwapDisplayInfo(int from, int to){
		if (displayInfo [from].activeSelf) {
			displayInfo [from].SetActive (false);
			displayInfo [to].SetActive (true);
		}
	}
}

