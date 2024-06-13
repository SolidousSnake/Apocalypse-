using _Project.Code.Core.SceneManagement;
using _Project.Code.Core.Util;
using _Project.Code.Services.AdsService;
using UnityEngine;
using VContainer;

namespace _Project.Code.Core.Bootstrap
{
    public sealed class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private int _targetFrameRate;
        
        [Inject] private ISceneLoader _sceneLoader;
        [Inject] private IAdsService _adsService;
        [Inject] private LoadingScreen _loadingScreen;
        
        private void Start()
        {
            Application.targetFrameRate = _targetFrameRate;
            _adsService.Initialize();
           _sceneLoader.Load(Constants.Scene.Menu);
        }
    }
}