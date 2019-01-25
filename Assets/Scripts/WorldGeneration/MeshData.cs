using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshData {
	public List<Vector3> vertices = new List<Vector3>();
	public List<int> triangles = new List<int>();
	public List<Vector2> uvs = new List<Vector2>();

	public List<Vector3> colVertices = new List<Vector3>();
	public List<int> colTriangles = new List<int>();

	private bool isCollide;

	public bool IsCollide {
		get => isCollide;
		set => isCollide = value;
	}

	public void CreateSides(int x, int y, int z, int[] sides, Vector2 texture){
		float v = 1f;
		foreach(int side in sides){
			switch(side) {
				case 0:
					AddVertex(new Vector3 (x + v, y - v, z));
					AddVertex(new Vector3 (x + v, y, z));
					AddVertex(new Vector3 (x + v, y, z + v));
					AddVertex(new Vector3 (x + v, y - v, z + v));
					break;
				case 1:
					AddVertex(new Vector3 (x, y - v, z + v));
					AddVertex(new Vector3 (x, y, z + v));
					AddVertex(new Vector3 (x, y, z));
					AddVertex(new Vector3 (x, y - v, z));
					break;
				case 2:
					AddVertex(new Vector3 (x,  y,  z + v));
					AddVertex(new Vector3 (x + v, y,  z + v));
					AddVertex(new Vector3 (x + v, y,  z ));
					AddVertex(new Vector3 (x,  y,  z ));
					break;
				case 3:
					AddVertex(new Vector3 (x,  y - v,  z ));
					AddVertex(new Vector3 (x + v, y - v,  z ));
					AddVertex(new Vector3 (x + v, y - v,  z + v));
					AddVertex(new Vector3 (x,  y - v,  z + v));
					break;
				case 4:
					AddVertex(new Vector3 (x + v, y - v, z + v));
					AddVertex(new Vector3 (x + v, y, z + v));
					AddVertex(new Vector3 (x, y, z + v));
					AddVertex(new Vector3 (x, y - v, z + v));
					break;
				case 5:
					AddVertex(new Vector3 (x, y - v, z));
					AddVertex(new Vector3 (x, y, z));
					AddVertex(new Vector3 (x + v, y, z));
					AddVertex(new Vector3 (x + v, y - v, z));
					break;
			}
			AddTriangles();
			AddUVs(texture);
		}
	}

	private void AddVertex(Vector3 vertex){
		vertices.Add(vertex);
		if(isCollide) colVertices.Add(vertex);
	}

	private void AddTriangles(){
		int verticesCount = vertices.Count;
		triangles.Add(verticesCount - 4);
		triangles.Add(verticesCount - 3);
		triangles.Add(verticesCount - 2);
		triangles.Add(verticesCount - 4);
		triangles.Add(verticesCount - 2);
		triangles.Add(verticesCount - 1);

		if(isCollide){
			int colVerticesCount = colVertices.Count;
			colTriangles.Add(colVerticesCount - 4);
			colTriangles.Add(colVerticesCount - 3);
			colTriangles.Add(colVerticesCount - 2);
			colTriangles.Add(colVerticesCount - 4);
			colTriangles.Add(colVerticesCount - 2);
			colTriangles.Add(colVerticesCount - 1);
		}
	}

	private void AddUVs(Vector2 texture){
		float tUnit = Block.tUnit;
		uvs.Add(new Vector2 (tUnit * texture.x + tUnit, tUnit * texture.y));
		uvs.Add(new Vector2 (tUnit * texture.x + tUnit, tUnit * texture.y + tUnit));
		uvs.Add(new Vector2 (tUnit * texture.x, tUnit * texture.y + tUnit));
		uvs.Add(new Vector2 (tUnit * texture.x, tUnit * texture.y));
	}
}
