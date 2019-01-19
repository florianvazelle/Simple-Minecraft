using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain {

    public void GenerateChunk(Chunk chunk){
        int size = Chunk.chunkSize;
        for(int x = 0 ; x < size ; x++){
            for(int y = 0 ; y < size ; y++){
                for(int z = 0 ; z < size ; z++){
                    chunk.blocks[x, y, z] = new Block();
                }
            }
        }
    }
}
