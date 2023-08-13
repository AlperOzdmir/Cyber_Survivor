using Collectibles;
using UnityEngine;

namespace Player
{
    public class PlayerLevel : MonoBehaviour
    {
        private int level = 1;
        private int experience = 0;
        private int experienceToNextLevel = 50;
        private int experienceCap = 50;

        public void IncreaseExp(int exp)
        {
            experience += exp;
            CheckLevelUp();
        }

        private void CheckLevelUp()
        {
            if (experience >= experienceToNextLevel)
            {
                level++;
                experience -= experienceToNextLevel;
                experienceToNextLevel = (int)(experienceCap * level);
                LevelUp();
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
