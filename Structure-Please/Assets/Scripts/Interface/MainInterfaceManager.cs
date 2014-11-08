using UnityEngine;
using System.Collections;

public class MainInterfaceManager : MonoBehaviour {

	public CrystalCandidateZone crystalCandidateZone;
	public IdentityCardPanel identityCardPanel;
	
	private float _timeSinceLastPressed = 0;
	private float _timeBetweenTwoPressed = 1;
	private int _currentIndex = 1;
	private string _baseName = "Textures/candidates/";


	public void displayCrystal(Sprite sprite)
	{		
		crystalCandidateZone.gameObject.SetActive(true);
		identityCardPanel.gameObject.SetActive(true);

		crystalCandidateZone.displayCrystal(sprite);
		identityCardPanel.displayCrystal(sprite);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	
	// Update is called once per frame
	void Update () {
		_timeSinceLastPressed += Time.deltaTime;
		if(Input.GetKey(KeyCode.A) && (_timeSinceLastPressed > _timeBetweenTwoPressed))
		{
			//int i = Mathf.FloorToInt(Random.value*2+1);
			_currentIndex = (_currentIndex+1) %3 + 1;
			string name = _baseName+_currentIndex;
			Debug.Log("display "+_currentIndex+" ie "+name);
			Sprite sprite = Resources.Load<Sprite>(name);
			displayCrystal(sprite);
			_timeSinceLastPressed = 0;
		}
	}
}
