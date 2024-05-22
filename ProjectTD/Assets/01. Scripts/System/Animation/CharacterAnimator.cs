using UnityEngine;

namespace H00N.Animations
{
    public class CharacterAnimator : MonoBehaviour
    {
        private Animator animator = null;

        private CharacterAnimationEvent animationEvent = null;
        public CharacterAnimationEvent AnimationEvent => animationEvent;

        private readonly int IS_WALK_HASH = Animator.StringToHash("IsWalk");
        private readonly int IS_HIT_HASH = Animator.StringToHash("IsHit");
        private readonly int IS_ATTACK_HASH = Animator.StringToHash("IsAttack");
        private readonly int IS_IDLE_HASH = Animator.StringToHash("IsIdle");

        private void Awake()
        {
            animator = transform.Find("Visual").GetComponent<Animator>();
            animationEvent = animator.GetComponent<CharacterAnimationEvent>();
        }

        public void ToggleIdle(bool value) => ToggleBoolean(IS_IDLE_HASH, value);

        public void ToggleWalk(bool value) =>  ToggleBoolean(IS_WALK_HASH, value);

        public void ToggleHit(bool value) => ToggleBoolean(IS_HIT_HASH, value);

        public void ToggleAttack(bool value) => ToggleBoolean(IS_ATTACK_HASH, value);

        private void ToggleBoolean(int hash, bool value)
        {
            animator.SetBool(hash, value);
        }
    }
}
