using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

	//Prefab d'un chunk pour pouvoir en instancier
	public GameObject chunkPrefab;
   
	//Dictionnaire de tout les chunks actifs, en fonction de leur position dans le monde
	private Dictionary<Vector3Int, Chunk> chunks = new Dictionary<Vector3Int, Chunk>();

	public void CreateChunk(int x, int y, int z){
		Vector3Int chunkPos = new Vector3Int(x, y, z);
		GameObject newChunk = Instantiate(chunkPrefab, chunkPos, Quaternion.identity) as GameObject;

		Chunk chunk = newChunk.GetComponent<Chunk>();
		chunk.World = this;
		chunk.ChunkPos = chunkPos;

        Terrain terrain = new Terrain();
        terrain.GenerateChunk(chunk, x, y, z);
	}

	public Block GetBlock(int x, int y, int z){
		Chunk chunk = GetChunk(x, y, z);
		if (chunk != null) return chunk.GetBlock(x - chunk.ChunkPos.x, y - chunk.ChunkPos.y, z - chunk.ChunkPos.z);
		else return new Air();
	}

	private Chunk GetChunk(int x, int y, int z){
		int size = Chunk.chunkSize;
		int cx = Mathf.FloorToInt(x / size) * size;
		int cy = Mathf.FloorToInt(y / size) * size;
		int cz = Mathf.FloorToInt(z / size) * size;

		Chunk chunk = null;
		chunks.TryGetValue(new Vector3Int(cx, cy, cz), out chunk);
		return chunk;
	}
}
