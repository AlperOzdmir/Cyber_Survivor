using System;
using Managers;
using Player;
using UnityEngine;

namespace Mobs
{
    public class Mob : MonoBehaviour
    {
        [Header("Mob Stats")]
        [SerializeField] private MobDataSO mobData;
        
        private SpawnManager spawnManager;
    
        private PlayerCombat player;
    
        private float currentHealth;
        private float currentArmor;
        
        private float shortestDistance = Mathf.Infinity;
        private float distanceToPlayer;
        private Vector3 playerPosition;
        private Vector3 targetPlayerPosition;

        private void Awake()
        {
            spawnManager = FindObjectOfType<SpawnManager>();
        }

        private void Start()
        {
            currentHealth = mobData.health;
            currentArmor = mobData.armor;
        }

        private void FixedUpdate()
        {
            if (spawnManager.players.Count == 0)
            {
                return;
            }
            foreach (var tempPlayer in spawnManager.players)
            {
                playerPosition = tempPlayer.transform.position;
                distanceToPlayer = (transform.position - playerPosition).magnitude;
                if (distanceToPlayer < shortestDistance)
                {
                    shortestDistance = distanceToPlayer;
                    targetPlayerPosition = playerPosition;
                }
            }
            transform.position = Vector2.MoveTowards(transform.position, targetPlayerPosition, 1f * mobData.movementSpeed * Time.deltaTime);
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                player = other.gameObject.GetComponent<PlayerCombat>();
                Attack();
            }
        }
    
        private void Attack()
        {
            if (player.CurrentHealth + player.CurrentArmor <= mobData.damage)
            {
                spawnManager.players.Remove(player.gameObject);
            }
            player.TakeDamage(mobData.damage);
        }
        
        public void TakeDamage(float damage)
        {
            if (damage > currentArmor)
            {
                currentArmor = 0;
                damage -= currentArmor;
                currentHealth -= damage;
                if (currentHealth <= 0)
                {
                    Die();
                }
            }
            else
            {
                currentArmor -= damage;
            }
        }

        private void Die()
        {
            Destroy(gameObject);
            Instantiate(mobData.experienceDropPrefab, transform.position, Quaternion.identity);
            // Might add some explosion effect here
        }
    }
}
