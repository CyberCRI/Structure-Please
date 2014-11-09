using UnityEngine;
using System.Collections;

public class DensityCardPanel : MonoBehaviour {

	public GUIText massText;
	public GUIText volumeText;
	public GUIText densityText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void onEnable()
	{
		massText.gameObject.SetActive(true);
		volumeText.gameObject.SetActive(true);
		densityText.gameObject.SetActive(true);
	}
	
	void onDisable()
	{
		massText.gameObject.SetActive(false);
		volumeText.gameObject.SetActive(false);
		densityText.gameObject.SetActive(false);
	}

	public void display(Crystal testResults)
	{
		var volume = (int) Random.Range (0.06f, 0.1f);
		var mass = volume * testResults.density;

		volumeText.text = volume.ToString() + "l";
		massText.text = mass.ToString() + "kg";
		densityText.text = testResults.density.ToString();// + "kg/l";
	}
}
