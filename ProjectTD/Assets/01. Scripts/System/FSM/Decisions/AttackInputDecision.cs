using System;
using H00N.Attacks;
using H00N.Inputs;
using UnityEngine;

namespace H00N.FSM
{
    public class AttackInputDecision : FSMDecision
    {
        [SerializeField] PlayInputSO input = null;
        [SerializeField] AttackDataSO atackData = null;
        private bool cache = false;

        private void Awake()
        {
            input.OnAttackEvent += HandleAttack;
        }

        private void HandleAttack()
        {
            if(atackData.Cooldown == false)
                cache = true;
        }

        public override bool MakeDecision()
        {
            return cache;
        }

        public override void EnterState()
        {
            base.EnterState();
            cache = false;
        }

        public override void ExitState()
        {
            base.ExitState();
            cache = false;
        }
    }
}
