﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

	private static Vector3Int[] chunkPositions = {
		new Vector3Int( 0, 0,  0), new Vector3Int(-1, 0,  0), new Vector3Int( 0, 0, -1), new Vector3Int( 0, 0,  1), new Vector3Int( 1, 0,  0),
		new Vector3Int(-1, 0, -1), new Vector3Int(-1, 0,  1), new Vector3Int( 1, 0, -1), new Vector3Int( 1, 0,  1), new Vector3Int(-2, 0,  0),
		new Vector3Int( 0, 0, -2), new Vector3Int( 0, 0,  2), new Vector3Int( 2, 0,  0), new Vector3Int(-2, 0, -1), new Vector3Int(-2, 0,  1),
		new Vector3Int(-1, 0, -2), new Vector3Int(-1, 0,  2), new Vector3Int( 1, 0, -2), new Vector3Int( 1, 0,  2), new Vector3Int( 2, 0, -1),
		new Vector3Int( 2, 0,  1), new Vector3Int(-2, 0, -2), new Vector3Int(-2, 0,  2), new Vector3Int( 2, 0, -2), new Vector3Int( 2, 0,  2),
		new Vector3Int(-3, 0,  0), new Vector3Int( 0, 0, -3), new Vector3Int( 0, 0,  3), new Vector3Int( 3, 0,  0), new Vector3Int(-3, 0, -1),
		new Vector3Int(-3, 0,  1), new Vector3Int(-1, 0, -3), new Vector3Int(-1, 0,  3), new Vector3Int( 1, 0, -3), new Vector3Int( 1, 0,  3),
		new Vector3Int( 3, 0, -1), new Vector3Int( 3, 0,  1), new Vector3Int(-3, 0, -2), new Vector3Int(-3, 0,  2), new Vector3Int(-2, 0, -3),
		new Vector3Int(-2, 0,  3), new Vector3Int( 2, 0, -3), new Vector3Int( 2, 0,  3), new Vector3Int( 3, 0, -2), new Vector3Int( 3, 0,  2),
		new Vector3Int(-4, 0,  0), new Vector3Int( 0, 0, -4), new Vector3Int( 0, 0,  4), new Vector3Int( 4, 0,  0), new Vector3Int(-4, 0, -1),
		new Vector3Int(-4, 0,  1), new Vector3Int(-1, 0, -4), new Vector3Int(-1, 0,  4), new Vector3Int( 1, 0, -4), new Vector3Int( 1, 0,  4),
		new Vector3Int( 4, 0, -1), new Vector3Int( 4, 0,  1), new Vector3Int(-3, 0, -3), new Vector3Int(-3, 0,  3), new Vector3Int( 3, 0, -3),
		new Vector3Int( 3, 0,  3), new Vector3Int(-4, 0, -2), new Vector3Int(-4, 0,  2), new Vector3Int(-2, 0, -4), new Vector3Int(-2, 0,  4),
		new Vector3Int( 2, 0, -4), new Vector3Int( 2, 0,  4), new Vector3Int( 4, 0, -2), new Vector3Int( 4, 0,  2), new Vector3Int(-5, 0,  0),
		new Vector3Int(-4, 0, -3), new Vector3Int(-4, 0,  3), new Vector3Int(-3, 0, -4), new Vector3Int(-3, 0,  4), new Vector3Int( 0, 0, -5),
		new Vector3Int( 0, 0,  5), new Vector3Int( 3, 0, -4), new Vector3Int( 3, 0,  4), new Vector3Int( 4, 0, -3), new Vector3Int( 4, 0,  3),
		new Vector3Int( 5, 0,  0), new Vector3Int(-5, 0, -1), new Vector3Int(-5, 0,  1), new Vector3Int(-1, 0, -5), new Vector3Int(-1, 0,  5),
		new Vector3Int( 1, 0, -5), new Vector3Int( 1, 0,  5), new Vector3Int( 5, 0, -1), new Vector3Int( 5, 0,  1), new Vector3Int(-5, 0, -2),
		new Vector3Int(-5, 0,  2), new Vector3Int(-2, 0, -5), new Vector3Int(-2, 0,  5), new Vector3Int( 2, 0, -5), new Vector3Int( 2, 0,  5),
		new Vector3Int( 5, 0, -2), new Vector3Int( 5, 0,  2), new Vector3Int(-4, 0, -4), new Vector3Int(-4, 0,  4), new Vector3Int( 4, 0, -4),
		new Vector3Int( 4, 0,  4), new Vector3Int(-5, 0, -3), new Vector3Int(-5, 0,  3), new Vector3Int(-3, 0, -5), new Vector3Int(-3, 0,  5),
		new Vector3Int( 3, 0, -5), new Vector3Int( 3, 0,  5), new Vector3Int( 5, 0, -3), new Vector3Int( 5, 0,  3), new Vector3Int(-6, 0,  0),
		new Vector3Int( 0, 0, -6), new Vector3Int( 0, 0,  6), new Vector3Int( 6, 0,  0), new Vector3Int(-6, 0, -1), new Vector3Int(-6, 0,  1),
		new Vector3Int(-1, 0, -6), new Vector3Int(-1, 0,  6), new Vector3Int( 1, 0, -6), new Vector3Int( 1, 0,  6), new Vector3Int( 6, 0, -1),
		new Vector3Int( 6, 0,  1), new Vector3Int(-6, 0, -2), new Vector3Int(-6, 0,  2), new Vector3Int(-2, 0, -6), new Vector3Int(-2, 0,  6),
		new Vector3Int( 2, 0, -6), new Vector3Int( 2, 0,  6), new Vector3Int( 6, 0, -2), new Vector3Int( 6, 0,  2), new Vector3Int(-5, 0, -4),
		new Vector3Int(-5, 0,  4), new Vector3Int(-4, 0, -5), new Vector3Int(-4, 0,  5), new Vector3Int( 4, 0, -5), new Vector3Int( 4, 0,  5),
		new Vector3Int( 5, 0, -4), new Vector3Int( 5, 0,  4), new Vector3Int(-6, 0, -3), new Vector3Int(-6, 0,  3), new Vector3Int(-3, 0, -6),
		new Vector3Int(-3, 0,  6), new Vector3Int( 3, 0, -6), new Vector3Int( 3, 0,  6), new Vector3Int( 6, 0, -3), new Vector3Int( 6, 0,  3),
		new Vector3Int(-7, 0,  0), new Vector3Int( 0, 0, -7), new Vector3Int( 0, 0,  7), new Vector3Int( 7, 0,  0), new Vector3Int(-7, 0, -1),
		new Vector3Int(-7, 0,  1), new Vector3Int(-5, 0, -5), new Vector3Int(-5, 0,  5), new Vector3Int(-1, 0, -7), new Vector3Int(-1, 0,  7),
		new Vector3Int( 1, 0, -7), new Vector3Int( 1, 0,  7), new Vector3Int( 5, 0, -5), new Vector3Int( 5, 0,  5), new Vector3Int( 7, 0, -1),
		new Vector3Int( 7, 0,  1), new Vector3Int(-6, 0, -4), new Vector3Int(-6, 0,  4), new Vector3Int(-4, 0, -6), new Vector3Int(-4, 0,  6),
		new Vector3Int( 4, 0, -6), new Vector3Int( 4, 0,  6), new Vector3Int( 6, 0, -4), new Vector3Int( 6, 0,  4), new Vector3Int(-7, 0, -2),
		new Vector3Int(-7, 0,  2), new Vector3Int(-2, 0, -7), new Vector3Int(-2, 0,  7), new Vector3Int( 2, 0, -7), new Vector3Int( 2, 0,  7),
		new Vector3Int( 7, 0, -2), new Vector3Int( 7, 0,  2), new Vector3Int(-7, 0, -3), new Vector3Int(-7, 0,  3), new Vector3Int(-3, 0, -7),
		new Vector3Int(-3, 0,  7), new Vector3Int( 3, 0, -7), new Vector3Int( 3, 0,  7), new Vector3Int( 7, 0, -3), new Vector3Int( 7, 0,  3),
		new Vector3Int(-6, 0, -5), new Vector3Int(-6, 0,  5), new Vector3Int(-5, 0, -6), new Vector3Int(-5, 0,  6), new Vector3Int( 5, 0, -6),
		new Vector3Int( 5, 0,  6), new Vector3Int( 6, 0, -5), new Vector3Int( 6, 0,  5) };

	public World world;

	private List<Vector3Int> updateList = new List<Vector3Int>();
	private List<Vector3Int> buildList = new List<Vector3Int>();

	private int timer = 0;

	void Start(){
		Simplex.Noise.Seed = Random.Range(100000, 999999);
	}

	void Update(){
		DeleteChunks();
		FindChunksToLoad();
		LoadAndRenderChunks();
	}

	private void FindChunksToLoad(){
		int size = Chunk.chunkSize;
		Vector3Int chunkPlayer = new Vector3Int(
			Mathf.FloorToInt(transform.position.x / Chunk.chunkSize) * Chunk.chunkSize,
			Mathf.FloorToInt(transform.position.y / Chunk.chunkSize) * Chunk.chunkSize,
			Mathf.FloorToInt(transform.position.z / Chunk.chunkSize) * Chunk.chunkSize
		);

		if (buildList.Count == 0) {
			for (int i = 0; i < chunkPositions.Length; i++){
				Vector3Int newChunkPos = new Vector3Int(chunkPositions[i].x * Chunk.chunkSize + chunkPlayer.x, 0, chunkPositions[i].z * Chunk.chunkSize + chunkPlayer.z);
				Chunk newChunk = world.GetChunk(newChunkPos.x, newChunkPos.y, newChunkPos.z);
				if (newChunk != null && (newChunk.rendered || updateList.Contains(newChunkPos))) continue;
				for (int y = -4; y < 4; y++) buildList.Add(new Vector3Int(newChunkPos.x, y * Chunk.chunkSize, newChunkPos.z));
				return;
			}
		}
	}

	private void LoadAndRenderChunks(){
		for (int i = 0; i < 2; i++){
			if (buildList.Count != 0){
				BuildChunk(buildList[0]);
				buildList.RemoveAt(0);
			}
		}

		for (int i = 0; i < updateList.Count; i++){
			Chunk chunk = world.GetChunk(updateList[0].x, updateList[0].y, updateList[0].z);
			if (chunk != null) chunk.update = true;
			updateList.RemoveAt(0);
		}
	}

	private void BuildChunk(Vector3Int chunkPos){
		for (int y = chunkPos.y - Chunk.chunkSize; y <= chunkPos.y + Chunk.chunkSize; y += Chunk.chunkSize){
			if (y > 64 || y < -64) continue;

			for (int x = chunkPos.x - Chunk.chunkSize; x <= chunkPos.x + Chunk.chunkSize; x += Chunk.chunkSize){
				for (int z = chunkPos.z - Chunk.chunkSize; z <= chunkPos.z + Chunk.chunkSize; z += Chunk.chunkSize){
					if (world.GetChunk(x, y, z) == null) world.CreateChunk(x, y, z);
				}
			}
		}
		updateList.Add(chunkPos);
	}

	private void DeleteChunks(){
		if (timer == 10) {
			List<Vector3Int> chunkToRemove = new List<Vector3Int>();
			foreach (var chunk in world.Chunks) {
				float distance = Vector3.Distance(
					new Vector3(chunk.Value.ChunkPos.x, 0, chunk.Value.ChunkPos.z),
					new Vector3(transform.position.x, 0, transform.position.z));

				if (distance > 256) chunkToRemove.Add(new Vector3Int(chunk.Key.x, chunk.Key.y, chunk.Key.z));
			}

			// Doit etre fait en dehors du foreach, sinon erreur car on enleve des elements de la list pendant qu'on la parcours
			foreach(Vector3Int chunkPos in chunkToRemove) world.DestroyChunk(chunkPos.x, chunkPos.y, chunkPos.z);
			timer = 0;
		}
		timer++;
	}

}
