using UnityEngine;
using System.Collections;

public class StructureCardPanel : MonoBehaviour {

	public GUIText structureText;
	public SpriteRenderer idPicture;
	
	private string _baseName = "Textures/structures/";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void display(Crystal testResults)
	{
		structureText.text = testResults.structure;

		string name = testResults.picture;
		Sprite sprite = Resources.Load<Sprite>(_baseName+name);
		idPicture.sprite = sprite;

	}
}
