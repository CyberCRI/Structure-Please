using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Engine : MonoBehaviour {
	TextAsset crystalsCsv;
	TextAsset charactersCsv;
	TextAsset testsCsv;
	

	// Private attributes:

	Dictionary<string, Crystal> crystals;
	List<Character> characters;
	Dictionary<string, int> testCosts;

	int nextCharacterIndex = 0;
	
	Character currentCharacter;
	Crystal currentTestResults;
	int wealth = 20;


	// Getters:

	public Character getCurrentCharacter() 
	{
		return currentCharacter;
	}
	
	public Crystal getCurrentTestResults() 
	{
		return currentTestResults;
	}
	
	public int getWealth() 
	{
		return wealth;
	}

	public int getTestCost(string test) 
	{
		return testCosts [test];
	}


	// Public methods:

	public void gotoNextCharacter() 
	{
		nextCharacterIndex = nextCharacterIndex > characters.Count-1 ? 0 : nextCharacterIndex;
		currentCharacter = characters [nextCharacterIndex++];
		currentTestResults = new Crystal ();
	}
	

	// Returns true if decision is correct, false otherwise
	//TODO manage false positives and negatives
	public bool makeDecision(bool accept) 
	{
		//bool isReal = currentCharacter.pretendsToBe.name == currentCharacter.reallyIs.name;
		//bool isCorrect = isReal == accept;

		bool isCorrect = currentCharacter.reallyIs.isPrecious;

		if (isCorrect) 
		{
			Debug.LogError("isCorrect");
			wealth += currentCharacter.prize;
		} 
		else 
		{
			Debug.LogError("NOOOOOT");
			wealth -= currentCharacter.prize;
		}
		return isCorrect;
	}

	// Returns true if test is performed, else false
	public bool analyzeDensity() 
	{
		if (currentTestResults.density.HasValue) return false;

		currentTestResults.density = currentCharacter.reallyIs.density;
		wealth -= testCosts["Density"];
		return true;
	}

	// Returns true if test is performed, else false
	public bool analyzeStructure() 
	{
		if (!string.IsNullOrEmpty(currentTestResults.structure)) return false;
		
		currentTestResults.structure = currentCharacter.reallyIs.structure;
		Debug.LogError("currentTestResults.structure="+currentTestResults.structure);
		wealth -= testCosts["Structure"];
		return true;
	}

	// Returns true if test is performed, else false
	public bool analyzeTransparency() 
	{
		if (currentTestResults.transparency.HasValue) return false;
		
		currentTestResults.transparency = currentCharacter.reallyIs.transparency;
		wealth -= testCosts["Transparency"];
		return true;
	}

	// Returns true if test is performed, else false
	public bool analyzeHardness() 
	{
		if (currentTestResults.hardness.HasValue) return false;
		
		currentTestResults.hardness = currentCharacter.reallyIs.hardness;
		wealth -= testCosts["Hardness"];
		return true;
	}

	// Returns true if test is performed, else false
	public bool analyzeColor() 
	{
		if (string.IsNullOrEmpty(currentTestResults.color)) return false;

		currentTestResults.color = currentCharacter.reallyIs.color;
		wealth -= testCosts["Color"];
		return true;
	}


	// Internal methods:

	void Awake () 
	{
		// Hardcoded values
		crystalsCsv = Resources.Load<TextAsset>("CSV/crystals");
		charactersCsv = Resources.Load<TextAsset> ("CSV/characters");
		testsCsv = Resources.Load<TextAsset> ("CSV/tests");
	
		loadData ();
	}

	void loadData()
	{
		// load crystals
		var crystalsData = CsvLoader.loadCsv (crystalsCsv.text);
		crystals = new Dictionary<string, Crystal> ();
		foreach( var crystalData in crystalsData ) 
		{
			var crystal = new Crystal ();

			crystal.name = crystalData["Name"];
			crystal.picture = crystalData["Picture"];
			crystal.density = float.Parse(crystalData["Density"]);
			crystal.structure = crystalData["Structure"];
			crystal.transparency = bool.Parse(crystalData["Transparency"]);
			crystal.hardness = float.Parse(crystalData["Hardness"]);
			crystal.color = crystalData["Color"];
			crystal.isPrecious = bool.Parse (crystalData["IsPrecious"]);

			crystals[crystal.name] = crystal;
		}

		// load characters
		var charactersData = CsvLoader.loadCsv (charactersCsv.text);
		characters = new List<Character> ();
		foreach (var characterData in charactersData) 
		{
			var character = new Character();

			character.name = characterData["Name"];
			character.age = int.Parse(characterData["Age"]);
			character.prize = int.Parse(characterData["Prize"]);
			character.picture = characterData["Picture"];
			character.pretendsToBe = crystals[characterData["PretendsToBe"]];
			character.reallyIs = crystals[characterData["ReallyIs"]];

			characters.Add(character);
		}

		// load tests
		var testsData = CsvLoader.loadCsv (testsCsv.text);
		testCosts = new Dictionary<string, int> ();
		foreach (var testData in testsData) 
		{
			testCosts[testData["Property"]] = int.Parse(testData["Cost"]);
		}
	}
}
