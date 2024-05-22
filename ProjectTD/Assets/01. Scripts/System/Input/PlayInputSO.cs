using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controls;

namespace H00N.Inputs
{
    [CreateAssetMenu(menuName = "SO/Input/PlayInput")]
    public class PlayInputSO : InputSO, IPlayActions
    {
        public event Action OnAttackEvent = null;

        public Vector2 MovementInput { get; private set; }
        public Vector2 MousePosition { get; private set; }

        protected override void OnEnable()
        {
            base.OnEnable();

            PlayActions play = InputManager.controls.Play;
            play.SetCallbacks(this);
            InputManager.RegistInputMap(this, play.Get());
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            if(context.performed)
                OnAttackEvent?.Invoke();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            MovementInput = context.ReadValue<Vector2>();
        }

        public void OnMousePosition(InputAction.CallbackContext context)
        {
            MousePosition = context.ReadValue<Vector2>();
        }
    }
}