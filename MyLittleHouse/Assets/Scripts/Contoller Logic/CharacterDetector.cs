using System;
using UnityEngine;

namespace ATG
{
    public interface IDetectableShower
    {
        public event Action<bool> OnShowDetectAvailable;
        public event EventHandler<IPickable> OnPickItem;
    }
    
    public class CharacterDetector: CharacterControl, IDetectableShower
    {
        public event Action<bool> OnShowDetectAvailable;

        public event EventHandler<IPickable> OnPickItem;
        
        public CharacterDetector(InputService input, Transform objTransform, CharacterData data) 
            : base(input, objTransform, data) {}

        public override void Update()
        {
            RaycastHit hit;

            var isDetect = false;
            
            Vector3 origin = _objTransform.position;
            Vector3 direction = _objTransform.TransformDirection(Vector3.forward);
            
#if UNITY_EDITOR
            UnityEngine.Debug.DrawRay(origin,direction*_characterData.RayLength,Color.red);
#endif

            if (Physics.Raycast(origin, direction, out hit, _characterData.RayLength))
            {
                if (hit.transform.TryGetComponent(out IPickable pickObject))
                {
                    isDetect = true;
                    
                    if(_input.IsPressPick)
                        OnPickItem?.Invoke(this,pickObject);
                }
            }
            
            OnShowDetectAvailable?.Invoke(isDetect);
        }
    }
}