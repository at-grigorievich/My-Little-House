using System;
using System.Collections.Generic;
using System.Linq;
using ATG.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ATG
{
    [Serializable]
    public class InventoryInfoContainer
    {
        [SerializeField] private Image _mainImage;
        [SerializeField] private TextMeshProUGUI _data;

        public void ShowData(ItemVisualizeData data)
        {
            _mainImage.sprite = data.SrcSprite;
            _data.SetText(data.SrcAbout);

            _mainImage.enabled = true;
        }

        public void Clear()
        {
            _mainImage.sprite = null;
            _mainImage.enabled = false;
            
            _data.SetText(string.Empty);
        }
    }
    
    public class InventoryVisualizator
    {
        private readonly IDetectableShower _detectableShower;
        private readonly InventoryInfoContainer _infoContainer;
        
        private readonly Canvas _canvas;
        
        private readonly RectTransform _gridRoot;
        private readonly HashSet<InventoryCell> _cells;

        public InventoryVisualizator(Canvas canvas,
            RectTransform gridRoot,IDetectableShower shower, InventoryInfoContainer infoContainer,
            InventoryCell prefab, int cellCount)
        {
            _canvas = canvas;
            _gridRoot = gridRoot;

            _detectableShower = shower;
            _infoContainer = infoContainer;
            
            _detectableShower.OnPickItem += OnPickItem;
            
            _cells = new HashSet<InventoryCell>();
            CreateGrid(cellCount,prefab);  
            
            SetEnable(false);
            
            _infoContainer.Clear();
        }
        
        
        public void SetEnable(bool isEnable)
        {
            _canvas.enabled = isEnable;
            
            if (!isEnable)
            {
                _infoContainer.Clear();
            }
        }

        private void OnPickItem(object sender, IPickable e)
        {
            if (TryAddItem(e.DoPick()))
            {
                e.Disable();
            }
        }
        private bool TryAddItem(ItemVisualizeData data)
        {
            InventoryCell selected = _cells.FirstOrDefault(c => c.IsEmpty);

            if (selected == null) return false;
            
            selected.SetupCell(data);
            return true;
        }

        
        private void CreateGrid(int cellCount, InventoryCell prefab)
        {
            for (int i = 0; i < cellCount; i++)
            {
                var instance = GameObject.Instantiate(prefab, _gridRoot);
                instance.OnShowCurrentData += 
                    (sender, data) => _infoContainer.ShowData(data);
                
                _cells.Add(instance);
            }   
        }
    }
}