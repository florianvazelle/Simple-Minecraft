using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : Block {
   public Air() {
      isSolid   = false;
      isChanged = true;
   }

   public override MeshData InitMeshData(Chunk chunk, int x, int y, int z, MeshData meshData) {
      return(meshData);
   }
}
