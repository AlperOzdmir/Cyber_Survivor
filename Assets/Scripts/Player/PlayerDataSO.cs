using UnityEngine;
using Weapons.Controllers;

namespace Player
{
    [CreateAssetMenu(fileName = "Player Data", menuName = "Scriptable Objects/Player Data", order = 1)]
    public class PlayerDataSO : ScriptableObject
    {
        public float health;
        public float recovery;
        public float armor;
        public float movementSpeed;
        public float cooldownReduction;
        public float strength;
        public float magnet;
        public GameObject startingWeapon;
    }
}
