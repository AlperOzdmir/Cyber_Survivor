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
        public int weaponLevel;
        public GameObject nextLevelWeapon;
        
        [Header("Projectile Related")]
        public float projectileSpeed;
        public float projectileRange;
        public float projectileLifetime;
        
        [Header("Special Effects")]
        public float knockbackPower;
        public int numberOfProjectiles;
        public int numberOfBounces;
        public float areaRadius;
        public float areaDamage;

        [Header("Melee Related")]
        public float meleeRange;
        public float meleeAnimationTime;
        
        [Header("Weapon Info")]
        public string weaponName;
        public string weaponDescription;
        public Sprite weaponSprite;
    }
}
