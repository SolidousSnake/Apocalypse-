using System.Linq;
using _Project.Code.Config;
using _Project.Code.Core.Bootstrap;
using _Project.Code.Core.Util;
using _Project.Code.Gameplay.GameResult;
using _Project.Code.Gameplay.Spawner;
using _Project.Code.Gameplay.Stopwatch;
using _Project.Code.Gameplay.Unit;
using _Project.Code.Services.MiniGameService;
using _Project.Code.Services.SoundService;
using _Project.Code.UI.Button;
using _Project.Code.UI.Label;
using _Project.Code.UI.Screen;
using UnityEngine;
using UnityEngine.Audio;
using VContainer;
using VContainer.Unity;

namespace _Project.Code.Core.Scope
{
    public sealed class LevelScope : LifetimeScope
    {
        [Header("General")]
        [SerializeField] private CarSpawner _carSpawner;
        [SerializeField] private CircleSpawner _circleSpawner;

        [Header("Config")] 
        [SerializeField] private LevelConfig _levelConfig;
        [SerializeField] private CircleMiniGameConfig _circleSpawnerConfig;

        [Header("UI")] 
        [SerializeField] private FailureResultView _gameOverScreen;
        [SerializeField] private CircleSpawnerLabel _circleSpawnerLabel;
        [SerializeField] private LootLabel _lootLabel;
        [SerializeField] private ButtonsParent _buttonsParent;
        [SerializeField] private YouWasRobbedLabel _youWasRobbedLabel;
        
        [Header("Sound")]
        [SerializeField] private AudioSource _musicSource;
        [SerializeField] private AudioMixerGroup _audioMixerGroup;

        protected override void Configure(IContainerBuilder builder)
        {
            FindAutoInjectObject();
            BindConfig(builder);
            BindServices(builder);
            BindSpawner(builder);
            BindUI(builder);
           
            builder.Register<Player>(Lifetime.Singleton);
            builder.Register<Stopwatch>(Lifetime.Singleton);
            builder.Register<FailureResult>(Lifetime.Singleton);
            builder.RegisterEntryPoint<LevelBootstrapper>();
        }

        private void BindUI(IContainerBuilder builder)
        {
            builder.RegisterInstance(_gameOverScreen);
            builder.RegisterInstance(_circleSpawnerLabel);
            builder.RegisterInstance(_lootLabel);
            builder.RegisterInstance(_buttonsParent);
            builder.RegisterInstance(_youWasRobbedLabel);
        }

        private void BindSpawner(IContainerBuilder builder)
        {
            builder.RegisterComponent(_carSpawner);
            builder.RegisterComponent(_circleSpawner);
        }

        private void BindConfig(IContainerBuilder builder)
        {
            builder.RegisterInstance(_levelConfig);
            builder.RegisterInstance(_circleSpawnerConfig);
        }

        private void BindServices(IContainerBuilder builder)
        {
            builder.Register<MiniGameService>(Lifetime.Singleton);
            builder.Register<SoundService>(Lifetime.Singleton).WithParameter(_audioMixerGroup)
                .WithParameter(_musicSource);
        }

        private void FindAutoInjectObject()
        {
            var objects = Object.FindObjectsOfType<AutoInject>(true)
                .Select(x => x.gameObject).ToList();
            autoInjectGameObjects = objects;
        }
    }
}