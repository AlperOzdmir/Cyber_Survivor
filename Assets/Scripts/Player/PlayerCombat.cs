using Managers;
using UnityEngine;
using Weapons.Controllers;

namespace Player
{
    public class PlayerCombat : MonoBehaviour
    {
        private PlayerStats playerData;
        private PlayerInventory playerInventory;
        
        private float maxHealth;
        private int weaponIndex;
        
        [Header("Related Objects")]
        [SerializeField] private HealthBar healthBar;
        

        private void Start()
        {
            playerData = GetComponent<PlayerStats>();
            playerInventory = GetComponent<PlayerInventory>();
            maxHealth = playerData.CurrentHealth;
            weaponIndex = 0;
            SpawnWeapon(playerData.StartingWeapon, weaponIndex);
        }

        private void SpawnWeapon(WeaponController weaponController, int index)
        {
            Instantiate(weaponController, transform.position, Quaternion.identity, transform);
            playerInventory.AddWeapon(weaponController, index);
        }

        private void FixedUpdate()
        {
            if (playerData.CurrentHealth < maxHealth)
            {
                RegenerateHealth();
            }
        }
        
        private void RegenerateHealth()
        {
            playerData.CurrentHealth += playerData.CurrentRecovery * Time.deltaTime;
            healthBar.UpdateBar(playerData.CurrentHealth, maxHealth);
        }

        public void Heal(float healing)
        {
            playerData.CurrentHealth += healing;
            if (playerData.CurrentHealth > maxHealth)
            {
                playerData.CurrentHealth = maxHealth;
            }
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
            GameManager.Instance.SetGameState(GameManager.GameState.GameOver);
            Destroy(gameObject);
        }
    }
}
