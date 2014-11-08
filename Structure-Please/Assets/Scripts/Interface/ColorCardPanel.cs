using UnityEngine;
using System.Collections;

public class ColorCardPanel : MonoBehaviour {

	public GUIText colorText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void display(Crystal testResults)
	{
		colorText.text = testResults.color;
	}
}
