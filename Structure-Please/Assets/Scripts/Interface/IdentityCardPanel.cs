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
	
	void onEnable()
	{
		crystalName.gameObject.SetActive(true);
		age.gameObject.SetActive(true);
		chemicalSpecies.gameObject.SetActive(true);
		structure.gameObject.SetActive(true);
		density.gameObject.SetActive(true);
		transparency.gameObject.SetActive(true);
		hardness.gameObject.SetActive(true);
		color.gameObject.SetActive(true);
	}
	
	void onDisable()
	{
		crystalName.gameObject.SetActive(false);
		age.gameObject.SetActive(false);
		chemicalSpecies.gameObject.SetActive(false);
		structure.gameObject.SetActive(false);
		density.gameObject.SetActive(false);
		transparency.gameObject.SetActive(false);
		hardness.gameObject.SetActive(false);
		color.gameObject.SetActive(true);
	}

	public void displayCrystal(Character character)
	{
		Debug.Log("IdentityCardPanel::displayCrystal("+character+")");
		Crystal pretendsToBe = character.pretendsToBe;

		crystalName.text = character.name;
		age.text = character.age.ToString();
		chemicalSpecies.text = pretendsToBe.name;
		structure.text = pretendsToBe.structure;
		density.text = pretendsToBe.density.HasValue?pretendsToBe.density.Value.ToString():"?";
		transparency.text = pretendsToBe.transparency.HasValue?(pretendsToBe.transparency.Value?"oui":"non"):"?";
		hardness.text = pretendsToBe.hardness.HasValue?pretendsToBe.hardness.Value.ToString():"?";
		color.text = pretendsToBe.color;

		string name = character.picture;
		Sprite sprite = Resources.Load<Sprite>(_baseName+name);
		Debug.Log("IdentityCardPanel::displayCrystal("+character+") name="+name+", sprite="+sprite);
		idPicture.sprite = sprite;
	}
}
