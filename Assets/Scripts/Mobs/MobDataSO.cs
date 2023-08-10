using UnityEngine;

namespace Mobs
{
    [CreateAssetMenu(fileName = "Mob Data", menuName = "ScriptableObjects/MobData", order = 1)]
    public class MobDataSO : ScriptableObject
    {
        public float health;
        public float armor;
        public float damage;
        public float movementSpeed;
    }
}
