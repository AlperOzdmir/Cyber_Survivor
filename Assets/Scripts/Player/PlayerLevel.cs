using System;
using Collectibles;
using UnityEngine;

namespace Player
{
    public class PlayerLevel : MonoBehaviour
    {
        
        private ExperienceBar experienceBar;
        
        private int level = 1;
        [HideInInspector]
        public int experience = 0;
        [HideInInspector]
        public int experienceToNextLevel = 50;
        private int experienceCap = 50;

        private void Awake()
        {
            experienceBar = FindObjectOfType<ExperienceBar>();
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
                level++;
                experience -= experienceToNextLevel;
                experienceToNextLevel += (int)(experienceCap * level);
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
