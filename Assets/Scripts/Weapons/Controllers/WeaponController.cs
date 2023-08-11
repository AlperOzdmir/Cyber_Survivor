using Player;
using UnityEngine;

namespace Weapons.Controllers
{
    public class WeaponController : MonoBehaviour
    {
        [Header("Weapon Stats")]
        [SerializeField] protected WeaponDataSO weaponData;
        
        private Vector3 direction;
        private float timeToAttack;
    
        protected virtual void Start()
        {
            timeToAttack = 1f / weaponData.attackSpeed;
        }

        private void FixedUpdate()
        {
            timeToAttack -= Time.deltaTime;
            if (timeToAttack <= 0)
            {
                Attack();
                timeToAttack = 1f / weaponData.attackSpeed;
            }
        }

        protected virtual void Attack()
        {
            timeToAttack = 1f / weaponData.attackSpeed;
        }
    }
}
