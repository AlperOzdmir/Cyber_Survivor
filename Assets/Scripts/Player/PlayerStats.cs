using System;
using Managers;
using UnityEngine;
using UnityEngine.Serialization;
using Weapons.Controllers;

namespace Player
{
    public class PlayerStats : MonoBehaviour
    {
        private float currentHealth;
        private float currentRecovery;
        private float currentArmor;
        private float currentMovementSpeed;
        private float currentStrength;
        private float currentCooldownReduction;
        private int currentLevel;
        private float currentMagnet;
        private GameObject startingWeapon;

        private void Awake()
        {
            var characterData = CharacterManager.GetCharacterData();
            CharacterManager.Instance.DestroySingleton();
            CurrentHealth = characterData.health;
            CurrentRecovery = characterData.recovery;
            CurrentArmor = characterData.armor;
            CurrentMovementSpeed = characterData.movementSpeed;
            CurrentStrength = characterData.strength;
            CurrentCooldownReduction = characterData.cooldownReduction;
            currentMagnet = characterData.magnet;
            startingWeapon = characterData.startingWeapon;
            CurrentLevel = 1;
        }

        private void Start()
        {
            GameManager.Instance.UpdateHealthText(currentHealth);
            GameManager.Instance.UpdateRecoveryText(currentRecovery);
            GameManager.Instance.UpdateArmorText(currentArmor);
            GameManager.Instance.UpdateMovementSpeedText(currentMovementSpeed);
            GameManager.Instance.UpdateCooldownReductionText(currentCooldownReduction);
            GameManager.Instance.UpdateStrengthText(currentStrength);
        }

        public float CurrentHealth
        {
            get => currentHealth;
            set
            {
                currentHealth = value;
                if (GameManager.Instance != null)
                {
                    GameManager.Instance.UpdateHealthText(currentHealth);
                }
            }
        }
        
        public float CurrentRecovery
        {
            get => currentRecovery;
            set
            {
                currentRecovery = value;
                if (GameManager.Instance != null)
                {
                    GameManager.Instance.UpdateRecoveryText(currentRecovery);
                }
            }
        }
        
        public float CurrentArmor
        {
            get => currentArmor;
            set
            {
                currentArmor = value;
                if (GameManager.Instance != null)
                {
                    GameManager.Instance.UpdateArmorText(currentArmor);
                }
            }
        }
        
        public float CurrentMovementSpeed
        {
            get => currentMovementSpeed;
            set
            {
                currentMovementSpeed = value;
                if (GameManager.Instance != null)
                {
                    GameManager.Instance.UpdateMovementSpeedText(currentMovementSpeed);
                }
            }
        }
        
        public float CurrentCooldownReduction
        {
            get => currentCooldownReduction;
            set
            {
                currentCooldownReduction = value;
                if (GameManager.Instance != null)
                {
                    GameManager.Instance.UpdateCooldownReductionText(currentCooldownReduction);
                }
            }
        }
        
        public float CurrentStrength
        {
            get => currentStrength;
            set
            {
                currentStrength = value;
                if (GameManager.Instance != null)
                {
                    GameManager.Instance.UpdateStrengthText(currentStrength);
                }
            }
        }
        
        public float CurrentMagnet
        {
            get => currentMagnet;
            set
            {
                currentMagnet = value;
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
        
        public GameObject StartingWeapon
        {
            get => startingWeapon;
            set
            {
                startingWeapon = value;
            }
        }
    }
}
