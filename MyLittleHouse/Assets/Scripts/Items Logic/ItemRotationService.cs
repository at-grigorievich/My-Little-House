using System.Linq;
using UnityEngine;

namespace ATG
{
    public class ItemRotationService : MonoBehaviour
    {
        [SerializeField] private string _itemsTag;
        [SerializeField] private float _rotationSpeed;

        private Transform[] _items;

        private void Awake()
        {
            _items = GameObject.FindGameObjectsWithTag(_itemsTag)
                .Select(o => o.transform).ToArray();
        }

        private void Update()
        {
            for (int i = 0; i < _items.Length; i++)
            {
                if (_items[i] != null)
                {
                    _items[i].Rotate(Vector3.up * _rotationSpeed * Time.deltaTime);
                }
            }
        }
    }
}