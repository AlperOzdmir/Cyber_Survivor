using Mobs;
using UnityEngine;
using Weapons.Behaviours;

namespace Weapons
{
    public class LaserRPGBehaviour : ProjectileBehaviour
    {
        [SerializeField] private LayerMask mobLayerMask;
        
        protected override void Start()
        {
            base.Start();
        }
        
        private void FixedUpdate()
        {
            transform.position += Direction * (weaponData.projectileSpeed * Time.deltaTime);
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
            if (other.CompareTag("Mob"))
            {
                var hitMobs = Physics2D.OverlapCircleAll(transform.position, weaponData.areaRadius, mobLayerMask);
                if (hitMobs != null)
                {
                    foreach (var mob in hitMobs)
                    {
                        mob.gameObject.GetComponent<Mob>().TakeDamage(weaponData.areaDamage);
                    }
                }
                Destroy(gameObject);
            }
            // Might add some animations, explosions, etc.
        }
    }
}
