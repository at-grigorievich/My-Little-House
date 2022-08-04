using UnityEngine;

namespace ATG
{
    public class CharacterRotate: CharacterControl
    {
        private readonly float _minVertical, _maxVertical;

        private readonly Transform _cameraTransform;

        private float _curVertRot;
        
        public CharacterRotate(InputService input, CharacterController character, 
            CharacterData data,Camera camera) : base(input, character,data)
        {
            _minVertical = -80f;
            _maxVertical = 80f;

            _cameraTransform = camera.transform;
        }

        public override void Update()
        {
            float rotateSens = _characterData.RotateSensivity; 
            
            float yAxis = _input.HorRot * rotateSens * Time.deltaTime;
            float xAxis = _input.VertRot * rotateSens * Time.deltaTime;

            _curVertRot -= xAxis;
            _curVertRot = Mathf.Clamp(_curVertRot, _minVertical, _maxVertical);
            
            _cameraTransform.localRotation = Quaternion.Euler(_curVertRot,0f,0f);
            _objTransform.Rotate(Vector3.up*yAxis);
        }
    }
}