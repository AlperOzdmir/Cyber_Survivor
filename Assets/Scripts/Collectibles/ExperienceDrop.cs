using System;
using Player;
using UnityEngine;

namespace Collectibles
{
    public class ExperienceDrop : MonoBehaviour
    {
        public int experienceValue;
        private PlayerLevel playerLevel;

        private void Awake()
        {
            playerLevel = FindObjectOfType<PlayerLevel>();
        }

        private void Collect()
        {
            playerLevel.IncreaseExp(experienceValue);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Collect();
                Destroy(gameObject);
            }
        }
    }
}
