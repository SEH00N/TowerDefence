using H00N.Inputs;
using H00N.Movements;
using UnityEngine;

namespace H00N.FSM
{
    public class RotateAction : FSMAction
    {
        [SerializeField] PlayInputSO input = null;
        private Camera mainCamera = null;
        private CharacterMovement movement = null;

        public override void Init(FSMBrain brain, FSMState state)
        {
            base.Init(brain, state);
            mainCamera = Camera.main;
            movement = brain.GetComponent<CharacterMovement>();
        }

        public override void EnterState()
        {
            base.EnterState();

            Ray ray = mainCamera.ScreenPointToRay(input.MousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit, float.MaxValue))
            {
                Vector3 direction = hit.point - brain.transform.position;
                direction.y = 0;
                movement.SetRotation(Quaternion.LookRotation(direction));
            }
        }
    }
}
