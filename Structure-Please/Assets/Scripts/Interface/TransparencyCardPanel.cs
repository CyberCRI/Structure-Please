using UnityEngine;
using System.Collections;

public class TransparencyCardPanel : MonoBehaviour {

	public GUIText transparencyText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void onEnable()
	{
		transparencyText.gameObject.SetActive(true);
	}
	
	void onDisable()
	{
		transparencyText.gameObject.SetActive(false);
	}

	public void display(Crystal testResults)
	{
		transparencyText.text = testResults.transparency.Value ? "Oui" : "Non";
	}
}
