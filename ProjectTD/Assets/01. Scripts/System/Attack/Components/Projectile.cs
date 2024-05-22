using UnityEngine;
using UnityEngine.Events;

namespace H00N.Attacks
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] UnityEvent OnHitEvent = null;
        [SerializeField] AttackDataSO attackData = null;
        [SerializeField] float speed = 5f;
        private DamageCaster damageCaster = null;

        private void Awake()
        {
            damageCaster = GetComponent<DamageCaster>();
            attackData.AttackPosition = transform;
        }

        private void FixedUpdate()
        {
            transform.Translate(Vector3.forward * (speed * Time.fixedDeltaTime));
        }

        private void OnCollisionEnter(Collision other)
        {
            damageCaster.CastDamageAll();
            OnHitEvent?.Invoke();
            
            Destroy(gameObject);
        }

        public void Init(Transform attackPosition)
        {
            Vector3 position = attackPosition.position;
            Quaternion rotation = Quaternion.LookRotation(attackPosition.forward);
            transform.SetPositionAndRotation(position, rotation);
        }
    }
}
