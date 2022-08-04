using System;
using UnityEngine;

namespace ATG
{
    public class SkyboxRotation
    {
        private static readonly int Rotation = Shader.PropertyToID("_Rotation");
        public const float RotateSpeed = 2f;
        
        private readonly Material _rotatedMaterial;

        private float _curRotation;

        public SkyboxRotation(Material mat)
        {
            _rotatedMaterial = mat;
        }

        public void DoRotate()
        {
            _curRotation += Time.deltaTime;
            _rotatedMaterial.SetFloat(Rotation, _curRotation);
        }
    }
    
    public class DayNightService : MonoBehaviour
    {
        private static readonly int Tint = Shader.PropertyToID("_Tint");
        
        [SerializeField] private float _dayTime;
        [SerializeField] private Light _directionLight;
        
        [SerializeField] private Gradient _skyboxGradient;
        [SerializeField] private AnimationCurve _lightCurve;

        private SkyboxRotation _skyboxRotation;
        
        private float _curTime;
        
        private Material _skyboxMaterial;

        private Action _setTime;

        private void Awake()
        {
            _skyboxMaterial = RenderSettings.skybox;
            _setTime = SetToNight;

            _skyboxRotation = new SkyboxRotation(_skyboxMaterial);
        }
        private void Update()
        {
            if (_curTime > _dayTime)
            {
                _curTime = 0f;
                SwitchSetTime();
            }

            _setTime?.Invoke();
            _curTime += Time.deltaTime;
            
            _skyboxRotation.DoRotate();
        }
        private void OnDisable()
        {
            _setTime = null;
            _skyboxMaterial.SetColor(Tint,_skyboxGradient.Evaluate(0f));
        }

        
        private void SetToNight()
        {
            var time = _curTime / _dayTime;
            AnimateSetDayNight(time);
        }
        private void SetToDay()
        {
            var time = 1f - _curTime / _dayTime;
            AnimateSetDayNight(time);
        }

        private void AnimateSetDayNight(float curTime)
        {
            _directionLight.intensity = _lightCurve.Evaluate(curTime);
            _skyboxMaterial.SetColor(Tint, _skyboxGradient.Evaluate(curTime));
        }
        private void SwitchSetTime() =>
            _setTime = _setTime == SetToNight ? SetToDay : SetToNight;
    }
}