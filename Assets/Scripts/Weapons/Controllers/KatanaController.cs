using System;
using Mobs;
using Player;
using UnityEngine;

namespace Weapons.Controllers
{
    public class KatanaController : WeaponController
    {
        
        private float damage;
        
        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
            CalculateDamage();
        }

        protected override void Attack()
        {
            base.Attack();
            Vector3 position = transform.position;
            var mob = Physics2D.OverlapCircle(position, weaponData.meleeRange, mobLayerMask);
            if (mob != null)
            {
                mob.GetComponent<Mob>().TakeDamage(damage);
                var slash = Instantiate(weaponData.weaponPrefab, position, Quaternion.identity);
                slash.GetComponent<KatanaBehaviour>().CheckDirection(mob.transform.position - position);
            }
        }

        private void CalculateDamage()
        {
            damage = weaponData.damage * ((100 + player.CurrentStrength) / 100);
        }
    }
}
