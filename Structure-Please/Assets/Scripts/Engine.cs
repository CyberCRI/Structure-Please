using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Engine : MonoBehaviour {
	Dictionary<string, Crystal> crystals;
	List<Character> characters;
	Dictionary<string, int> testCosts;

	int nextCharacterIndex = 0;
	
	Character currentCharacter;
	Crystal currentTestResults;
	int wealth = 20;
	
	void Awake () 
	{
		// TODO: load crystals from CSV file
		crystals = new Dictionary<string, Crystal> ();
		var crystal = new Crystal ();
		crystal.name = "gold";
		crystals.Add ("Gold", crystal);
		crystal = new Crystal ();
		crystal.name = "diamond";
		crystals.Add ("Diamond", crystal);

		// TODO: load characters from CSV file
		characters = new List<Character>();
		var character = new Character();
		character.name = "Bob";
		character.reallyIs = crystals["Gold"];
		character.pretendsToBe = crystals["Diamond"];
		characters.Add (character);

		// TODO: load costs from CSV file
		testCosts = new Dictionary<string, int> ();
		testCosts.Add ("Density", 1);
		testCosts.Add ("Transparency", 2);
		testCosts.Add ("Structure", 8);
		testCosts.Add ("Hardness", 4);
		testCosts.Add ("Color", 5);
	}


	// Getters
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

	
	public void gotoNextCharacter() 
	{
		currentCharacter = characters [nextCharacterIndex++];
		currentTestResults = new Crystal ();
	}
	

	// Returns true if decision is correct, false otherwise
	public bool makeDecision(bool accept) 
	{
		bool isReal = currentCharacter.pretendsToBe.name == currentCharacter.reallyIs.name;
		bool isCorrect = isReal == accept;
		if (isCorrect) 
		{
			wealth += currentCharacter.prize;
		} 
		else 
		{

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
		if (string.IsNullOrEmpty(currentTestResults.structure)) return false;
		
		currentTestResults.structure = currentCharacter.reallyIs.structure;
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
}
