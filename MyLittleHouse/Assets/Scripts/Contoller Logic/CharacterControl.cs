using UnityEngine;

namespace ATG
{
    public abstract class CharacterControl
    {
        protected readonly InputService _input;
        protected readonly CharacterData _characterData;
        
        protected readonly CharacterController _character;

        protected readonly Transform _objTransform;

        public CharacterControl(InputService input,CharacterController character, CharacterData data)
        {
            _input = input;
            _character = character;

            _characterData = data;
            
            _objTransform = _character.transform;
        }

        public abstract void Update();
    }
}