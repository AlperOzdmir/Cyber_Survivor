using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerCombat : MonoBehaviour
    {
        [SerializeField] private PlayerDataSO playerData;
        
        private List<GameObject> currentWeapons = new List<GameObject>();
        
        public float CurrentHealth { get; private set;}
        public float CurrentArmor { get; private set;}
        private float currentMovementSpeed;
        private float currentCooldownReduction;
    
        [Header("Related Objects")]
        [SerializeField] private HealthBar healthBar;

        private void Awake()
        {
            Instantiate(playerData.startingWeapon, transform.position, Quaternion.identity, transform);
            currentWeapons.Add(playerData.startingWeapon);
        }

        private void Start()
        {
            CurrentHealth = playerData.health;
        }
    
        public void TakeDamage(float damage)
        {
            if (damage > CurrentArmor)
            {
                CurrentArmor = 0;
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
    
        private void Die()
        {
            Destroy(gameObject);
        }
    }
}
