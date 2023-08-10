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
                Direction = Vector3.right;
            }
            else
            {
                Direction = direction;   
            }
            
            var directionX = Direction.x;
            var directionY = Direction.y;
        }

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Mob"))
            {
                other.gameObject.GetComponent<Mob>().TakeDamage(weaponData.damage);
            }
        }
    }
}
