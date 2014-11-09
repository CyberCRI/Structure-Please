using UnityEngine;
using System.Collections;

public class HardnessCardPanel : MonoBehaviour {

	public GUIText hardnessText;
	
	
	void onEnable()
	{
		hardnessText.gameObject.SetActive(true);
	}
	
	void onDisable()
	{
		hardnessText.gameObject.SetActive(false);
	}

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
