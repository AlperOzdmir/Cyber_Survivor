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
             var laser = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
             laser.GetComponent<LaserRevolverBehaviour>().CheckDirection(PlayerMovement.movementDirection);
         }
    }
}
