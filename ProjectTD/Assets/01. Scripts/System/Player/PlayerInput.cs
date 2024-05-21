using H00N.Inputs;
using H00N.Movements;
using UnityEngine;

namespace H00N.Players
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] PlayInputSO input = null;

        private CharacterMovement movement = null;

        private void Awake()
        {
            movement = GetComponent<CharacterMovement>();
        }

        private void Update()
        {
            movement.SetMovement(input.MovementInput);
        }
    }
}
