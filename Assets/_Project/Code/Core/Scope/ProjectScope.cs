using _Project.Code.Core.SceneManagement;
using _Project.Code.Services.AdsService;
using _Project.Code.Services.SaveLoadService;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Project.Code.Core.Scope
{
    public sealed class ProjectScope : LifetimeScope
    {
        [SerializeField] private LoadingScreen _loadingScreen;
        
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterServices(builder);

            builder.RegisterComponentInNewPrefab(_loadingScreen, Lifetime.Scoped);
        }

        private void RegisterServices(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<JsonSaveLoadService>();
            builder.RegisterEntryPoint<MobileAdsService>();
            builder.RegisterEntryPoint<SceneLoader>();
        }
    }
}