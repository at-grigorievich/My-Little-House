using ATG.Data;
using UnityEngine;

namespace ATG
{
    public class ItemLogic : MonoBehaviour, IPickable
    {
        [SerializeField] private ItemData _myData;
        
        public ItemVisualizeData DoPick()
        {
            return _myData.VisualizeData;
        }

        public void Disable() => gameObject.SetActive(false);
    }
}