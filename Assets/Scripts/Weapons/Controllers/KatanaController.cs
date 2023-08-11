using Mobs;
using UnityEngine;

namespace Weapons.Controllers
{
    public class KatanaController : WeaponController
    {
        [SerializeField] private LayerMask mobLayerMask;
        
        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
        }

        protected override void Attack()
        {
            base.Attack();
            Vector3 position = transform.position;
            var mob = Physics2D.OverlapCircle(position, weaponData.meleeRange, mobLayerMask);
            if (mob != null)
            {
                mob.GetComponent<Mob>().TakeDamage(weaponData.damage);
                var slash = Instantiate(weaponData.weaponPrefab, position, Quaternion.identity);
                slash.GetComponent<KatanaBehaviour>().CheckDirection(mob.transform.position - position);
            }
        }
    }
}
