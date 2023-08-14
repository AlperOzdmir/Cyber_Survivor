using System;
using Collectibles;
using UnityEngine;

namespace Player
{
    public class PlayerLevel : MonoBehaviour
    {
        private ExperienceBar experienceBar;
        
        private PlayerStats playerStats;
        
        [HideInInspector]
        public int experience = 0;
        [HideInInspector]
        public int experienceToNextLevel = 50;
        private readonly int experienceCap = 50;
        

        private void Start()
        {
            experienceBar = FindObjectOfType<ExperienceBar>();
            playerStats = GetComponent<PlayerStats>();
        }

        private void IncreaseExp(int exp)
        {
            experience += exp;
            CheckLevelUp();
            experienceBar.UpdateBar(experience, experienceToNextLevel);
        }

        private void CheckLevelUp()
        {
            if (experience >= experienceToNextLevel)
            {
                playerStats.CurrentLevel++;
                experience -= experienceToNextLevel;
                experienceToNextLevel += (int)(experienceCap * playerStats.CurrentLevel);
                LevelUp();
                experienceBar.UpdateBar(experience, experienceToNextLevel);
            }
        }

        private void LevelUp()
        {
            Debug.Log("Level Up!");
            return;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Experience"))
            {
                var experienceDrop = other.GetComponent<ExperienceDrop>();
                IncreaseExp(experienceDrop.experienceValue);
                experienceDrop.Collect();
            }
        }
    }
}
