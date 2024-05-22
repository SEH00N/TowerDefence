using UnityEngine;

namespace H00N.Movements
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] MovementDataSO movementData = null;

        [Space(15f)]
        [SerializeField] float gravityScale = 1f;
        private const float GRAVITY_SCALE = -9.81f;

        private CharacterController characterController = null;

        private Vector2 direction = Vector2.zero;
        private float velocity = 0f;
        private float verticalVelocity = 0f;

        public bool IsGround => characterController.isGrounded;
        public bool UpdateRotation = true;

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
        }

        private void FixedUpdate()
        {
            CalculateVelocity();
            ApplyMovement();
            ApplyGravity();
        }

        private void CalculateVelocity()
        {
            if(direction.sqrMagnitude <= 0f)
                return;

            velocity += movementData.Acceleration * Time.fixedDeltaTime;
            velocity = Mathf.Min(velocity, movementData.MaxSpeed);
        }

        private void ApplyMovement()
        {
            if(direction.sqrMagnitude <= 0f)
                return;

            Vector3 movement = new Vector3(direction.x, 0f, direction.y) * velocity;
            characterController.Move(movement * Time.fixedDeltaTime);

            if(UpdateRotation)
            {
                Quaternion targetRotation = Quaternion.LookRotation(movement);
                targetRotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.fixedDeltaTime * movementData.RotateSpeed);
                SetRotation(targetRotation);
            }
        }

        private void ApplyGravity()
        {
            if(IsGround && verticalVelocity < 0f)
                verticalVelocity = 0f;

            verticalVelocity += GRAVITY_SCALE * Time.fixedDeltaTime;
            characterController.Move(Vector3.up * (Time.fixedDeltaTime * verticalVelocity));
        }

        public void SetMovement(Vector2 direction)
        {
            bool isStopped = direction.sqrMagnitude <= 0f;

            float dot = Vector3.Dot(this.direction.normalized, direction.normalized);
            float angle = Mathf.Acos(dot);
            bool isTurned = angle > 90f;

            if(isStopped || isTurned)
                velocity = 0f;

            this.direction = direction;
        }

        public void SetRotation(Quaternion rotate)
        {
            transform.rotation = rotate;
        }
    }
}
