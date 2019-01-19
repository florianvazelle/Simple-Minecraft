using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {
    
	public World world;

    void Start(){
		world.CreateChunk(0, 0, 0);
        world.CreateChunk(16, 0, 0);
        world.CreateChunk(0, 16, 0);
        world.CreateChunk(0, 0, 16);
        //world.DestroyChunk(0, 0, 0);
	}

    void Update(){}
}
