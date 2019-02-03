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

	private float caveFrequency = 0.025f;
	private int caveSize = 7;

	private float treeFrequency = 0.2f;
	private int treeDensity = 3;

	public void GenerateChunk(Chunk chunk){
		int size = Chunk.chunkSize;
		for(int x = chunk.ChunkPos.x - 3 ; x < size + chunk.ChunkPos.x + 3 ; x++){
			for(int z = chunk.ChunkPos.z - 3 ; z < size + chunk.ChunkPos.z + 3 ; z++){
				AddNoiseEffect(chunk, x, z);
			}
		}
	}

	private void AddNoiseEffect(Chunk chunk, int x, int z){
		int size = Chunk.chunkSize;

		int stoneHeight = Mathf.FloorToInt(stoneBaseHeight);
		stoneHeight += Mathf.FloorToInt(Noise.CalcPixel3D(x, 0, z, stoneMountainFrequency, Mathf.FloorToInt(stoneMountainHeight)));

		if (stoneHeight < stoneMinHeight) stoneHeight = Mathf.FloorToInt(stoneMinHeight);

		stoneHeight += Mathf.FloorToInt(Noise.CalcPixel3D(x, 0, z, stoneBaseNoise, Mathf.FloorToInt(stoneBaseNoiseHeight)));

		int dirtHeight = stoneHeight + Mathf.FloorToInt(dirtBaseHeight);
		dirtHeight += Mathf.FloorToInt(Noise.CalcPixel3D(x, 100, z, dirtNoise, Mathf.FloorToInt(dirtNoiseHeight)));

		for(int y = chunk.ChunkPos.y - 8 ; y < size + chunk.ChunkPos.y + size ; y++){
			int caveChance = Mathf.FloorToInt(Noise.CalcPixel3D(x, y, z, caveFrequency, 100));

			if (y <= stoneHeight && caveSize < caveChance) SetBlock(x, y, z, new Block(), chunk);
			else if (y <= dirtHeight && caveSize < caveChance){
				SetBlock(x, y, z, new Dirt(), chunk);
				//if (y == dirtHeight && Noise.CalcPixel3D(x, 0, z, treeFrequency, 100) < treeDensity) CreateTree(x, y + 1, z, chunk);
			}
			else SetBlock(x, y, z, new Air(), chunk);
		}
	}

	public static void SetBlock(int x, int y, int z, Block block, Chunk chunk, bool replaceBlocks = false){
		x -= chunk.ChunkPos.x;
		y -= chunk.ChunkPos.y;
		z -= chunk.ChunkPos.z;
		//if (Chunk.InRange(x) && Chunk.InRange(y) && Chunk.InRange(z)){
			//if (replaceBlocks || chunk.blocks[x, y, z] == null) 
			chunk.SetBlock(x, y, z, block);
		//}
	}

	private void CreateTree(int x, int y, int z, Chunk chunk){
		//Leaves
		for (int xi = -2; xi <= 2; xi++){
			for (int yi = 4; yi <= 8; yi++){
				for (int zi = -2; zi <= 2; zi++){
					SetBlock(x + xi, y + yi, z + zi, new Leaf(), chunk, true);
				}
			}
		}
		//Trunk
		for (int yt = 0; yt < 6; yt++) SetBlock(x, y + yt, z, new Wood(), chunk, true);
	}
}
