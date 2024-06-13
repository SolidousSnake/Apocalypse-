using UnityEngine;

namespace _Project.Code.Config
{
    [CreateAssetMenu]
    public sealed class CarConfig : ScriptableObject
    {
        [SerializeField] private float _health;
        [SerializeField] private int _minResourcesCount;
        [SerializeField] private int _maxResourcesCount;

        public float Health => _health;
        public int MinResources => _minResourcesCount;
        public int MaxResources => _maxResourcesCount;
    }
}