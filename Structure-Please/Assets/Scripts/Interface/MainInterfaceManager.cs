using UnityEngine;
using System.Collections;

public class MainInterfaceManager : MonoBehaviour {
	public Engine engine;	
	public CrystalCandidateZone crystalCandidateZone;
	public ResultPanel resultPanel;
	public DensityCardPanel densityCardPanel;
	public TransparencyCardPanel transparencyCardPanel;
	public StructureCardPanel structureCardPanel;
	public HardnessCardPanel hardnessCardPanel;
	public ColorCardPanel colorCardPanel;
	
	private float _timeSinceLastPressed = 0;
	private float _timeBetweenTwoPressed = .5f;
	private int _currentIndex = 1;
	private string _baseName = "Textures/candidates/";

	public void acceptCharacter() 
	{
		var wasRight = engine.makeDecision (true);
		// TODO: say something about how the player was right or wrong
		Debug.Log ("You were " + (wasRight ? "right" : "wrong"));
		gotoNextCharacter ();
	}

	public void rejectCharacter() 
	{
		var wasRight = engine.makeDecision (false);
		// TODO: say something about how the player was right or wrong
		Debug.Log ("You were " + (wasRight ? "right" : "wrong"));
		gotoNextCharacter ();
	}

	public void gotoNextCharacter() 
	{
		hideCardPanels ();
		hideCrystalOnBooth ();
		engine.gotoNextCharacter ();
		
		displayCrystalOnBooth(engine.getCurrentCharacter());
	}

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

	public void hideCrystalOnBooth()
	{
		crystalCandidateZone.gameObject.SetActive (false);
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
		gotoNextCharacter ();
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
		//accept
		if(Input.GetKey(KeyCode.A) && (_timeSinceLastPressed > _timeBetweenTwoPressed))
		{			
			acceptCharacter();
			_timeSinceLastPressed = 0;
		}
		//reject
		if(Input.GetKey(KeyCode.R) && (_timeSinceLastPressed > _timeBetweenTwoPressed))
		{			
			rejectCharacter();
			_timeSinceLastPressed = 0;
		}
	}	
	
	public Texture2D densityIcon;
	public Texture2D structureIcon;
	public Texture2D hardnessIcon;
	public Texture2D transparencyIcon;
	public Texture2D colorIcon;

	public int _densityX = 0;
	public int _densityY = 0;
	public int _structureX = 64;
	public int _structureY = 64;
	public int _hardnessX = 128;
	public int _hardnessY = 128;
	public int _transparencyX = 0;
	public int _transparencyY = 0;
	public int _colorX = 64;
	public int _colorY = 64;

	private int _buttonWidth = 64;
	private int _buttonHeight = 64;

	/*
	void OnGUI () {
		int height = Screen.height;
		Debug.Log(height);
		if(GUI.Button (new Rect(_densityX,height-_densityY,_buttonWidth,_buttonHeight), new GUIContent (densityIcon, "Pour évaluer la densité")))
		{
			onPressAnalyzeDensity();
		}
		if(GUI.Button (new Rect(_structureX, height-_structureY, _buttonWidth, _buttonHeight), new GUIContent (structureIcon, "Pour évaluer la géométrie")))
		{
			onPressAnalyzeStructure();
		}
		if(GUI.Button (new Rect(_hardnessX, height-_hardnessY, _buttonWidth, _buttonHeight), new GUIContent (hardnessIcon, "Pour évaluer la dureté")))
		{
			onPressAnalyzeHardness();
		}
		if(GUI.Button (new Rect(_transparencyX, height-_transparencyY, _buttonWidth, _buttonHeight), new GUIContent (transparencyIcon, "Pour évaluer la transparence")))
		{
			onPressAnalyzeTransparency();
		}
		if(GUI.Button (new Rect(_colorX, height-_colorY, _buttonWidth, _buttonHeight), new GUIContent (colorIcon, "Pour évaluer la couleur")))
		{
			onPressAnalyzeColor();
		}
  }
  */
}
