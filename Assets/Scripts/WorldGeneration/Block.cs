using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block {
	protected Vector2 texture;
	public static float tUnit = 0.25f;

	protected bool isSolid;
	protected bool isChanged;

	public bool IsSolid {
		get => isSolid;
	}

	public bool IsChanged {
		get => isChanged;
		set => isChanged = value;
	}

	public Block(){
		isSolid = true;
		isChanged = true;

		texture = new Vector2(0, 0);
	}

	public virtual MeshData InitMeshData(Chunk chunk, int x, int y, int z, MeshData meshData){
		int[] sidesToInitialize = chunk.NeighborsCheck(x, y, z);
		meshData.CreateSides(x, y, z, sidesToInitialize, texture);
		return meshData;
	}
}
