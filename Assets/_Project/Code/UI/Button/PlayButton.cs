using _Project.Code.Core.SceneManagement;
using _Project.Code.Core.Util;
using UnityEngine;
using VContainer;

namespace _Project.Code.UI.Button
{
    [RequireComponent(typeof(UnityEngine.UI.Button))]
    public sealed class PlayButton : MonoBehaviour
    {
        [SerializeField] private UnityEngine.UI.Button _button;
        [Inject] private readonly ISceneLoader _sceneLoader;
        [Inject] private readonly LoadingScreen _loadingScreen;
        
        private void Start() => _button.onClick.AddListener(LoadLevel);

        private void LoadLevel() => _sceneLoader.Load(Constants.Scene.Level);
    }
}