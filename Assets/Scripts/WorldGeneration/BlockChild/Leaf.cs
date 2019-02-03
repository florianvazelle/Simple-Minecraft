using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : Block {

	public Leaf() {
		isSolid   = true;
		isChanged = false;

		texture = new Vector2(0, 1);
	}
}
