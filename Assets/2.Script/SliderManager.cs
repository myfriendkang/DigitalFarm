using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour {

	public Image fillArea;
	public Text numStr;
	private float _phVal;
	Color orange = new Color(255/255f,165/255f,0);
	Color green = new Color (153/255f,255/255f,0);
	Color darkBlue = new Color(0,0,102/255f);

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Slider(){
		_phVal = this.gameObject.GetComponent<Slider> ().value;
		numStr.text = _phVal.ToString ("f1");
		if (_phVal >= 0.0f && _phVal <= 6.0f) {
			fillArea.color = Color.Lerp (Color.red, orange, _phVal / 6);
		} else if (_phVal >= 6.1 && _phVal <= 6.5) {
			fillArea.color = Color.Lerp (orange, Color.white, _phVal / 2);
		} else if (_phVal >= 6.6 && _phVal <= 14) {
			fillArea.color = Color.Lerp (green, darkBlue, (_phVal-6.0f)/8);
		}
	}
}
