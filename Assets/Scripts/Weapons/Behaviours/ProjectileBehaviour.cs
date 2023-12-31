using Mobs;
using UnityEngine;

namespace Weapons.Behaviours
{
    public class ProjectileBehaviour : MonoBehaviour
    {
        [SerializeField] protected WeaponDataSO weaponData;
        
        protected Vector3 Direction;
        
        protected virtual void Start()
        {
            Destroy(gameObject, weaponData.projectileLifetime);
        }
        
        public void CheckDirection(Vector3 direction)
        {
            Direction = direction;
            gameObject.transform.rotation = Quaternion.LookRotation(Vector3.forward, Direction);
        }

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Mob"))
            {
                other.gameObject.GetComponent<Mob>().TakeDamage(weaponData.damage);
            }
            // Online part
            /* else if (other.CompareTag("Player"))
            {
                other.gameObject.GetComponent<Player.PlayerCombat>().TakeDamage(weaponData.damage);
            }
            */
        }
    }
}
