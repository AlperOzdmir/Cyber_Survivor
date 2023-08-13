using System.Collections.Generic;
using Managers;
using UnityEngine;

namespace Mobs
{
    public class MobSpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> mobs;

        private SpawnManager spawnManager;
        
        private float timeToSpawn;
        
        private void Awake()
        {
            spawnManager = FindObjectOfType<SpawnManager>();
        }
    
        private void Start()
        {
            SpawnMob();
            timeToSpawn = 1f / spawnManager.spawnSpeed;
        }
    
        private void FixedUpdate()
        {
            timeToSpawn -= Time.deltaTime;
            if (timeToSpawn <= 0)
            {
                SpawnMob();
                timeToSpawn = 1f / spawnManager.spawnSpeed;
            }
        }

        private void SpawnMob()
        {
            Instantiate(mobs[0], transform.position, Quaternion.identity, transform);
        }
    }
}
