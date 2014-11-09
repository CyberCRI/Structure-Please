using UnityEngine;
using System.Collections;

public class HardnessCardPanel : MonoBehaviour {

	public GUIText hardnessText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void display(Crystal testResults)
	{
		hardnessText.text = testResults.hardness.Value.ToString();
	}
}
