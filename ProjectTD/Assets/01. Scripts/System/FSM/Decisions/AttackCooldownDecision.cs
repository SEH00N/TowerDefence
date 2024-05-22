using H00N.Attacks;
using UnityEngine;

namespace H00N.FSM
{
    public class AttackCooldownDecision : FSMDecision
    {
        [SerializeField] AttackDataSO attackData = null;

        public override bool MakeDecision()
        {
            return attackData.Cooldown;
        }
    }
}