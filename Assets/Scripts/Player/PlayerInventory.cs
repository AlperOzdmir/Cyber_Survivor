using System.Collections.Generic;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Weapons;
using Weapons.Controllers;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

namespace Player
{
    public class PlayerInventory : MonoBehaviour
    {
        public List<WeaponController> weapons = new List<WeaponController>(8);
        public int[] weaponLevels = new int[8];
        
        private PlayerCombat player;

        private void Start()
        {
            player = GetComponent<PlayerCombat>();
        }

        [System.Serializable]
        public class WeaponUpgrade
        {
            public WeaponDataSO weaponData;
            public WeaponController weaponObject;
        }
        
        [System.Serializable]
        public class UpgradeUI
        {
            public TextMeshProUGUI upgradeName;
            public TextMeshProUGUI upgradeDescription;
            public Image upgradeImage;
            public Button upgradeButton;
        }
        
        public List<WeaponUpgrade> weaponUpgrades = new List<WeaponUpgrade>(8);
        public List<UpgradeUI> upgradeUIs = new List<UpgradeUI>(8);
    
        public void AddWeapon(WeaponController weapon, int weaponIndex)
        {
            weapons[weaponIndex] = weapon;
            weaponLevels[weaponIndex] = weapon.weaponData.weaponLevel;
            if (GameManager.Instance != null &&
                GameManager.Instance.GetGameState() == GameManager.GameState.LevelUpMenu)
            {
                GameManager.Instance.CloseLevelUpMenu();
            }
        }
    
        private void RemoveWeapon(WeaponController weapon)
        {
            int weaponIndex = weapons.IndexOf(weapon);
            weapons[weaponIndex] = null;
            weaponLevels[weaponIndex] = 0;
        }
    
        public void UpgradeWeapon(int weaponIndex)
        {
            var weapon = weapons[weaponIndex];
            var upgradedWeapon = Instantiate(weapon.weaponData.nextLevelWeapon, transform.position, Quaternion.identity, transform);
            AddWeapon(upgradedWeapon.GetComponent<WeaponController>(), weaponIndex);
            Destroy(weapon.gameObject);
            weaponLevels[weaponIndex] = upgradedWeapon.GetComponent<WeaponController>().weaponData.weaponLevel;
            
            if (GameManager.Instance != null &&
                GameManager.Instance.GetGameState() == GameManager.GameState.LevelUpMenu)
            {
                GameManager.Instance.CloseLevelUpMenu();
            }
        }

        private void ApplyUpgradeOptions()
        {
            foreach (var upgradeOption in upgradeUIs)
            {
                WeaponUpgrade weaponUpgrade = weaponUpgrades[Random.Range(0, weaponUpgrades.Count)];
                if (weaponUpgrade != null)
                {
                    bool newWeapon = false;
                    for (int i = 0; i < weapons.Count; i++)
                    {
                        if (weapons[i] != null && weapons[i].weaponData == weaponUpgrade.weaponData)
                        {
                            newWeapon = false;
                            upgradeOption.upgradeButton.onClick.AddListener(() => UpgradeWeapon(i));
                            upgradeOption.upgradeDescription.text = "Upgrade your " + weaponUpgrade.weaponData
                                .nextLevelWeapon.GetComponent<WeaponController>().weaponData.weaponDescription;
                            upgradeOption.upgradeName.text = weaponUpgrade.weaponData.nextLevelWeapon.GetComponent<WeaponController>().weaponData.weaponName;
                            break;
                        }
                        newWeapon = true;
                    }

                    if (newWeapon)
                    {
                        upgradeOption.upgradeButton.onClick.AddListener(() => player.SpawnWeapon(weaponUpgrade.weaponObject.gameObject));
                        upgradeOption.upgradeDescription.text = weaponUpgrade.weaponData.weaponDescription;
                        upgradeOption.upgradeName.text = weaponUpgrade.weaponData.weaponName;
                    }
                    upgradeOption.upgradeImage.sprite = weaponUpgrade.weaponData.weaponSprite;
                }
            }
        }

        private void RemoveUpgradeOptions()
        {
            foreach (var upgradeOption in upgradeUIs)
            {
                upgradeOption.upgradeButton.onClick.RemoveAllListeners();
            }
        }
        
        public void RemoveApplyUpgradeOptions()
        {
            RemoveUpgradeOptions();
            ApplyUpgradeOptions();
        }
    }
}
