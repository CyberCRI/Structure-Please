using UnityEngine;
using System.Collections;

public class MainInterfaceManager : MonoBehaviour {

	public Engine engine;	
	public CrystalCandidateZone crystalCandidateZone;
	public ResultPanel resultPanel;
	
	private float _timeSinceLastPressed = 0;
	private float _timeBetweenTwoPressed = 1f;
	private int _currentIndex = 1;
	private string _baseName = "Textures/candidates/";

	public void displayCrystalOnBooth(Character character)
	{	
		Sprite sprite = Resources.Load<Sprite>(character.picture);
		displayCrystalOnBooth(sprite);
	}
	
	public void displayCrystalOnBooth(Sprite sprite)
	{
		crystalCandidateZone.gameObject.SetActive(true);
		crystalCandidateZone.displayCrystal(sprite);    
    }

	public void onPressIDCard()
	{
		resultPanel.displayIDCard(engine.getCurrentCharacter());
	}

	public void onPressAnalyzeDensity()
	{
		bool alreadyDone = engine.analyzeDensity();
		Crystal tests = engine.getCurrentTestResults();
	}
	
	// Use this for initialization
	void Start () {
		resultPanel.displayIDCard();
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
			displayCrystalOnBooth(sprite);
			_timeSinceLastPressed = 0;
		}
		if(Input.GetKey(KeyCode.B) && (_timeSinceLastPressed > _timeBetweenTwoPressed))
		{
			onPressIDCard();
			_timeSinceLastPressed = 0;
		}
	}
}
