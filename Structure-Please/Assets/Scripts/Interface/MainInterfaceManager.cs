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
	public WealthPanel wealthPanel;
	public GameObject victory;
	public GameObject fail;

	public GameObject rule1;
	public GameObject rule2;
	public GameObject rule3;
	public GameObject score;
	public GameObject scoreLabel;
	public GameObject idcardField1;
	public GameObject idcardField2;
	public GameObject idcardField3;
	public GameObject idcardField4;
	
	private float _timeSinceLastPressed = 0;
	private float _timeBetweenTwoPressed = .5f;
	private int _currentIndex = 1;
	private string _baseName = "Textures/candidates/";

	void manageGUITexts(bool display)
	{
		rule1.SetActive(display);
		rule2.SetActive(display);
		rule3.SetActive(display);
		score.SetActive(display);
		scoreLabel.SetActive(display);
		idcardField1.SetActive(display);
		idcardField2.SetActive(display);
		idcardField3.SetActive(display);
		idcardField4.SetActive(display);
	}

	IEnumerator displayGameObjectForSomeTime(GameObject panel, float duration) {		
		manageGUITexts(false);
		panel.SetActive(true);
		Debug.LogError("BEFORE");
		yield return new WaitForSeconds(duration);
		Debug.LogError("AFTER ");
		panel.SetActive(false);
		manageGUITexts(true);
	}
  
  public void acceptCharacter() 
	{
		var wasRight = engine.makeDecision (true);
		GameObject thePanel = victory;
		if(!wasRight) 
		{
			thePanel = fail;
		}
		StartCoroutine(displayGameObjectForSomeTime(thePanel, 3f));

		// TODO: say something about how the player was right or wrong
		Debug.Log ("You were " + (wasRight ? "right" : "wrong"));
		gotoNextCharacter ();
	}

	public void rejectCharacter() 
	{
		var wasRight = engine.makeDecision (false);
		GameObject thePanel = victory;
		if(!wasRight) 
		{
			thePanel = fail;
		}
		StartCoroutine(displayGameObjectForSomeTime(thePanel, 3f));

		// TODO: say something about how the player was right or wrong
		Debug.Log ("You were " + (wasRight ? "right" : "wrong"));
		gotoNextCharacter ();
	}

	public void gotoNextCharacter() 
	{
		hideCardPanels ();
		hideCrystalOnBooth ();
		engine.gotoNextCharacter ();

		Debug.Log("MainInterfaceManager::gotoNextCharacter calls displayCrystalOnBooth");
		displayCrystalOnBooth(engine.getCurrentCharacter());

		updateWealth();
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
		Debug.Log("MainInterfaceManager::displayCrystalOnBooth("+character.picture+")");
		Sprite sprite = Resources.Load<Sprite>(_baseName+character.picture);
		displayCrystalOnBooth(sprite);
	}
	
	public void displayCrystalOnBooth(Sprite sprite)
	{
		Debug.Log("MainInterfaceManager::displayCrystal("+sprite.name+")");
		crystalCandidateZone.gameObject.SetActive(true);
		crystalCandidateZone.displayCrystal(sprite);    
    }

	public void hideCrystalOnBooth()
	{
		crystalCandidateZone.gameObject.SetActive (false);
	}

	public void onPressIDCard()
	{
		Debug.Log("MainInterfaceManager::onPressIDCard");
		resultPanel.displayIDCard(engine.getCurrentCharacter());
	}
	
	public void onPressAnalyzeDensity()
	{
		Debug.Log ("onPressAnalyzeDensity");
		if(!densityCardPanel.gameObject.activeSelf)
		{
			densityCardPanel.gameObject.SetActive (true);
			bool performedTest = engine.analyzeDensity();
			if(!performedTest) return;

			densityCardPanel.display(engine.getCurrentTestResults());
			updateWealth();
    }
		else
		{
			densityCardPanel.gameObject.SetActive (false);
		}
	}
	public void onPressAnalyzeStructure()
	{
		Debug.Log ("onPressAnalyzeStructure");
		if(!structureCardPanel.gameObject.activeSelf)
		{
			Debug.LogError ("onPressAnalyzeStructure inactive");
			structureCardPanel.gameObject.SetActive (true);
			bool performedTest = engine.analyzeStructure();
			if(!performedTest) return;

			structureCardPanel.display (engine.getCurrentTestResults());
			updateWealth();
    }
		else
		{
			Debug.LogError ("onPressAnalyzeStructure active");
			structureCardPanel.gameObject.SetActive(false);
		}
	}
	public void onPressAnalyzeTransparency()
	{
		Debug.Log ("onPressAnalyzeTransparency");
		if(!transparencyCardPanel.gameObject.activeSelf)
		{
			transparencyCardPanel.gameObject.SetActive (true);
			bool performedTest = engine.analyzeTransparency();
			if(!performedTest) return;

			transparencyCardPanel.display (engine.getCurrentTestResults());
			updateWealth();
    }
		else
		{
			transparencyCardPanel.gameObject.SetActive(false);
		}
	}
	public void onPressAnalyzeHardness()
	{
		Debug.Log ("onPressAnalyzeHardness");
		if(!hardnessCardPanel.gameObject.activeSelf)
		{
			hardnessCardPanel.gameObject.SetActive (true);
			bool performedTest = engine.analyzeHardness();
			if(!performedTest) return;

			hardnessCardPanel.display (engine.getCurrentTestResults());
			updateWealth();
		}
		else
		{
			hardnessCardPanel.gameObject.SetActive (false);
		}
	}
	public void onPressAnalyzeColor()
	{
		Debug.Log ("onPressAnalyzeColor");
		/*
		if(!colorCardPanel.gameObject.activeSelf)
		{
			colorCardPanel.gameObject.SetActive (true);
			bool performedTest = engine.analyzeColor();
			if(!performedTest) return;

			updateWealth();
			colorCardPanel.display (engine.getCurrentTestResults());
		}
		else
		{
			colorCardPanel.gameObject.SetActive (false);
		}
		*/
	}

	public void updateWealth() 
	{
		wealthPanel.display(engine.getWealth());
	}
  
	
	// Use this for initialization
	void Start () {
		gotoNextCharacter ();
		_buttonStyle = new GUIStyle();
		_buttonStyle.fixedWidth = 0f;
		_buttonStyle.fixedHeight = 0f;
		_buttonStyle.border = new RectOffset(0, 0, 0, 0);

		makeButtonLabels ();

		updateWealth();
	}	

	// Update is called once per frame
	void Update () {
		_timeSinceLastPressed += Time.deltaTime;
		//booth
		if(Input.GetKey(KeyCode.B) && (_timeSinceLastPressed > _timeBetweenTwoPressed))
		{
			//int i = Mathf.FloorToInt(Random.value*2+1);
			_currentIndex = (_currentIndex+1) %3 + 1;
			string name = _currentIndex.ToString();
			Debug.Log("display "+_currentIndex+" ie "+name);
			Sprite sprite = Resources.Load<Sprite>(_baseName+name);
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
	public Texture2D idcardIcon;
	
	
	private static float _buttonWidth = 278f;
	private static float _buttonHeight = 125f;
	private static float _spacing = 12f;
	
	private static float targetWidth = 1920f;
	private static float targetHeight = 1080f;

	// first column 
	private static float _idcardX = 38f;
	private static float _idcardY = 649f;
	private static float _hardnessX = 38f;
	private static float _hardnessY = 785f;
	private static float _colorX = 38f;
	private static float _colorY = 919f;

	// second column
	private static float _densityX = 332f;
	private static float _densityY = 649f;
	private static float _transparencyX = 332f;
	private static float _transparencyY = 785f;
	private static float _structureX = 332f;
	private static float _structureY = 919f;
	
	private GUIStyle _buttonStyle;
    
	private Rect resizeGUI(Rect rect)
	{		
		return getResizedRect(rect.x, rect.y, rect.width, rect.height);
	}
	
	private Rect getResizedRect(float x, float y, float width, float height)
	{
		float screenWidth = width / targetWidth;
		float rectWidth = screenWidth * Screen.width;
		float screenHeight = height / targetHeight;
		float rectHeight = screenHeight * Screen.height;
		
		float rectX = (x / targetWidth) * Screen.width;
		float rectY = (y / targetHeight) * Screen.height;
		
		return new Rect(rectX, rectY, rectWidth, rectHeight);
	}
	
	void OnGUI () {
		Rect densityRect = getResizedRect(_densityX, _densityY,_buttonWidth,_buttonHeight);
		//Debug.Log("densityRect="+densityRect);
		
		Rect structureRect = getResizedRect(_structureX, _structureY,_buttonWidth,_buttonHeight);
		//Debug.Log("structureRect="+structureRect);
		
		Rect hardnessRect = getResizedRect(_hardnessX, _hardnessY,_buttonWidth,_buttonHeight);
		//Debug.Log("hardnessRect="+hardnessRect);
		
		Rect transparencyRect = getResizedRect(_transparencyX, _transparencyY,_buttonWidth,_buttonHeight);
		//Debug.Log("transparencyRect="+densityRect);
		
		Rect colorRect = getResizedRect(_colorX, _colorY,_buttonWidth,_buttonHeight);
		//Debug.Log("colorRect="+colorRect);
		
		Rect idcardRect = getResizedRect(_idcardX, _idcardY,_buttonWidth,_buttonHeight);
		//Debug.Log("idcardRect="+idcardRect);

		Rect acceptRect = getResizedRect(1675f, 486f, 165f, 162f);
		Rect rejectRect = getResizedRect(1675f, 683f, 165f, 166f);

		if(GUI.Button (densityRect, new GUIContent (), _buttonStyle))
		{
			onPressAnalyzeDensity();
		}
		if(GUI.Button (structureRect, new GUIContent (), _buttonStyle))
		{
			onPressAnalyzeStructure();
		}
		if(GUI.Button (hardnessRect, new GUIContent (), _buttonStyle))
		{
			onPressAnalyzeHardness();
		}
		if(GUI.Button (transparencyRect, new GUIContent (), _buttonStyle))
		{
			onPressAnalyzeTransparency();
		}
		if(GUI.Button (colorRect, new GUIContent (), _buttonStyle))
		{
			onPressAnalyzeColor();
		}
		if(GUI.Button (idcardRect, new GUIContent (), _buttonStyle))
		{
			onPressIDCard();
		}
		if(GUI.Button (acceptRect, new GUIContent (), _buttonStyle))
		{
			acceptCharacter();
		}
		if(GUI.Button (rejectRect, new GUIContent (), _buttonStyle))
		{
			rejectCharacter();
		}
	}

	void makeButtonLabels() 
	{
		float spacingX = 115f;
		float spacingY = 18f;

		float labelWidth = 294f;
		float labelHeight = 135f;

		float firstX = 97f;
		float secondX = firstX + labelWidth;

		float firstY = 700f;
		float secondY = firstY+labelHeight;
		float thirdY = secondY+labelHeight;


		// first column
		makeButtonLabel("Identite", 0, firstX + spacingX, firstY + spacingY);
		makeButtonLabel("Marteau", engine.getTestCost("Density"), firstX + spacingX, secondY + spacingY);
		makeButtonLabel("Lumiere noire", engine.getTestCost("Color"), firstX + spacingX, thirdY + spacingY);
		// second column
		makeButtonLabel("Eau & balance", engine.getTestCost("Density"), secondX + spacingX, firstY + spacingY);
		makeButtonLabel("Laser", engine.getTestCost("Transparency"), secondX + spacingX, secondY + spacingY);
		makeButtonLabel("Synchrotron", engine.getTestCost("Structure"), secondX + spacingX, thirdY + spacingY);
	}

	void makeButtonLabel(string name, int price, float x, float y)
	{
		GameObject buttonLabelPrefab = Resources.Load<GameObject> ("ButtonLabel");

		GameObject instance = Instantiate (buttonLabelPrefab, new Vector3 (x / 1920f, 1f - y / 1080f, 0f), Quaternion.identity) as GameObject;
		instance.transform.FindChild ("Name").guiText.text = name;
		instance.transform.FindChild ("Price").guiText.text = price > 0 ? price.ToString() + " kE" : "";
	}
}
