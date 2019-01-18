using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {
    
	public World world;

    void Start(){
		world.CreateChunk(0, 0, 0);
	}

    void Update(){}
}
