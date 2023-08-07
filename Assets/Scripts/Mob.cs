using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Mob : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float damage;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float movementSpeed;
    
    private Player player;
    private List<GameObject> players;
    private MobSpawner mobSpawner;
    
    private float shortestDistance = Mathf.Infinity;
    private float distanceToPlayer;
    private Vector3 playerPosition;
    private Vector3 targetPlayerPosition;

    private void Start()
    {
        mobSpawner = FindObjectOfType<MobSpawner>();
        players = mobSpawner.GetPlayersList();
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
        transform.position = Vector2.MoveTowards(transform.position, targetPlayerPosition, 1f * movementSpeed * Time.deltaTime);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject.GetComponent<Player>();
            Attack();
        }
    }
    
    private void Attack()
    {
        if (player.health <= damage)
        {
            players.Remove(player.gameObject);
        }
        player.TakeDamage(damage);
    }
    
}
