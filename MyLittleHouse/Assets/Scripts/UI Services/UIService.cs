using System;
using TMPro;
using UnityEngine;

namespace ATG
{
    public class UIService : MonoBehaviour
    {
        [SerializeField] private Character _character;
        [SerializeField] private TextMeshProUGUI _detectorDataText;
        [Space(15)] 
        [SerializeField] private Canvas _gamePanelCanvas;
        [SerializeField] private Canvas _inventoryCanvas;
        [Space(15)]
        [SerializeField] private InventoryInfoContainer _inventoryInfo;
        [Space(5)]
        [SerializeField] private int _cellCount;
        [SerializeField] private RectTransform _inventoryGridRoot;
        [SerializeField] private InventoryCell _cellPrefab;
        
        private DetectorUIVisualizator _detectorVisualizator;
        private InventoryVisualizator _inventoryVisualizator;

        private Action _onOpenInventory;
        
        private void Start()
        {
            IDetectableShower shower = _character.DetectableShower;
            
            _detectorVisualizator = new DetectorUIVisualizator(_detectorDataText,shower);

            _inventoryVisualizator = 
                new InventoryVisualizator(_inventoryCanvas,_inventoryGridRoot,shower, _inventoryInfo,
                    _cellPrefab, _cellCount);
            
            _onOpenInventory = OpenInventory;
            _character.InputService.OnPressInventory += () => _onOpenInventory?.Invoke();

            Cursor.visible = false;
        }

        private void OpenInventory()
        {
            // TODO: REFACTOR
            _gamePanelCanvas.enabled = false;
            
            _inventoryVisualizator.SetEnable(true);
            _onOpenInventory = CloseInventory;

            Cursor.visible = true;
        }

        private void CloseInventory()
        {
            // TODO: REFACTOR
            _gamePanelCanvas.enabled = true;
            
            _inventoryVisualizator.SetEnable(false);
            _onOpenInventory = OpenInventory;

            Cursor.visible = false;
        }
    }
}