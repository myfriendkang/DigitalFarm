using UnityEngine;
using System.Collections;

public class MessageManager : MonoBehaviour {

	public GameObject[] messages;
	// Use this for initialization
	void Start () {
		
	}

	public void ShowMessageBox(int num){
		messages [num].SetActive (true);
	}

	public void HideMessageBox(int num){
		if (messages [num].activeSelf) {
			messages [num].SetActive (false);
		}
	}

}
