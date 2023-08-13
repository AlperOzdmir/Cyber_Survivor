using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerCombat : MonoBehaviour
    {
        [SerializeField] private PlayerDataSO playerData;
        
        private List<GameObject> currentWeapons = new List<GameObject>();
        
        public float CurrentHealth { get; private set; }
        
        public float CurrentRecovery { get; private set; }
        public float CurrentArmor { get; private set; }
        public float CurrentMovementSpeed { get; private set; }
        
        public float CurrentStrength { get; private set; }
        public float CurrentCooldownReduction { get; private set; }
    
        [Header("Related Objects")]
        [SerializeField] private HealthBar healthBar;

        private void Awake()
        {
            Instantiate(playerData.startingWeapon, transform.position, Quaternion.identity, transform);
            currentWeapons.Add(playerData.startingWeapon);
        }

        private void Start()
        {
            CurrentHealth = playerData.health - 10;
            CurrentRecovery = playerData.recovery;
            CurrentArmor = playerData.armor;
            CurrentMovementSpeed = playerData.movementSpeed;
            CurrentStrength = playerData.strength;
            CurrentCooldownReduction = playerData.cooldownReduction;
        }

        private void FixedUpdate()
        {
            CurrentHealth += CurrentRecovery * Time.deltaTime;
            healthBar.UpdateBar(CurrentHealth, playerData.health);
        }

        public void TakeDamage(float damage)
        {
            if (damage > CurrentArmor)
            {
                ArmorBreak();
                damage -= CurrentArmor;
                CurrentHealth -= damage;
                healthBar.UpdateBar(CurrentHealth, playerData.health);
                if (CurrentHealth <= 0)
                {
                    Die();
                }
            }
            else
            {
                CurrentArmor -= damage;
            }
        }

        private void ArmorBreak()
        {
            CurrentArmor = 0;
            // Add some animation here
        }
    
        private void Die()
        {
            Destroy(gameObject);
        }
    }
}
