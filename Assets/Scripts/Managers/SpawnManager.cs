using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Managers
{
    public class SpawnManager : MonoBehaviour
    {
        
        [HideInInspector]
        public List<GameObject> players;
        
        public float spawnSpeed;
        
        private void Awake()
        {
            players = GameObject.FindGameObjectsWithTag("Player").ToList();
        }
    }
}
