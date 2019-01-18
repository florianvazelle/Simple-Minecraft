using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour {

    public void GenerateChunk(Chunk chunk, int x, int y, int z){
        int size = Chunk.chunkSize;
        for(int i = x ; i < x + size ; i++){
            for(int j = y ; j < y + size ; j++){
                for(int k = z ; k < z + size ; k++){
                    chunk.blocks[i, j, k] = new Block();
                }
            }
        }
    }
}
