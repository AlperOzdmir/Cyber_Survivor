using UnityEngine;

namespace Weapons.Behaviours
{
    public class MeleeBehaviour : MonoBehaviour
    {
        [SerializeField] protected WeaponDataSO weaponData;
        
        protected Vector3 Direction;
        
        protected virtual void Start()
        {
            Destroy(gameObject, weaponData.meleeAnimationTime);
        }
        
        public void CheckDirection(Vector3 direction)
        {
            Direction = direction;
            gameObject.transform.rotation = Quaternion.LookRotation(Vector3.forward, Direction);
        }
    }
}
