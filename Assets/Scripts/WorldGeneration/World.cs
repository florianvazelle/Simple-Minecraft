using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

	//Prefab d'un chunk pour pouvoir en instancier
	public GameObject chunkPrefab;

	//Dictionnaire de tout les chunks actifs, en fonction de leur position dans le monde
	private Dictionary<Vector3Int, Chunk> chunks = new Dictionary<Vector3Int, Chunk>();

	public Dictionary<Vector3Int, Chunk> Chunks {
		get => chunks;
	}

	public void CreateChunk(int x, int y, int z){
		Vector3Int chunkPos = new Vector3Int(x, y, z);
		GameObject newChunk = Instantiate(chunkPrefab, chunkPos, Quaternion.identity) as GameObject;

		Chunk chunk = newChunk.GetComponent<Chunk>();
		chunk.World = this;
		chunk.ChunkPos = chunkPos;

		chunks.Add(chunkPos, chunk);

		Terrain terrain = new Terrain();
		terrain.GenerateChunk(chunk);

		//chunk.SetBlocksUnmodified();
	}

	public Block GetBlock(int x, int y, int z){
		Chunk chunk = GetChunk(x, y, z);
		if (chunk != null) return chunk.GetBlock(x - chunk.ChunkPos.x, y - chunk.ChunkPos.y, z - chunk.ChunkPos.z);
		else return new Air();
	}

	public Chunk GetChunk(int x, int y, int z){
		int size = Chunk.chunkSize;
		int cx = Mathf.FloorToInt(x / (float)size) * size;
		int cy = Mathf.FloorToInt(y / (float)size) * size;
		int cz = Mathf.FloorToInt(z / (float)size) * size;

		Chunk chunk = null;
		chunks.TryGetValue(new Vector3Int(cx, cy, cz), out chunk);
		return chunk;
	}

	public void DestroyChunk(int x, int y, int z){
		Vector3Int chunkPos = new Vector3Int(x, y, z);
		Chunk chunk = null;
		if (chunks.TryGetValue(chunkPos, out chunk)){
			Destroy(chunk.gameObject);
			chunks.Remove(chunkPos);
		}
	}

	public void SetBlock(int x, int y, int z, Block block){
		int size = Chunk.chunkSize;
		Chunk chunk = GetChunk(x, y, z);

		if (chunk != null){
			chunk.SetBlock(x - chunk.ChunkPos.x, y - chunk.ChunkPos.y, z - chunk.ChunkPos.z, block);
			chunk.update = true;

			UpdateIfEqual(x - chunk.ChunkPos.x, 0       , new Vector3Int(x - 1, y, z));
			UpdateIfEqual(x - chunk.ChunkPos.x, size - 1, new Vector3Int(x + 1, y, z));
			UpdateIfEqual(y - chunk.ChunkPos.y, 0       , new Vector3Int(x, y - 1, z));
			UpdateIfEqual(y - chunk.ChunkPos.y, size - 1, new Vector3Int(x, y + 1, z));
			UpdateIfEqual(z - chunk.ChunkPos.z, 0       , new Vector3Int(x, y, z - 1));
			UpdateIfEqual(z - chunk.ChunkPos.z, size - 1, new Vector3Int(x, y, z + 1));
		}
	}

	private void UpdateIfEqual(int value1, int value2, Vector3Int chunkPos){
		if (value1 == value2){
			Chunk chunk = GetChunk(chunkPos.x, chunkPos.y, chunkPos.z);
			if (chunk != null) chunk.update = true;
		}
	}
}
