using System;
using System.Collections.Generic;
using _Project.Code.Config;
using _Project.Code.Gameplay.Unit;
using _Project.Code.UI.Label;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;
using Random = UnityEngine.Random;

namespace _Project.Code.Gameplay.Spawner
{
    public sealed class CircleSpawner : MonoBehaviour
    {
        [SerializeField] private Collider2D _areaCollider;
        [SerializeField] private Circle _prefab;
        
        [Inject] private readonly CircleMiniGameConfig _config;
        [Inject] private readonly CircleSpawnerLabel _label;

        private readonly List<Circle> _circles = new List<Circle>();

        private float _currentShrinkTime;
        private int _currentProgressIndex;

        private void Start()
        {
            _currentShrinkTime = _config.MaxShrinkDuration;
        }

        public event Action Finished;
        
        public int MissedCircles { get; private set; }
        
        public async UniTaskVoid SpawnCircle()
        {
            for (int i = 0; i < _config.CirclesCount; i++)
            {
                Vector3 randomPosition = GetRandomPositionInGameArea();
                Circle circle = Instantiate(_prefab, randomPosition, Quaternion.identity);
                circle.Popped += OnCirclePopped;
                circle.Shrank += OnCircleShrank;
                circle.Initialize(_currentShrinkTime);
                _circles.Add(circle);

                await UniTask.WaitForSeconds(_config.SpawnDelay);
            }
            Finished?.Invoke();
        }

        public void ReduceTime()
        {
            _currentShrinkTime -= _config.ShrinkDecrease;
        }
        
        public void Reset()
        {
            _label.Reset();
            _circles.Clear();
            MissedCircles = 0;
            _currentProgressIndex = 0;
        }

        private Vector3 GetRandomPositionInGameArea()
        {
            var areaBounds = _areaCollider.bounds;
            float randomX = Random.Range(areaBounds.min.x, areaBounds.max.x);
            float randomY = Random.Range(areaBounds.min.y, areaBounds.max.y);
            float randomZ = Random.Range(areaBounds.min.z, areaBounds.max.z);

            return new Vector3(randomX, randomY, randomZ);
        }

        private void OnCirclePopped()
        {
            UpdateProgressCircle(true);
            _currentProgressIndex++;
        }

        private void OnCircleShrank()
        {
            UpdateProgressCircle(false);
            MissedCircles++;
            _currentProgressIndex++;
        }

        private void UpdateProgressCircle(bool isPopped)
        {
            if (_currentProgressIndex < _circles.Count)
            {
                _label.ChangeColor(_currentProgressIndex, isPopped);
            }
        }
    }
}