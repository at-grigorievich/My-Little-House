using System;
using UnityEngine;

namespace ATG
{
    [RequireComponent(typeof(Light))]
    public class LightingAnimation : MonoBehaviour
    {
        [SerializeField] private AnimationCurve _lightIntensity;

        private float _totalTime,_currentTime;

        private Light _light;

        private void Awake()
        {
            _light = GetComponent<Light>();
            _totalTime = _lightIntensity.keys[^1].time;
        }


        private void Update()
        {
            _light.intensity = _lightIntensity.Evaluate(_currentTime);
            _currentTime += Time.deltaTime;

            if (_currentTime >= _totalTime)
                _currentTime = 0f;
        }
    }
}
