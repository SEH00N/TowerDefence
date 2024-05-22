using UnityEngine;

namespace H00N.Attacks
{
    public class DamageCaster : MonoBehaviour
    {
        [SerializeField] AttackDataSO attackData = null;
        [SerializeField] int containerSize = 10;
        private Collider[] container = null;

        private void Awake()
        {
            SetContainer(containerSize);
        }

        public void SetContainer(int size)
        {
            containerSize = size;
            container = new Collider[containerSize];
        }

        public void CastDamage()
        {
            int count = Cast();
            if(count <= 0)
                return;

            if(container[0].TryGetComponent<IDamageable>(out IDamageable id))
                id.TakeDamage(transform, attackData.Damage);
        }

        public void CastDamageAll()
        {
            int count = Cast();
            for(int i = 0; i < count; ++i)
            {
                if(container[i].TryGetComponent<IDamageable>(out IDamageable id))
                    id.TakeDamage(transform, attackData.Damage);
            }
        }

        private int Cast()
        {
            return Physics.OverlapSphereNonAlloc(attackData.AttackPosition.position, attackData.Radius, container, attackData.CastLayer);
        }

        #if UNITY_EDITOR
        [Space(15f)]
        [SerializeField] bool gizmo = true;
        private void OnDrawGizmos()
        {
            if(gizmo == false)
                return;

            if(attackData == null || attackData.AttackPosition == null)
                return;

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackData.AttackPosition.position, attackData.Radius);
        }
        #endif   
    }
}
