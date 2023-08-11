using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Mobs
{
    public class Mob : MonoBehaviour
    {
        [Header("Mob Stats")]
        [SerializeField] private MobDataSO mobData;
    
        private PlayerCombat player;
        private List<GameObject> players;
        private MobSpawner mobSpawner;
    
        private float currentHealth;
        private float currentArmor;
        
        private float shortestDistance = Mathf.Infinity;
        private float distanceToPlayer;
        private Vector3 playerPosition;
        private Vector3 targetPlayerPosition;

        private void Start()
        {
            mobSpawner = FindObjectOfType<MobSpawner>();
            players = mobSpawner.GetPlayersList();
            currentHealth = mobData.health;
            currentArmor = mobData.armor;
        }

        private void FixedUpdate()
        {
            if (players.Count == 0)
            {
                return;
            }
            foreach (var tempPlayer in players)
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
            if (player.health <= mobData.damage)
            {
                players.Remove(player.gameObject);
            }
            player.TakeDamage(mobData.damage);
        }
        
        public void TakeDamage(float damage)
        {
            if (currentArmor > 0)
            {
                currentArmor -= damage;
            }
            else
            {
                currentHealth -= damage;
                if (currentHealth <= 0)
                {
                    Die();
                }
            }
        }

        private void Die()
        {
            Destroy(gameObject);
            // Might add some explosion effect here
        }
    }
}
