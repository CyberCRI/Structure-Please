using UnityEngine;
using System.Collections;

public class IdentityCardPanel : MonoBehaviour {

	public GUIText crystalName;
	public GUIText age;
	public GUIText chemicalSpecies;
	public GUIText structure;
	public GUIText density;
	public GUIText transparency;
	public GUIText hardness;
	public GUIText color;

	public SpriteRenderer idPicture;

	private string _baseName = "Textures/candidates/";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void displayCrystal(Character character)
	{
		Crystal pretendsToBe = character.pretendsToBe;

		crystalName.text = character.name;
		age.text = character.age.ToString();
		chemicalSpecies.text = pretendsToBe.name;
		structure.text = pretendsToBe.structure;
		density.text = pretendsToBe.density.HasValue?pretendsToBe.density.Value.ToString():"?";
		transparency.text = pretendsToBe.transparency.HasValue?(pretendsToBe.transparency.Value?"oui":"non"):"?";
		hardness.text = pretendsToBe.hardness.HasValue?pretendsToBe.hardness.Value.ToString():"?";
		color.text = pretendsToBe.color;

		string name = _baseName+character.picture;
		Sprite sprite = Resources.Load<Sprite>(name);
		idPicture.sprite = sprite;
	}
}
