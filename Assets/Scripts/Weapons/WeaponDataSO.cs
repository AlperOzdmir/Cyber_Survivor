using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObjects/WeaponData", order = 1)]
    public class WeaponDataSO : ScriptableObject
    {
        [Header("Weapon Stats")]
        public GameObject weaponPrefab;
        public float damage;
        public float attackSpeed;
        public float armorPenetration;
        public bool isMelee;
        
        [Header("Projectile Related")]
        public GameObject projectilePrefab;
        public float projectileSpeed;
        public float projectileRange;
        public float projectileLifetime;
    }
}
