using _Project.Code.Config;
using _Project.Code.Gameplay.Unit;
using _Project.Code.Gameplay.Spawner;
using _Project.Code.Gameplay.Stopwatch;
using Cysharp.Threading.Tasks;
using VContainer;
using VContainer.Unity;

namespace _Project.Code.Core.Bootstrap
{
    public sealed class LevelBootstrapper : IInitializable
    {
        [Inject] private readonly LevelConfig _levelConfig;
        [Inject] private readonly Player _player;
        [Inject] private readonly Stopwatch _stopwatch;
        [Inject] private readonly CarSpawner _carSpawner;
        
        public void Initialize()
        {
            _stopwatch.Start();
            _player.Initialize(_levelConfig.MaxPlayerHealth, _levelConfig.InitialPlayerHealth);
            
            _carSpawner.Spawn().Forget();
        }
    }
}