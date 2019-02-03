using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : Block {
	
	public Wood() {
		isSolid   = true;
		isChanged = false;

		texture = new Vector2(1, 1);
	}
}
