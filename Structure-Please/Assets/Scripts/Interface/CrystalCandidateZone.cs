using UnityEngine;
using System.Collections;

public class CrystalCandidateZone : MonoBehaviour {


	public SpriteRenderer candidate;

	public Sprite sprite1;
	public Sprite sprite2;
	public Sprite sprite3;

	private float _timeSinceLastPressed = 0;
	private float _timeBetweenTwoPressed = 1;
	private int _currentIndex = 1;

	public void displayNextCrystal(int i)
	{
		Debug.Log("display "+i);
		candidate.gameObject.SetActive(true);
		//candidate.guiTexture = new GUITexture();

		switch(i)
		{
		case 1:
			candidate.sprite = sprite1;
			break;
		case 2:
			candidate.sprite = sprite2;
			break;
		case 3:
			candidate.sprite = sprite3;
			break;
		}
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		_timeSinceLastPressed += Time.deltaTime;
		if(Input.GetKey(KeyCode.A) && (_timeSinceLastPressed > _timeBetweenTwoPressed))
		{
			_currentIndex = (_currentIndex+1) %3 + 1;
			Debug.Log(_currentIndex);
			displayNextCrystal(_currentIndex);
			_timeSinceLastPressed = 0;
		}
	}
}
