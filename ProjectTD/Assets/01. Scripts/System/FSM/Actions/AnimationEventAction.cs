using H00N.Animations;
using UnityEngine;
using UnityEngine.Events;

namespace H00N.FSM
{
    public class AnimationEventAction : FSMAction
    {
        [SerializeField] UnityEvent onAnimationEndEvent;
        [SerializeField] UnityEvent onAnimationTriggerEvent;

        private CharacterAnimator animator = null;

        public override void Init(FSMBrain brain, FSMState state)
        {
            base.Init(brain, state);
            animator = brain.GetComponent<CharacterAnimator>();
        }

        public override void EnterState()
        {
            base.EnterState();
            animator.AnimationEvent.OnAnimationEndEvent += HandleAnimationEnd;
            animator.AnimationEvent.OnAnimationTriggerEvent += HandleAnimationTrigger;
        }

        public override void ExitState()
        {
            base.ExitState();
            animator.AnimationEvent.OnAnimationEndEvent -= HandleAnimationEnd;
            animator.AnimationEvent.OnAnimationTriggerEvent -= HandleAnimationTrigger;
        }

        private void HandleAnimationEnd()
        {
            onAnimationEndEvent?.Invoke();
        }

        private void HandleAnimationTrigger()
        {
            onAnimationTriggerEvent?.Invoke();
        }
    }
}
