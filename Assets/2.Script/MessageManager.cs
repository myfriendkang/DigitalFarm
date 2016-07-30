using UnityEngine;
using System.Collections;

public class MessageManager : MonoBehaviour {
	public GameObject cellMgr;
	public GameObject[] messages;
	float originalY;
	float x;
	float y;
	// Use this for initialization
	void Start () {
		originalY= messages [1].GetComponent<RectTransform> ().position.y;
	}

	public void ShowMessageBox(int num){
		messages [num].SetActive (true);
	}

	public void HideMessageBox(int num){
		if (messages [num].activeSelf) {
			messages [num].SetActive (false);
		} else {
			messages [num].SetActive (false);
		}
	}
	public void DoPingpongAnimation(int num){
		iTween.MoveBy (messages [num], iTween.Hash ("y",10 ,
			"time", 0.3f,
			"delay", 0.0f,
			"easeType", iTween.EaseType.easeOutExpo
			,"loopType", iTween.LoopType.pingPong));
	}
		

	public void ShowMessageEachCell(int i){
		if (messages [0].activeSelf) {
			x = cellMgr.GetComponent<CellManager> ().greenCells [i - 1].GetComponent<RectTransform> ().position.x;
			y = cellMgr.GetComponent<CellManager> ().greenCells [i - 1].GetComponent<RectTransform> ().position.y + 50;
			messages [1].GetComponent<RectTransform> ().position = new Vector3 (x, y, 1);
			ShowMessageBox (1);
		}
	}

}   
