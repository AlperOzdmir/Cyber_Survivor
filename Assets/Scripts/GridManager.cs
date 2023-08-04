using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int width, height;
    [SerializeField] private List<GameObject> tileArray;
    [SerializeField] private Transform cameraTransform;
    
    private void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        for (var i = 0; i < width; i++)
        {
            for (var j = 0; j < height; j++)
            {
                var randomTile = PickRandomTile();
                var tile = Instantiate(randomTile, new Vector3(i, j), quaternion.identity);
                tile.name = $"Tile {i} {j}";
            }
        }
        cameraTransform.position = new Vector3(width / 2f, height / 2f, -10);
    }
    
    private GameObject PickRandomTile()
    {
        var randomTile = tileArray[UnityEngine.Random.Range(0, tileArray.Count)];
        return randomTile;
    }

    public Vector3 GetCenterPosition()
    {
        return new Vector3(width / 2f, height / 2f, 0);
    }
    
}
