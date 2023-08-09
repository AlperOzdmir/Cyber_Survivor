using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private float maxHealth = 100f;
    
    [Header("Stats")]
    [HideInInspector]
    public float health;
    private int weaponIndex = 0;
    private float cooldownReduction = 0f;
    private float movementSpeed = 3f;
    
    [Header("Related Objects")]
    [SerializeField] private StatusBar healthBar;
    
    private void Start()
    {
        health = maxHealth;
    }
    
    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.UpdateBar(health, maxHealth);
        if (health <= 0)
        {
            Die();
        }
    }
    
    private void Die()
    {
        Destroy(gameObject);
    }
}
