using Mobs;
using UnityEngine;

namespace Weapons.Controllers
{
    public class ZapperController : WeaponController
    {
        protected int zapCount;
        
        protected override void Start()
        {
            base.Start();
            zapCount = weaponData.numberOfBounces;
        }

        protected override void Attack()
        {
            base.Attack();
            Vector3 position = transform.position;
            var mob = Physics2D.OverlapCircle(position, weaponData.projectileRange, mobLayerMask);
            if (mob != null)
            {
                ZapEnemy(mob.transform.position);
            }
        }

        private void ZapEnemy(Vector3 position)
        {
            var mob = Physics2D.OverlapCircle(position, weaponData.meleeRange, mobLayerMask);
            if (mob != null)
            {
                Vector3 mobPosition = mob.transform.position;
                mob.GetComponent<Mob>().TakeDamage(weaponData.damage);
                var zap = Instantiate(weaponData.weaponPrefab, mobPosition, Quaternion.identity);
                zapCount--;
                if (zapCount > 0)
                {
                    ZapEnemy(mobPosition);
                }
                else
                {
                    zapCount = weaponData.numberOfBounces;
                }
            }
            else
            {
                zapCount = weaponData.numberOfBounces;
            }
        }
    }
}
