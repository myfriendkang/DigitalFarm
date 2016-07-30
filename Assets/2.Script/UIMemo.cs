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
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

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
}
