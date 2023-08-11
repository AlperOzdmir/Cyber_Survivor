using UnityEngine;
using Vector2 = System.Numerics.Vector2;

namespace Weapons.Controllers
{
    public class LaserRevolverController : WeaponController
    {
        [SerializeField] private LayerMask mobLayerMask;
        
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
                 var laser = Instantiate(weaponData.projectilePrefab, position, Quaternion.identity);
                 laser.GetComponent<LaserRevolverBehaviour>().CheckDirection(mob.transform.position - position);
             }
         }
    }
}
