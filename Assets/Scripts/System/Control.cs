using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
    public class Control : Singleton<Control>
    {
        private MainControl _control;

        private void Awake()
        {
            _control = new MainControl();
            _control.Game.Jump.performed += _ => OnJump?.Invoke();
            _control.Game.Roll.performed += _ => OnRoll?.Invoke();
        }

        public void Enable() => _control.Enable();
        public void Disable() => _control.Disable();

        public delegate void JumpAction();
        public event JumpAction OnJump;
        public delegate void RollAction();
        public event RollAction OnRoll;
    }
}
