using System;
using UnityEngine;

namespace ATG
{
    public class InputService
    {
        private readonly PlayerInput _input;

        public Vector2 MoveAxis => _input.Player.Move.ReadValue<Vector2>();
        public Vector2 RotateAxis => _input.Player.Rotate.ReadValue<Vector2>();
        
        public float ForwardDir => MoveAxis.y;
        public float SideDir => MoveAxis.x;

        public float VertRot=> RotateAxis.y;
        public float HorRot => RotateAxis.x;
        
        public event Action OnPressPick;
        
        public InputService()
        {
            _input = new PlayerInput();
            _input.Player.Pick.performed += context => OnPressPick?.Invoke();
        }

        public void Enable() => _input.Enable();
        public void Disable() => _input.Disable();
    }
}
