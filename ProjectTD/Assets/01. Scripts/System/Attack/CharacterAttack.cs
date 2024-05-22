using UnityEngine;

namespace H00N.Attacks
{
    public class CharacterAttack : MonoBehaviour
    {
        [SerializeField] AttackDataSO attackData = null;
        [SerializeField] Transform attackPosition = null;

        [Space(15f)]
        [SerializeField] AttackComponent attackComponent = null;

        private float timer = 0f;

        private void Awake()
        {
            attackData.AttackPosition = attackPosition;
        }

        private void Update()
        {
            if(attackData.Cooldown == false)
                return;

            timer += Time.deltaTime;
            if(timer >= attackData.AttackDelay)
            {
                timer = 0f;
                attackData.Cooldown = false;
            }
        }

        public void Attack()
        {
            attackComponent?.Attack();
            attackData.Cooldown = true;
        }

        public void ChangeAttackComponent(AttackComponent component) => attackComponent = component;
    }
}
