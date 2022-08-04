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

        private InputService _inputService;
        
        private void Awake()
        {
            _inputService = new InputService();
            _controller = GetComponent<CharacterController>();

            _camera = Camera.main;

            _rotateControl = new CharacterRotate(_inputService, _controller,_data, _camera);
            _movementControl = new CharacterMovement(_inputService, _controller, _data);
        }

        private void Start()
        {
            
            Cursor.visible = false;
        }

        private void Update()
        {
            _movementControl.Update();
            _rotateControl.Update();
        }

        private void OnEnable()
        {
            _inputService.Enable();
        }
        private void OnDisable()
        {
            _inputService.Disable();
        }
    }
}