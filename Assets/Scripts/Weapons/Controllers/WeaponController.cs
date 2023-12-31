using Player;
using UnityEngine;

namespace Weapons.Controllers
{
    public class WeaponController : MonoBehaviour
    {
        [Header("Weapon Stats")]
        public WeaponDataSO weaponData;
        
        protected LayerMask mobLayerMask;
        
        protected PlayerStats player;
        
        private Vector3 direction;
        private float timeToAttack;
        private float attackSpeed;
    
        protected virtual void Start()
        {
            player = GetComponentInParent<PlayerStats>();
            mobLayerMask = LayerMask.GetMask("Mob");
            attackSpeed = (1f / weaponData.attackSpeed) * ((100 - player.CurrentCooldownReduction) / 100);
            timeToAttack = attackSpeed;
        }

        private void FixedUpdate()
        {
            timeToAttack -= Time.deltaTime;
            if (timeToAttack <= 0)
            {
                Attack();
            }
        }

        protected virtual void Attack()
        {
            timeToAttack = attackSpeed;
        }
    }
}
