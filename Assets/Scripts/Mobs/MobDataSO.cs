using UnityEngine;

namespace Mobs
{
    [CreateAssetMenu(fileName = "Mob Data", menuName = "Scriptable Objects/Mob Data", order = 1)]
    public class MobDataSO : ScriptableObject
    {
        public float health;
        public float armor;
        public float damage;
        public float movementSpeed;
        public GameObject experienceDropPrefab;
    }
}
