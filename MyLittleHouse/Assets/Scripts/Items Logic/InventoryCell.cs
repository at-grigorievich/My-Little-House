using System;
using ATG.Data;
using UnityEngine;
using UnityEngine.UI;

namespace ATG
{
    [RequireComponent(typeof(Button))]
    public class InventoryCell : MonoBehaviour
    {
        [SerializeField] private Image _src;
        [SerializeField] private Button _button;
        
        private ItemVisualizeData _data;

        public event EventHandler<ItemVisualizeData> OnShowCurrentData;
        
        public bool IsEmpty => _data == null;

        private void OnEnable()
        {
            Hide();
        }

        public void SetupCell(ItemVisualizeData data)
        {
            _data = data;
            
            _src.sprite = data.SrcSprite;
            _src.enabled = true;

            _button.interactable = true;
            _button.onClick.AddListener(OnClick);
        }


        private void Hide()
        {
            _data = null;
            
            _src.sprite = null;
            _src.enabled = false;

            _button.interactable = false;
            _button.onClick.RemoveAllListeners();
        }

        private void OnClick() => OnShowCurrentData?.Invoke(this,_data);
        
    }
}