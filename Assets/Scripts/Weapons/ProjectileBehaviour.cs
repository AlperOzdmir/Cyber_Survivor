using System;
using Mobs;
using UnityEngine;

namespace Weapons
{
    public class ProjectileBehaviour : MonoBehaviour
    {
        [SerializeField] protected WeaponDataSO weaponData;
        
        protected Vector3 Direction = Vector3.zero;
        
        protected virtual void Start()
        {
            Destroy(gameObject, weaponData.projectileLifetime);
        }
        
        public void CheckDirection(Vector3 direction)
        {
            if (direction == Vector3.zero)
            {
                Direction = Vector3.up;
            }
            else
            {
                Direction = direction;   
            }
            gameObject.transform.rotation = Quaternion.LookRotation(Vector3.forward, Direction);
        }

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Mob"))
            {
                other.gameObject.GetComponent<Mob>().TakeDamage(weaponData.damage);
            }
            /* else if (other.CompareTag("Player"))
            {
                other.gameObject.GetComponent<Player.PlayerCombat>().TakeDamage(weaponData.damage);
            }
            */
        }
    }
}
