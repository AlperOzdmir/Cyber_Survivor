using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Managers
{
    public class GridManager : MonoBehaviour
    {
        [SerializeField] private int width, height;
        [SerializeField] private List<GameObject> tileArray;
        [SerializeField] private GameObject limitTile;
        [SerializeField] private GameObject mobSpawnerTile;
        [SerializeField] private Transform cameraTransform;
    
        private void Start()
        {
            GenerateGrid();
        }

    
        // If grid size (height, width) values are changed, camera limit collider should be updated manually.
        private void GenerateGrid()
        {
            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                {
                    if (i == width - 2 || j == height - 2 || i == 1 || j == 1)
                    {
                        // Tile with collider in order to set map limits
                        var tile = Instantiate(limitTile, new Vector3(i, j), quaternion.identity);
                        tile.name = $"Tile {i} {j}";
                    }
                    else if (i == width - 3 || j == height - 3 || i == 2 || j == 2)
                    {
                        // Mob spawner tiles
                        var tile = Instantiate(mobSpawnerTile, new Vector3(i, j), quaternion.identity);
                        tile.name = $"Tile {i} {j}";
                    }
                    else if (i == width / 2)
                    {
                        // Mob spawner tiles
                        var tile = Instantiate(mobSpawnerTile, new Vector3(i, j), quaternion.identity);
                        tile.name = $"Tile {i} {j}";
                    }
                    else
                    {
                        var randomTile = PickRandomTile();
                        var tile = Instantiate(randomTile, new Vector3(i, j), quaternion.identity);
                        tile.name = $"Tile {i} {j}";
                    }
                }
            }
            // After creating grid, set camera position to center of the grid
            cameraTransform.position = new Vector3(width / 2f, height / 2f, -10);
        }
    
        private GameObject PickRandomTile()
        {
            var randomTile = tileArray[UnityEngine.Random.Range(0, tileArray.Count)];
            return randomTile;
        }
    
    }
}
