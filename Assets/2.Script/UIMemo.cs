using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIMemo : MonoBehaviour {

	public InputField memoInputField;
	public Text wordsNum;
	string str;
	char ch;
	int maxWordCount = 50;
	int wordsCount = 0;
	int num=0 ;
	private GameObject selectedObj;
	public Text textField;
	bool shown;
	// Use this for initialization
	void Start () {
		selectedObj = null;
		shown = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.activeSelf) {
			if (selectedObj != null && shown ==false) {
				string text = selectedObj.GetComponent<DisplayCellStatus> ().GetText ();
				Debug.Log (text);
				memoInputField.text = selectedObj.GetComponent<DisplayCellStatus> ().GetText ();
				shown = true;
			}
		}

	}

	public void WordsCount(){
		str = memoInputField.GetComponentInChildren<Text> ().text;
		string[] array = str.Split (' ');
		wordsCount = array.Length-1;

		if (wordsCount <= maxWordCount) {
			num = maxWordCount - wordsCount;
			wordsNum.text = num.ToString ();
		}
	}
	public void GetSelectedCell(GameObject obj){
		selectedObj = obj;
	}
	public void RemoveSelectedCell(){
		selectedObj = null;
		shown = false;
	}
}
