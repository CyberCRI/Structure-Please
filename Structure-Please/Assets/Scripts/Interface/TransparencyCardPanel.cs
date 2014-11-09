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

	public void display(Crystal testResults)
	{
		transparencyText.text = testResults.transparency.Value ? "Transparent" : "Opaque";
	}
}
