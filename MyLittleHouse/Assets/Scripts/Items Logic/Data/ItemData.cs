using System;
using UnityEngine;

namespace ATG.Data
{
    [Serializable]
    public class ItemVisualizeData
    {
        [field: SerializeField] public Sprite SrcSprite { get; private set; }
        [field: SerializeField] public string SrcAbout { get; private set; }
    }
    
    [CreateAssetMenu(fileName = "Item Data", menuName = "Items/New Item Data", order = 0)]
    public class ItemData : ScriptableObject
    {
        [field: SerializeField] public ItemLogic ItemPrefab { get; private set; }
        [field: SerializeField] public ItemVisualizeData VisualizeData { get; private set; }
    }
}