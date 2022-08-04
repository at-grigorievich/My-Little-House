using System;
using UnityEngine;

namespace ATG
{
    [RequireComponent(typeof(CharacterController))]
    public class Character : MonoBehaviour
    {
        [SerializeField] private CharacterData _data;
        
        private Camera _camera;
        
        private CharacterController _controller;
        
        private CharacterControl _movementControl;
        private CharacterControl _rotateControl;
        private CharacterDetector _detector;

        public InputService InputService { get; private set; }

        public IDetectableShower DetectableShower => _detector;

        private void Awake()
        {
            InputService = new InputService();
            _controller = GetComponent<CharacterController>();

            _camera = Camera.main;

            if (_camera == null)
                throw new NullReferenceException("Cant find camera !");
            
            _rotateControl = new CharacterRotate(InputService, transform,_data, _camera);
            _movementControl = new CharacterMovement(InputService, _controller, _data);
            _detector = new CharacterDetector(InputService, _camera.transform, _data);
        }

        private void Update()
        {
            _movementControl.Update();
            _rotateControl.Update();
            _detector.Update();
        }

        private void OnEnable()
        {
            InputService.Enable();
        }
        
        private void OnDisable()
        {
            InputService.Disable();
        }
    }
}