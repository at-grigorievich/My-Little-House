using System;
using ATG.Data;
using UnityEngine;

namespace ATG
{
    public class ItemLogic : MonoBehaviour, IPickable
    {
        [SerializeField] private ItemData _myData;
        
        public Sprite DoPick()
        {
            gameObject.SetActive(false);

            if (_myData.ItemSprite == null)
                throw new NullReferenceException($"Sprite is null! {_myData.name}");
            
            return _myData.ItemSprite;
        }
    }
}