using UnityEngine;
using System.Collections;

public class MainInterfaceManager : MonoBehaviour {
	public Engine engine;	
	public CrystalCandidateZone crystalCandidateZone;
	public ResultPanel resultPanel;
	public DensityCardPanel densityCardPanel;
	public TransparencyCardPanel transparencyCardPanel;
	public StructureCardPanel structureCardPanel;
	public HardnessCardText hardnessCardPanel;
	public ColorCardPanel colorCardPanel;
	
	private float _timeSinceLastPressed = 0;
	private float _timeBetweenTwoPressed = .5f;
	private int _currentIndex = 1;
	private string _baseName = "Textures/candidates/";

	public void hideCardPanels() 
	{
		resultPanel.displayIDCard ();
		densityCardPanel.gameObject.SetActive (false);
		transparencyCardPanel.gameObject.SetActive (false);
		structureCardPanel.gameObject.SetActive (false);
		hardnessCardPanel.gameObject.SetActive (false);
		colorCardPanel.gameObject.SetActive (false);
	}
	
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
		bool performedTest = engine.analyzeDensity();
		if(!performedTest) return;

		densityCardPanel.gameObject.SetActive (true);
		densityCardPanel.display (engine.getCurrentTestResults());
	}
	public void onPressAnalyzeStructure()
	{
		bool performedTest = engine.analyzeStructure();
		if(!performedTest) return;
		
		structureCardPanel.gameObject.SetActive (true);
		structureCardPanel.display (engine.getCurrentTestResults());
	}
	public void onPressAnalyzeTransparency()
	{
		bool performedTest = engine.analyzeTransparency();
		if(!performedTest) return;
		
		densityCardPanel.gameObject.SetActive (true);
		densityCardPanel.display (engine.getCurrentTestResults());
	}
	public void onPressAnalyzeHardness()
	{
		bool performedTest = engine.analyzeHardness();
		if(!performedTest) return;
		
		hardnessCardPanel.gameObject.SetActive (true);
		hardnessCardPanel.display (engine.getCurrentTestResults());
	}
	public void onPressAnalyzeColor()
	{
		bool performedTest = engine.analyzeColor();
		if(!performedTest) return;
		
		colorCardPanel.gameObject.SetActive (true);
		colorCardPanel.display (engine.getCurrentTestResults());
	}
  
	
	// Use this for initialization
	void Start () {
		resultPanel.displayIDCard();
    }	

	// Update is called once per frame
	void Update () {
		_timeSinceLastPressed += Time.deltaTime;
		//booth
		if(Input.GetKey(KeyCode.B) && (_timeSinceLastPressed > _timeBetweenTwoPressed))
		{
			//int i = Mathf.FloorToInt(Random.value*2+1);
			_currentIndex = (_currentIndex+1) %3 + 1;
			string name = _baseName+_currentIndex;
			Debug.Log("display "+_currentIndex+" ie "+name);
			Sprite sprite = Resources.Load<Sprite>(name);
			displayCrystalOnBooth(sprite);
			_timeSinceLastPressed = 0;
		}
		//id card
		if(Input.GetKey(KeyCode.I) && (_timeSinceLastPressed > _timeBetweenTwoPressed))
		{
			onPressIDCard();
			_timeSinceLastPressed = 0;
		}
		//density
		if(Input.GetKey(KeyCode.D) && (_timeSinceLastPressed > _timeBetweenTwoPressed))
		{
			onPressAnalyzeDensity();
			_timeSinceLastPressed = 0;
		}
		//structure
		if(Input.GetKey(KeyCode.S) && (_timeSinceLastPressed > _timeBetweenTwoPressed))
		{
			onPressAnalyzeStructure();
			_timeSinceLastPressed = 0;
	    }
			//transparency
		if(Input.GetKey(KeyCode.T) && (_timeSinceLastPressed > _timeBetweenTwoPressed))
		{
			onPressAnalyzeTransparency();
			_timeSinceLastPressed = 0;
	    }
		//hardness
		if(Input.GetKey(KeyCode.H) && (_timeSinceLastPressed > _timeBetweenTwoPressed))
		{
			onPressAnalyzeHardness();
			_timeSinceLastPressed = 0;
	    }
		//color
		if(Input.GetKey(KeyCode.C) && (_timeSinceLastPressed > _timeBetweenTwoPressed))
		{
			onPressAnalyzeColor();
			_timeSinceLastPressed = 0;
	    }
		//next
		if(Input.GetKey(KeyCode.N) && (_timeSinceLastPressed > _timeBetweenTwoPressed))
		{			
			engine.gotoNextCharacter();
			_timeSinceLastPressed = 0;
		}
  }
}
