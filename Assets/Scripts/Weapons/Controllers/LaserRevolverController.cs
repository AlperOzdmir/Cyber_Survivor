using UnityEngine;

namespace Weapons.Controllers
{
    public class LaserRevolverController : WeaponController
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
                 var laser = Instantiate(weaponData.weaponPrefab, position, Quaternion.identity);
                 laser.GetComponent<LaserRevolverBehaviour>().CheckDirection(mob.transform.position - position);
             }
         }
    }
}
