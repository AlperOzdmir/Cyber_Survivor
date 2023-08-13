using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private PlayerDataSO characterData;

        [HideInInspector]
        public float currentHealth;
        [HideInInspector]
        public float currentRecovery;
        [HideInInspector]
        public float currentArmor;
        [HideInInspector]
        public float currentMovementSpeed;
        [HideInInspector]
        public float currentStrength;
        [HideInInspector]
        public float currentCooldownReduction;
        [HideInInspector] 
        public int currentLevel;
        
        public GameObject StartingWeapon {get; private set;}

        private void Awake()
        {
            CurrentHealth = characterData.health;
            CurrentRecovery = characterData.recovery;
            CurrentArmor = characterData.armor;
            CurrentMovementSpeed = characterData.movementSpeed;
            CurrentStrength = characterData.strength;
            CurrentCooldownReduction = characterData.cooldownReduction;
            StartingWeapon = characterData.startingWeapon;
            CurrentLevel = 1;
        }

        public float CurrentHealth
        {
            get => currentHealth;
            set
            {
                currentHealth = value;
            }
        }
        
        public float CurrentRecovery
        {
            get => currentRecovery;
            set
            {
                currentRecovery = value;
            }
        }
        
        public float CurrentArmor
        {
            get => currentArmor;
            set
            {
                currentArmor = value;
            }
        }
        
        public float CurrentMovementSpeed
        {
            get => currentMovementSpeed;
            set
            {
                currentMovementSpeed = value;
            }
        }
        
        public float CurrentStrength
        {
            get => currentStrength;
            set
            {
                currentStrength = value;
            }
        }
        
        public float CurrentCooldownReduction
        {
            get => currentCooldownReduction;
            set
            {
                currentCooldownReduction = value;
            }
        }
        
        public int CurrentLevel
        {
            get => currentLevel;
            set
            {
                currentLevel = value;
            }
        }
    }
}
