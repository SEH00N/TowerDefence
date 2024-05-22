using H00N.Inputs;
using UnityEngine;

namespace H00N.FSM
{
    public class MoveInputDecision : FSMDecision
    {
        [SerializeField] PlayInputSO input = null;

        public override bool MakeDecision()
        {
            return input.MovementInput.sqrMagnitude > 0f;    
        }
    }
}
