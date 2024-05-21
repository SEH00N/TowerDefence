using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace H00N.Inputs
{
    public class InputSO : ScriptableObject
    {
        public InputMapType inputMapType;

        protected virtual void OnEnable()
        {
            Debug.Log($"Set InputSO : {inputMapType}");
        }
    }
}