using System;
using _Project.Code.Core.SceneManagement;
using _Project.Code.Core.Util;
using TMPro;
using UnityEngine;
using VContainer;

namespace _Project.Code.UI.Screen
{
    public sealed class FailureResultView : MonoBehaviour
    {
        [SerializeField] private UnityEngine.UI.Button _restartButton;
        [SerializeField] private TextMeshProUGUI _timeLabel;
        [SerializeField] private TextMeshProUGUI _bestLabel;

        [Inject] private ISceneLoader _sceneLoader;

        public void SetAmount(TimeSpan currentTime, TimeSpan bestTime)
        {
            _timeLabel.text = "your time: " + currentTime.ToString(@"mm\:ss");
            _bestLabel.text = "your time: " + bestTime.ToString(@"mm\:ss");
        }
        
        public void Show() => gameObject.SetActive(true);
        public void Hide() => gameObject.SetActive(false);
        
        private void Start() => _restartButton.onClick.AddListener(Restart);
        private void OnDestroy() => _restartButton.onClick.RemoveAllListeners();
        private void Restart() => _sceneLoader.Load(Constants.Scene.Level);
    }
}