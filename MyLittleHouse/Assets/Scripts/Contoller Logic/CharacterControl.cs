using UnityEngine;

namespace ATG
{
    public abstract class CharacterControl
    {
        protected readonly InputService _input;
        protected readonly CharacterData _characterData;

        protected readonly Transform _objTransform;

        protected CharacterControl(InputService input,Transform objTransform, CharacterData data)
        {
            _input = input;

            _characterData = data;
            
            _objTransform = objTransform;
        }

        public abstract void Update();
    }
}