using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> mobs;
    [SerializeField] private float spawnPerSecond;

    // TODO Can be optimized later
    private List<GameObject> playersList = new List<GameObject>();

    private float timeToSpawn;
    
    private void Start()
    {
        var players = GameObject.FindGameObjectsWithTag("Player");
        timeToSpawn = Time.time;
        foreach (var player in players)
        {
            playersList.Add(player);
        }
    }
    
    private void FixedUpdate()
    {
        if (timeToSpawn >= Time.time)
        {
            SpawnMob();
            timeToSpawn = Time.time + (1 / spawnPerSecond);
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
