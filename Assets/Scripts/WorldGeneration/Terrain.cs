using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Simplex;

public class Terrain {

	private float stoneBaseHeight = -24;
	private float stoneBaseNoise = 0.05f;
	private float stoneBaseNoiseHeight = 4;

	private float stoneMountainHeight = 48;
	private float stoneMountainFrequency = 0.008f;
	private float stoneMinHeight = -12;

	private float dirtBaseHeight = 1;
	private float dirtNoise = 0.04f;
	private float dirtNoiseHeight = 3;

	public void GenerateChunk(Chunk chunk){
		int size = Chunk.chunkSize;
		for(int x = chunk.ChunkPos.x ; x < size + chunk.ChunkPos.x ; x++){
			for(int z = chunk.ChunkPos.z ; z < size + chunk.ChunkPos.z ; z++){
				AddNoiseEffect(chunk, x, z);
			}
		}
	}

	private void AddNoiseEffect(Chunk chunk, int x, int z){
		int size = Chunk.chunkSize;

		int stoneHeight = Mathf.FloorToInt(stoneBaseHeight);
		stoneHeight += Mathf.FloorToInt(Noise.CalcPixel3D(x, 0, z, stoneMountainFrequency, Mathf.FloorToInt(stoneMountainHeight)));

		if (stoneHeight < stoneMinHeight)
			stoneHeight = Mathf.FloorToInt(stoneMinHeight);

		stoneHeight += Mathf.FloorToInt(Noise.CalcPixel3D(x, 0, z, stoneBaseNoise, Mathf.FloorToInt(stoneBaseNoiseHeight)));

		int dirtHeight = stoneHeight + Mathf.FloorToInt(dirtBaseHeight);
		dirtHeight += Mathf.FloorToInt(Noise.CalcPixel3D(x, 100, z, dirtNoise, Mathf.FloorToInt(dirtNoiseHeight)));

		for(int y = chunk.ChunkPos.y ; y < size + chunk.ChunkPos.y ; y++){
			if (y <= stoneHeight) chunk.SetBlock(x - chunk.ChunkPos.x, y - chunk.ChunkPos.y, z - chunk.ChunkPos.z, new Block());
			else if (y <= dirtHeight) chunk.SetBlock(x - chunk.ChunkPos.x, y - chunk.ChunkPos.y, z - chunk.ChunkPos.z, new Dirt());
			else chunk.SetBlock(x - chunk.ChunkPos.x, y - chunk.ChunkPos.y, z - chunk.ChunkPos.z, new Air());
		}
	}
}
