using H00N.Inputs;
using UnityEngine;

namespace H00N
{
    public class GameManager : MonoBehaviour
    {
        private void Awake()
        {
            InputManager.ChangeInputMap(InputMapType.Play);
        }
    }
}
