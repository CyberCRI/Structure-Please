using UnityEngine;
using System.Collections;

public class Character {
	public string name;
	public int age;
	public string picture;
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
