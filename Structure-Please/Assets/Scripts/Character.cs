using UnityEngine;
using System.Collections;

public class Character {
	public string name;
	public string image;
	public int prize;
	public Crystal pretendsToBe;
	public Crystal reallyIs;

	public Character clone() {
		Character cloned = new Character ();
		cloned.name = this.name;
		cloned.pretendsToBe = this.pretendsToBe.clone ();
		cloned.reallyIs = this.reallyIs.clone ();
		return cloned;
	}
}
