using UnityEngine;
using System.Collections;

public class ColorCardPanel : MonoBehaviour {

	public GUIText colorText;
	
	
	void onEnable()
	{
		colorText.gameObject.SetActive(true);
	}
	
	void onDisable()
	{
		colorText.gameObject.SetActive(false);
	}

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
