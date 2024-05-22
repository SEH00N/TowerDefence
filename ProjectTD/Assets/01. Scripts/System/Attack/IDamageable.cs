using UnityEngine;

namespace H00N.Attacks
{
    public interface IDamageable
    {
        public void TakeDamage(Transform attacker, float damage);
    }
}
