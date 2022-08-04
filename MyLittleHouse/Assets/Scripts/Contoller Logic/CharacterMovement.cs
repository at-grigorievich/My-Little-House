using UnityEngine;

namespace ATG
{
    public class CharacterMovement: CharacterControl
    {
        private const float Gravity = -9.8f;
        
        public CharacterMovement(InputService input, CharacterController character, CharacterData data) 
            : base(input, character,data) {}

        public override void Update()
        {
            float movementSpeed = _characterData.MoveSpeed;
            
            Vector3 dir = _objTransform.right*_input.SideDir 
                          + _objTransform.forward*_input.ForwardDir;

            if (!_character.isGrounded) dir.y = Gravity;
            
            _character.Move(dir * movementSpeed * Time.deltaTime);
        }
    }
}