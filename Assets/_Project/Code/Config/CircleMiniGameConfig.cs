using UnityEngine;

namespace _Project.Code.Config
{
    [CreateAssetMenu]
    public sealed class CircleMiniGameConfig : ScriptableObject
    {
        [SerializeField] private float _minCircleShrinkDuration;
        [SerializeField] private float _maxCircleShrinkDuration;
        [SerializeField] private float _shrinkDecrease;
        [SerializeField] private float _spawnDelay;
        [SerializeField] private float _damagePercent;
        [SerializeField] private int _circlesCount;
        [SerializeField] private int _countToWin;
        
        public float MinShrinkDuration => _minCircleShrinkDuration;
        public float MaxShrinkDuration => _maxCircleShrinkDuration;
        public float ShrinkDecrease => _shrinkDecrease;
        public float SpawnDelay => _spawnDelay;
        public float DamagePercent => _damagePercent;
        public int CirclesCount => _circlesCount;
        public int CountToWin => _countToWin;
    }
}