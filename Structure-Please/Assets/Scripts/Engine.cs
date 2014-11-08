using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Engine : MonoBehaviour {
	Dictionary<string, Crystal> crystals;
	List<Character> characters;


	// Use this for initialization
	void Start () {
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
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public float analyzeMass() {
		// TODO
		return 43;
	}

	public string analyzeStructure() {
		// TODO
		return "structure.png";
	}

	public string analyzeAppearance() {
		// TODO
		return "appearance.png";
	}

	public bool analyzePolarity() {
		// TODO
		return true;
	}
}
