using UnityEngine;
using Weapons.Controllers;

namespace Weapons
{
    public class LaserRevolverBehaviour : ProjectileBehaviour
    {
        protected override void Start()
        {
            base.Start();
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            transform.position += Direction * (weaponData.projectileSpeed * Time.deltaTime);
        }
        
        protected override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
            if (other.CompareTag("Mob"))
            {
                Destroy(gameObject);
            }
            // Might add some animations, explosions, etc.
        }
    }
}
