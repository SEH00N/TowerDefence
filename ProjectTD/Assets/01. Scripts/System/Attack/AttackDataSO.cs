using UnityEngine;

namespace H00N.Attacks
{
    [CreateAssetMenu(menuName = "SO/Attack/AttackData")]
    public class AttackDataSO : ScriptableObject
    {
        public Transform AttackPosition = null;
        public LayerMask CastLayer = 0;
        public float Radius = 1f;
        public float Damage = 10f;

        [Space(15f)]
        public bool Cooldown = false;
        public float AttackDelay = 1f;
    }
}
