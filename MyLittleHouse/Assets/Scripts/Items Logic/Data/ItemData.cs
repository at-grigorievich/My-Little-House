using UnityEngine;

namespace ATG.Data
{
    [CreateAssetMenu(fileName = "Item Data", menuName = "Items/New Item Data", order = 0)]
    public class ItemData : ScriptableObject
    {
        [field: SerializeField] public ItemLogic ItemPrefab { get; private set; }
        [field: SerializeField] public Sprite ItemSprite { get; private set; }
    }
}