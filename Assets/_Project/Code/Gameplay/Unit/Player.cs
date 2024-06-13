using System;
using System.Threading;
using _Project.Code.Gameplay.GameResult;
using Cysharp.Threading.Tasks;

namespace _Project.Code.Gameplay.Unit
{
    public sealed class Player
    {
        private readonly FailureResult _failureResult;
        private CancellationTokenSource _cts;

        public Player(FailureResult failureResult)
        {
            _failureResult = failureResult;
            Health = new Health.Health();
        }

        public event Action<int, int, int> TookLoot;
        public Health.Health Health { get; } 

        public void Initialize(float maxHealth, float health)
        {
            _cts = new CancellationTokenSource();
            Health.SetMaxHealth(maxHealth);
            Health.ApplyHealth(health);
            Health.Depleted += _failureResult.SetResult;

            ApplySelfDamage().Forget();
        }

        public void AddResources(int medkit, int water, int food)
        {
            Health.ApplyHealth(medkit + water + food);
            TookLoot?.Invoke(medkit, water, food);
        }
        
        private async UniTask ApplySelfDamage()
        {
            while (!_cts.IsCancellationRequested)
            {
                await UniTask.WaitForSeconds(1f);
                Health.ApplyDamage(1f);
            }
        }
    }
}