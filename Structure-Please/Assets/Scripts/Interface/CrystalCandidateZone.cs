using UnityEngine;
using System.Collections;

public class CrystalCandidateZone : MonoBehaviour {

	public SpriteRenderer candidate;

	public void displayCrystal(Sprite sprite)
	{
		Debug.Log("CrystalCandidateZone::displayCrystal("+sprite.name+")");
		candidate.sprite = sprite;
	}

	// Use this for initialization
	void Start () {

	}
}
