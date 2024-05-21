using UnityEngine;

namespace H00N.Movements
{
    [CreateAssetMenu(menuName = "SO/Movement/MovementData")]
    public class MovementDataSO : ScriptableObject
    {
        public float MaxSpeed = 2f;
        public float Acceleration = 10f;
        public float RotateSpeed = 10f;
    }
}
