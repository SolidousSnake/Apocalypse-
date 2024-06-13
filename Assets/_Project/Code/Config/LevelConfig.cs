using _Project.Code.Gameplay.Unit;
using UnityEngine;

namespace _Project.Code.Config
{
    [CreateAssetMenu]
    public sealed class LevelConfig : ScriptableObject
    {
        [SerializeField] private Car[] _cars;
        [SerializeField] private float _initialPlayerHealth;
        [SerializeField] private float _maxPlayerHealth;
        [SerializeField] private float _minCarSpawnDelay;
        [SerializeField] private float _maxCarSpawnDelay;

        public Car[] Cars => _cars;
        public float InitialPlayerHealth => _initialPlayerHealth;
        public float MaxPlayerHealth => _maxPlayerHealth;
        public float MinCarSpawnDelay => _minCarSpawnDelay;
        public float MaxCarSpawnDelay => _maxCarSpawnDelay;
    }
}