using UnityEngine;
using System.Collections;

public class CrystalCandidateZone : MonoBehaviour {

	public SpriteRenderer candidate;

	public void displayCrystal(Sprite sprite)
	{
		candidate.sprite = sprite;
	}

	// Use this for initialization
	void Start () {

	}
}
