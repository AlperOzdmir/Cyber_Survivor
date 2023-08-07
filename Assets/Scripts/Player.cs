using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float health = 100f;
    private float damage = 1f;
    private float attackSpeed = 1f;
    private float cooldownReduction = 0f;
    private float movementSpeed = 3f;

    [Header("Movement")]
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private Rigidbody2D rBody;
    [SerializeField] private CapsuleCollider2D collider;

    [Header("Related Objects")]
    [SerializeField] private List<Transform> spawnPoints;
    
    private void Start()
    {
        // TODO Assign players to spawn points - online feature 
        transform.position = spawnPoints[0].position;
    }

    private void FixedUpdate()
    {
        rBody.velocity = new Vector2(joystick.Horizontal * movementSpeed, joystick.Vertical * movementSpeed);
    }
    
    // Will be used for area happenings (earthquake etc.)
    private Vector2 GetPlayersTilePosition()
    {
        var playersPosition = transform.position;
        var playersTilePosition = new Vector2(Mathf.RoundToInt(playersPosition.x), Mathf.RoundToInt(playersPosition.y));
        Debug.Log(playersTilePosition);
        return playersTilePosition;
    }
    
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    
    private void Die()
    {
        collider.enabled = false;
        Destroy(gameObject);
    }
    
    public float GetHealth()
    {
        return health;
    }
}
