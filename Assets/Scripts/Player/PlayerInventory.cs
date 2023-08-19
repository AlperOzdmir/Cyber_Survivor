using System.Collections.Generic;
using UnityEngine;
using Weapons.Controllers;

namespace Player
{
    public class PlayerInventory : MonoBehaviour
    {
        public List<WeaponController> weapons = new List<WeaponController>(12);
        public int[] weaponLevels = new int[5];
    
        public void AddWeapon(WeaponController weapon, int weaponIndex)
        {
            weapons[weaponIndex] = weapon;
            weaponLevels[weaponIndex] = 1;
        }
    
        private void RemoveWeapon(WeaponController weapon, int weaponIndex)
        {
            weapons[weaponIndex] = null;
            weaponLevels[weaponIndex] = 0;
        }
    
        public void UpgradeWeapon(WeaponController weapon, int weaponIndex)
        {
            var newWeapon = Instantiate(weapon.weaponData.nextLevelWeapon, transform.position, Quaternion.identity, transform);
            RemoveWeapon(weapon, weaponIndex);
            Destroy(weapon.gameObject);
            AddWeapon(newWeapon, weaponIndex);
            weaponLevels[weapons.IndexOf(weapon)]++;
        }
    }
}
