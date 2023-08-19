using UnityEngine;
using Weapons.Controllers;

namespace Weapons
{
    [CreateAssetMenu(fileName = "Weapon Data", menuName = "Scriptable Objects/Weapon Data", order = 1)]
    public class WeaponDataSO : ScriptableObject
    {
        [Header("Weapon Stats")]
        public GameObject weaponPrefab;
        public float damage;
        public float attackSpeed;
        public float armorPenetration;
        public bool isMelee;
        public WeaponController nextLevelWeapon;
        
        [Header("Projectile Related")]
        public GameObject projectilePrefab;
        public float projectileSpeed;
        public float projectileRange;
        public float projectileLifetime;

        [Header("Melee Related")]
        public float meleeRange;
        public float meleeAnimationTime;
    }
}
