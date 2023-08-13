using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerCombat : MonoBehaviour
    {
        private PlayerStats playerData;
        
        private float maxHealth;
        
        private List<GameObject> currentWeapons = new List<GameObject>();
        
        [Header("Related Objects")]
        [SerializeField] private HealthBar healthBar;

        private void Awake()
        {
            playerData = GetComponent<PlayerStats>();
            Instantiate(playerData.StartingWeapon, transform.position, Quaternion.identity, transform);
            currentWeapons.Add(playerData.StartingWeapon);
        }

        private void Start()
        {
            maxHealth = playerData.CurrentHealth;
        }

        private void FixedUpdate()
        {
            playerData.CurrentHealth += playerData.CurrentRecovery * Time.deltaTime;
            healthBar.UpdateBar(playerData.CurrentHealth, maxHealth);
        }

        public void TakeDamage(float damage)
        {
            if (damage > playerData.CurrentArmor)
            {
                ArmorBreak();
                damage -= playerData.CurrentArmor;
                playerData.CurrentHealth -= damage;
                healthBar.UpdateBar(playerData.CurrentHealth, maxHealth);
                if (playerData.CurrentHealth <= 0)
                {
                    Die();
                }
            }
            else
            {
                playerData.CurrentArmor -= damage;
            }
        }

        private void ArmorBreak()
        {
            playerData.CurrentArmor = 0;
            // Add some animation here
        }
    
        private void Die()
        {
            Destroy(gameObject);
        }
    }
}
