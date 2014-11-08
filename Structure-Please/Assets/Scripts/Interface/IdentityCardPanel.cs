using UnityEngine;
using System.Collections;

public class IdentityCardPanel : MonoBehaviour {

	public GUIText crystalName;
	public GUIText weight;
	public GUIText polarization;
	public GUIText microscopicAspect;
	public GUIText geometry;

	public SpriteRenderer idPicture;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void displayNextCrystal()
	{
		crystalName.text = "John";
		weight.text = "32 kg";
		polarization.text = "Oui";
		microscopicAspect.text = "Lisse";
		geometry.text = "rhomboédrique";

		int i = Mathf.FloorToInt(Random.value*2+1);
		Sprite sprite = Resources.Load<Sprite>("Textures/candidates/"+i);
		idPicture.sprite = sprite;
	}
}
