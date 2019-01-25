using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt : Block {
	public Dirt() {
		isSolid   = true;
		isChanged = false;

		texture = new Vector2(1, 0);
	}
}
