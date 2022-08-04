using UnityEngine;

namespace ATG
{
    [CreateAssetMenu(fileName = "Character Data", menuName = "Character/New Data", order = 0)]
    public class CharacterData : ScriptableObject
    {
        [field: SerializeField] public float MoveSpeed { get; private set; }
        [field: SerializeField] public float RotateSensivity { get; private set; }

        public int InventoryCapacity => 9;
        [field: SerializeField] public float RayLength { get; private set; }
    }
}