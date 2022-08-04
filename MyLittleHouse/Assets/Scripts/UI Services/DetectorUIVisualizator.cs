using TMPro;

namespace ATG
{
    public class DetectorUIVisualizator
    {
        private readonly IDetectableShower _detectableShower;
        private readonly TextMeshProUGUI _data;

        /*~DetectorUIVisualizator()
        {
            _detectableShower.OnShowDetectAvailable -= OnShowDetectAvailable;
        }*/
        
        public DetectorUIVisualizator(TextMeshProUGUI data, IDetectableShower shower)
        {
            _data = data;
            _data.enabled = false;

            _detectableShower = shower;
            _detectableShower.OnShowDetectAvailable += OnShowDetectAvailable;
        }

        private void OnShowDetectAvailable(bool isNeedToVisible)
        {
            if(_data.enabled == isNeedToVisible)
                return;

            _data.enabled = isNeedToVisible;
        }
    }
}