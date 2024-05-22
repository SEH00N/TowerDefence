using UnityEngine;

namespace H00N.Attacks
{
    public class Projectile : MonoBehaviour
    {
        private AttackDataSO attackData = null;

        public void Init(AttackDataSO data)
        {
            attackData = data;

            Vector3 position = attackData.AttackPosition.position;
            Quaternion rotation = Quaternion.LookRotation(attackData.AttackPosition.forward);
            transform.SetPositionAndRotation(position, rotation);
        }
    }
}
