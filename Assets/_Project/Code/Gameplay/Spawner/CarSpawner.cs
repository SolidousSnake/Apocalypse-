using System;
using System.Threading;
using _Project.Code.Config;
using _Project.Code.Gameplay.Unit;
using _Project.Code.Gameplay.Unit.Behaviour;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Random = UnityEngine.Random;

namespace _Project.Code.Gameplay.Spawner
{
    public sealed class CarSpawner : MonoBehaviour, IDisposable
    {
        [SerializeField] private Transform[] _spawnPoints;
       
        [Inject] private readonly LevelConfig _levelConfig;
        [Inject] private readonly IObjectResolver _container;

        private readonly CancellationTokenSource _cts = new();
        
        public async UniTask Spawn()
        {
            while (!_cts.IsCancellationRequested)
            {
                _container.Instantiate(GetRandomCar(), GetRandomSpawnPoint().position, GetRandomSpawnPoint().rotation, null);
                
                await UniTask.Delay(GetDelay());
            }
        }

        private Transform GetRandomSpawnPoint() => _spawnPoints[Random.Range(0, _spawnPoints.Length)];
        
        private Car GetRandomCar() => _levelConfig.Cars[Random.Range(0, _levelConfig.Cars.Length)];

        private TimeSpan GetDelay() => 
            TimeSpan.FromSeconds(Random.Range(_levelConfig.MinCarSpawnDelay, _levelConfig.MaxCarSpawnDelay));

        public void Dispose() => _cts.Cancel();
    }
}