using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour {

	public static int chunkSize = 16;
    public Block[,,] blocks = new Block[chunkSize, chunkSize, chunkSize];
	private bool update = true;

	private MeshFilter filter;
	private MeshCollider collider;

	private World world;
	private Vector3Int chunkPos;

	public World World {
		get => world;
		set => world = value;
	}

	public Vector3Int ChunkPos {
		get => chunkPos;
		set => chunkPos = value;
	}

	void Start(){
		filter = gameObject.GetComponent<MeshFilter>();
		collider = gameObject.GetComponent<MeshCollider>();
	}

	void Update(){
		if(update){
			UpdateMesh();
			update = false;
		}
	}

	private void UpdateMesh(){
		MeshData meshData = new MeshData();
		for(int x = 0 ; x < chunkSize ; x++){
			for(int y = 0 ; y < chunkSize ; y++){
				for(int z = 0 ; z < chunkSize ; z++){
					meshData = blocks[x, y, z].InitMeshData(this, x, y, z, meshData); 
				}
			}
		}
		RenderMesh(meshData);
	}

	public int[] NeighborsCheck(int x, int y, int z){
		List<int> neighborsSolid = new List<int>();
        if(!GetBlock(x + 1, y, z).IsSolid) neighborsSolid.Add(0);
        if(!GetBlock(x - 1, y, z).IsSolid) neighborsSolid.Add(1);
		if(!GetBlock(x, y + 1, z).IsSolid) neighborsSolid.Add(2);
		if(!GetBlock(x, y - 1, z).IsSolid) neighborsSolid.Add(3);
		if(!GetBlock(x, y, z + 1).IsSolid) neighborsSolid.Add(4);
		if(!GetBlock(x, y, z - 1).IsSolid) neighborsSolid.Add(5);
		return neighborsSolid.ToArray();
	}

	public Block GetBlock(int x, int y, int z){
		if(InRange(x) && InRange(y) && InRange(z)) return blocks[x, y, z];
		return world.GetBlock(x, y, z);
	}

	private bool InRange(int x){
		return (x >= 0 && x < chunkSize);
	}

	private void RenderMesh(MeshData meshData){
		filter.mesh.Clear();
		filter.mesh.vertices = meshData.vertices.ToArray();
		filter.mesh.triangles = meshData.triangles.ToArray();
		filter.mesh.uv = meshData.uvs.ToArray();
		filter.mesh.RecalculateNormals();

		collider.sharedMesh = null;
		Mesh mesh = new Mesh();
		mesh.vertices = meshData.colVertices.ToArray();
		mesh.triangles = meshData.colTriangles.ToArray();
		mesh.RecalculateNormals();
		collider.sharedMesh = mesh;

		meshData.Clear();
	}
}
