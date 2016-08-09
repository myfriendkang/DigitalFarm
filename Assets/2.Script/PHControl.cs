using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PHControl : MonoBehaviour
{

	public GameObject point;
	public bool coolingDown;
	float waitTime;
	public Text phVal;
	float phRadian;
	float phMax = 14.0f;
	string s;
	void Awake ()
	{
		coolingDown = false;
		if (point.GetComponent<RectTransform> ().eulerAngles.z < 1  && point.GetComponent<RectTransform> ().eulerAngles.z >=0) {
			point.GetComponent<RectTransform> ().eulerAngles = new Vector3 (0, 0, 359.9f);
		}

	}
		
	void Update ()
	{
		if (coolingDown) {
			
			s = phVal.text;
			phRadian = float.Parse (s);
			phRadian = (360 * phRadian) / phMax;
			if (point.GetComponent<RectTransform> ().eulerAngles.z >= 360 - phRadian) {
				point.GetComponent<RectTransform> ().Rotate (Vector3.back * 5);
			}

		} else {
			point.GetComponent<RectTransform> ().eulerAngles = new Vector3 (0, 0, 359.9f);
			coolingDown = false;
		}
	}
}
