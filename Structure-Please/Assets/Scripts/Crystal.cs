using UnityEngine;
using System.Collections;

public class Crystal {
	public string name;
	public string picture;
	public float? density;
	public string structure;
	public bool? transparency;
	public float? hardness;
	public string color;
	public bool isPrecious;

	public Crystal clone() {
		return (Crystal)this.MemberwiseClone ();
	}
}
