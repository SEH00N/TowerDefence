using UnityEngine;

namespace H00N.Attacks
{
    public class ProjectileAttack : AttackComponent
    {
        [SerializeField] AttackDataSO attackData = null;
        [SerializeField] Projectile projectilePrefab = null;

        public override void Attack()
        {
            Projectile projectile = Instantiate(projectilePrefab);
            projectile.Init(attackData.AttackPosition);
        }
    }
}
