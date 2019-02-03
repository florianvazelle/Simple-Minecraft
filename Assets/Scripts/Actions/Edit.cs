using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edit {

	public static Vector3Int GetBlockPos(RaycastHit hit, bool adjacent = false){
		string content = System.IO.File.ReadAllText("D:\\Unity\\Minecraft\\Simple-Minecraft\\Logs\\Edit.log");
		System.IO.File.WriteAllText("D:\\Unity\\Minecraft\\Simple-Minecraft\\Logs\\Edit.log", content + System.Environment.NewLine + 
			System.Environment.NewLine + "Hit: " + hit.point + 
			System.Environment.NewLine + "Normal: " + hit.normal);
		return GetTrue(hit.point, hit.normal);

		/*
		 * return new Vector3Int(
		 * MoveWithinBlock(hit.point.x, hit.normal.x, adjacent),
		 * MoveWithinBlock(hit.point.y, hit.normal.y, adjacent),
		 * MoveWithinBlock(hit.point.z, hit.normal.z, adjacent)
		 * );
		*/
	}

	private static int MoveWithinBlock(float pos, float norm, bool adjacent = false){
		if(pos - (int)pos == 0.5f || pos - (int)pos == -0.5f){
			if(adjacent) pos += (norm /2);
			else pos -= (norm /2);
		}
		return Mathf.RoundToInt(pos);
	}

	public static Vector3Int GetTrue(Vector3 position, Vector3 norm){
		int[] newPosition = new int[3];
		for(int i = 0 ; i < 3; i++) {
			
			if(position[i] < 0f) {
				if(norm[i] == 1.0f && (i == 0 || i == 2)){
					newPosition[i] = Mathf.RoundToInt(position[i] - 1);
				} else if(norm[i] == 0.0f && (i == 1)){
					newPosition[i] = Fix2(position[i]);
				} else {
					newPosition[i] = Fix1(position[i]);
				}
			} else {
				if(norm[i] == 0.0f){
					if(i == 1) {
						newPosition[i] = Fix2(position[i]);
					} else {
						newPosition[i] = Mathf.FloorToInt(position[i]);
					}
				} else if(norm[i] == 1.0f && (i == 0 || i == 2)){
					newPosition[i] = Mathf.RoundToInt(position[i] - 1);
				} else if(norm[i] == -1.0f && (i == 1)) {
					newPosition[i] = Mathf.RoundToInt(position[i] + 1);
				} else {
					newPosition[i] = Fix1(position[i]);
				}
			}
		}
		return new Vector3Int(newPosition[0], newPosition[1], newPosition[2]);
	}

	private static int Fix1(float pos){
		if (pos - (int)pos == 0.5f){
			return Mathf.RoundToInt((pos += 0.2f));
		}
		else if(pos - (int)pos == -0.5f){
			return Mathf.RoundToInt((pos -= 0.2f));
		}
		return Mathf.FloorToInt(pos);
	}

	private static int Fix2(float pos){
		if (pos - (int)pos > 0.01f || pos - (int)pos < -0.01f){
			return Mathf.CeilToInt(pos);
		} else {
			return Mathf.FloorToInt(pos);
		}
	}

	public static bool SetBlock(RaycastHit hit, Block block, bool adjacent = false){
		Chunk chunk = hit.collider.GetComponent<Chunk>();
		if (chunk == null) return false;
		Vector3Int pos = GetBlockPos(hit, adjacent);
		string content = System.IO.File.ReadAllText("D:\\Unity\\Minecraft\\Simple-Minecraft\\Logs\\Edit.log");
		System.IO.File.WriteAllText("D:\\Unity\\Minecraft\\Simple-Minecraft\\Logs\\Edit.log", content + 
			System.Environment.NewLine + "Int: " + pos);
		chunk.World.SetBlock(pos.x, pos.y, pos.z, block);
		return true;
	}

	public static bool AddBlock(RaycastHit hit, Block block){
		Chunk chunk = hit.collider.GetComponent<Chunk>();
		if (chunk == null) return false;
		Vector3Int pos = GetBlockPos(hit);
		pos += Vector3Int.CeilToInt(hit.normal);
		chunk.World.SetBlock(pos.x, pos.y, pos.z, block);
		return true;

	}

	/*public static Block GetBlock(RaycastHit hit, bool adjacent = false){
		Chunk chunk = hit.collider.GetComponent<Chunk>();
		if (chunk == null) return null;
		Vector3Int pos = GetBlockPos(hit, adjacent);
		Block block = chunk.World.GetBlock(pos.x, pos.y, pos.z);
		return block;
	}*/
}
