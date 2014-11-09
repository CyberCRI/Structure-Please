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

		Debug.Log("MainInterfaceManager::gotoNextCharacter calls displayCrystalOnBooth");
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
			structureCardPanel.gameObject.SetActive (true);
			bool performedTest = engine.analyzeStructure();
			if(!performedTest) return;

			structureCardPanel.display (engine.getCurrentTestResults());
		}
		else
		{
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
		}
		else
		{
			hardnessCardPanel.gameObject.SetActive (false);
		}
	}
	public void onPressAnalyzeColor()
	{
		Debug.Log ("onPressAnalyzeColor");
		if(!colorCardPanel.gameObject.activeSelf)
		{
			colorCardPanel.gameObject.SetActive (true);
			bool performedTest = engine.analyzeColor();
			if(!performedTest) return;

			colorCardPanel.display (engine.getCurrentTestResults());
		}
		else
		{
			colorCardPanel.gameObject.SetActive (false);
		}
	}
  
	
	// Use this for initialization
	void Start () {
		gotoNextCharacter ();
		_buttonStyle = new GUIStyle();
		_buttonStyle.fixedWidth = 0f;
		_buttonStyle.fixedHeight = 0f;
		_buttonStyle.border = new RectOffset(0, 0, 0, 0);
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

	private static float _densityX = 120f;
	private static float _densityY = targetHeight-(_buttonHeight+_spacing);
	private static float _structureX = _densityX+_buttonWidth+_spacing;
	private static float _structureY = targetHeight-(_buttonHeight+_spacing);
	private static float _hardnessX = _densityX+2*(_buttonWidth+_spacing);
	private static float _hardnessY = targetHeight-(_buttonHeight+_spacing);

	private static float _transparencyX = _densityX;
	private static float _transparencyY = targetHeight-2*(_buttonHeight+_spacing);
	private static float _colorX = _densityX+_buttonWidth+_spacing;
	private static float _colorY = targetHeight-2*(_buttonHeight+_spacing);
	private static float _idcardX = _densityX+2*(_buttonWidth+_spacing);
	private static float _idcardY = targetHeight-2*(_buttonHeight+_spacing);
	
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

		if(GUI.Button (densityRect, new GUIContent (densityIcon, "Pour évaluer la densité"), _buttonStyle))
		{
			onPressAnalyzeDensity();
		}
		if(GUI.Button (structureRect, new GUIContent (structureIcon, "Pour évaluer la géométrie"), _buttonStyle))
		{
			onPressAnalyzeStructure();
		}
		if(GUI.Button (hardnessRect, new GUIContent (hardnessIcon, "Pour évaluer la dureté"), _buttonStyle))
		{
			onPressAnalyzeHardness();
		}
		if(GUI.Button (transparencyRect, new GUIContent (transparencyIcon, "Pour évaluer la transparence"), _buttonStyle))
		{
			onPressAnalyzeTransparency();
		}
		if(GUI.Button (colorRect, new GUIContent (colorIcon, "Pour évaluer la couleur"), _buttonStyle))
		{
			onPressAnalyzeColor();
		}
		if(GUI.Button (idcardRect, new GUIContent (idcardIcon, "Pour afficher la carte d'identité du cristal"), _buttonStyle))
		{
			onPressIDCard();
		}
	}
}
