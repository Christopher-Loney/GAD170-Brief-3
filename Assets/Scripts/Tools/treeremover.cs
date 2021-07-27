using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeremover : MonoBehaviour
{
    public float WaterLevel;
    private TerrainData terrain;
    public ArrayList AllTrees;
    public List<TreeInstance> UnderWater;

  void Start()
    {
        WaterLevel = this.gameObject.transform.position.y;
        UnderWater = new List<TreeInstance>();

        terrain = Terrain.activeTerrain.terrainData;

        AllTrees = new ArrayList(terrain.treeInstances);

        foreach (TreeInstance tree in terrain.treeInstances)
        {

            Vector3 worldTreePos = Vector3.Scale(tree.position, terrain.size) + Terrain.activeTerrain.transform.position;
            Debug.Log(worldTreePos);

            if (worldTreePos.y < WaterLevel)
            {
                //UnderWater.Add(tree);
                AllTrees.Remove(tree);
            }
            
        }

        //Debug.Log(UnderWater.Count);

        // Remove trees
        TreeInstance[] tempArray = new TreeInstance[AllTrees.Count];
        AllTrees.CopyTo(tempArray);
        terrain.treeInstances = tempArray;

        // Refresh Terrain
        float[,] heights = terrain.GetHeights(0, 0, 0, 0);
        terrain.SetHeights(0, 0, heights);
    }
    
}
    