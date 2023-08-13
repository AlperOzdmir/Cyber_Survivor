using Player;
using UnityEngine;

namespace Weapons.Controllers
{
    public class WeaponController : MonoBehaviour
    {
        [Header("Weapon Stats")]
        [SerializeField] protected WeaponDataSO weaponData;
        
        protected PlayerCombat playerCombat;
        
        private Vector3 direction;
        private float timeToAttack;
    
        protected virtual void Start()
        {
            playerCombat = GetComponentInParent<PlayerCombat>();
            timeToAttack = (1f / weaponData.attackSpeed) * ((100 - playerCombat.CurrentCooldownReduction) / 100);
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
            timeToAttack = (1f / weaponData.attackSpeed) * ((100 - playerCombat.CurrentCooldownReduction) / 100);
        }
    }
}
