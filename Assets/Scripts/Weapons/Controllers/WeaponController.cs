using UnityEngine;

namespace Weapons.Controllers
{
    public class WeaponController : MonoBehaviour
    {
        [Header("Weapon Stats")]
        [SerializeField] protected float damage;
        [SerializeField] protected float attackSpeed;
        [SerializeField] protected float armorPenetration;
        [SerializeField] protected bool isMelee;
        
        [Header("Projectile Related")]
        [SerializeField] protected GameObject projectilePrefab;
    
        protected PlayerMovement PlayerMovement;
        private Vector3 direction;
        private float timeToAttack;
    
        protected virtual void Start()
        {
            timeToAttack = 1f / attackSpeed;
            PlayerMovement = GetComponentInParent<PlayerMovement>();
            if (PlayerMovement == null)
            {
                Debug.LogError("PlayerMovement not found!");
            }
        }

        private void FixedUpdate()
        {
            timeToAttack -= Time.deltaTime;
            if (timeToAttack <= 0)
            {
                Attack();
                timeToAttack = 1f / attackSpeed;
            }
        }

        protected virtual void Attack()
        {
            timeToAttack = 1f / attackSpeed;
        }
    }
}
