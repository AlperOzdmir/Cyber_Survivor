using UnityEngine;

namespace Weapons
{
    public class ProjectileBehaviour : MonoBehaviour
    {
        [SerializeField] protected float projectileSpeed;
        [SerializeField] protected float projectileLifetime;
        
        private Transform objectTransform;
        protected Vector3 Direction = Vector3.zero;
        
        protected virtual void Start()
        {
            Destroy(gameObject, projectileLifetime);
            objectTransform = GetComponent<Transform>();
        }
        
        public void CheckDirection(Vector3 direction)
        {
            Direction = direction;
            
        }
    }
}
