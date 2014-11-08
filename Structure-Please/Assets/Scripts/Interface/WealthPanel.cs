using UnityEngine;
using System.Collections;

public class WealthPanel : MonoBehaviour {

	public GUIText wealthText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void display(int wealth)
	{
		wealthText.text = wealth.ToString() + " k€";
	}
}
