using H00N.Animations;
using H00N.Inputs;
using H00N.Movements;
using UnityEngine;

namespace H00N.FSM
{
    public class MoveAction : FSMAction
    {
        [SerializeField] PlayInputSO input = null;
        private CharacterMovement movement = null;

        public override void Init(FSMBrain brain, FSMState state)
        {
            base.Init(brain, state);
            movement = brain.GetComponent<CharacterMovement>();
        }

        public override void EnterState()
        {
            base.EnterState();
        }

        public override void UpdateState()
        {
            base.UpdateState();
            movement.SetMovement(input.MovementInput);
        }

        public override void ExitState()
        {
            base.ExitState();
            movement.SetMovement(Vector2.zero);
        }
    }
}
