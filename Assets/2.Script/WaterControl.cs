using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaterControl : MonoBehaviour {

	public Image cooldown;
	public bool coolingDown;
	float waitTime = 5.0f;

	void Start(){
		coolingDown = false;
	}
	// control coolingDown Value to start animation

	void Update () 
	{
		if (coolingDown == true) {
			if (cooldown.fillAmount <= 1.0f) {
				cooldown.fillAmount += 5.0f / waitTime * Time.deltaTime;
			} else {
				coolingDown = false;

			}
		} else {
			cooldown.fillAmount = 0.0f;
		}
	}
}
