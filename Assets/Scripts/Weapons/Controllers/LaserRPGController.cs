using UnityEngine;

namespace Weapons.Controllers
{
    public class LaserRPGController : WeaponController
    {
        protected override void Start()
        {
            base.Start();
        }

        protected override void Attack()
        {
            base.Attack();
            Vector3 position = transform.position;
            var mob = Physics2D.OverlapCircle(position, weaponData.projectileRange, mobLayerMask);
            if (mob != null)
            {
                var rocket = Instantiate(weaponData.weaponPrefab, position, Quaternion.identity);
                rocket.GetComponent<LaserRPGBehaviour>().CheckDirection(mob.transform.position - position);
            }
        }
    }
}
