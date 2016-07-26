using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class SpriteController : MonoBehaviour {

	public string _spriteName= string.Empty;
	public float _totalAnimTimeInSeconds =3f;
	private float _passedTime = 0;
	private int _currentNumber = 0;
	//public string folerName;

	public Sprite[] _sprites;
	public bool playAnim;
	// Use this for initialization
	void Awake () {
		playAnim = false;
		_sprites = Resources.LoadAll<Sprite> ("CT");
	}
	
	// Update is called once per frame
	void Update () {
		if (_sprites.Length > 0 && playAnim == true) {
				float singleAnimTime = _totalAnimTimeInSeconds / _sprites.Length;
				if (_passedTime >= singleAnimTime) {
					_currentNumber++;
					if (_currentNumber >= _sprites.Length) {
						_currentNumber = 0;
						playAnim = false;
					}
					gameObject.GetComponent<Image> ().sprite = _sprites [_currentNumber];
					_passedTime -= singleAnimTime;
				}
				_passedTime += Time.deltaTime;
			}
			
	}

	public void PlaySpriteImage(){
		playAnim = true;
	}
}
