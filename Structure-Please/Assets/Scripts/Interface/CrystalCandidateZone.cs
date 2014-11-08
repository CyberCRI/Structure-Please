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
	private string _baseName = "Textures/candidates/";

	public void displayNextCrystal(int i)
	{
		candidate.gameObject.SetActive(true);

		string name = _baseName+i;
		Debug.Log("display "+i+" ie "+name);
		Sprite sprite = Resources.Load<Sprite>(name) as Sprite;
		candidate.sprite = sprite;
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
