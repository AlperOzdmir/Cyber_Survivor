using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> mobs;
    [SerializeField] private float spawnSpeed;

    // TODO Can be optimized later
    private List<GameObject> playersList = new List<GameObject>();

    private float timeToSpawn;
    
    private void Start()
    {
        var players = GameObject.FindGameObjectsWithTag("Player");
        timeToSpawn = 1f / spawnSpeed;
        foreach (var player in players)
        {
            playersList.Add(player);
        }
    }
    
    private void FixedUpdate()
    {
        timeToSpawn -= Time.deltaTime;
        if (timeToSpawn <= 0)
        {
            SpawnMob();
            timeToSpawn = 1f / spawnSpeed;
        }
    }

    private void SpawnMob()
    {
        Instantiate(mobs[0], transform.position, Quaternion.identity);
    }
    
    public List<GameObject> GetPlayersList()
    {
        return playersList;
    } 
}
