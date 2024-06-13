using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace _Project.Code.Core.SceneManagement
{
    public sealed class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private Image _loadingBar;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private int _delayFrame;
        [SerializeField] private float _fadeSpeed;
        
        [Inject] private ISceneLoader _sceneLoader;

        private void OnEnable()
        {
            _sceneLoader.Started += Show;
            _sceneLoader.Finished += Hide;
            _sceneLoader.Progressed += SetAmount;
        }

        private void OnDisable()
        {
            _sceneLoader.Started -= Show;
            _sceneLoader.Finished -= Hide;
            _sceneLoader.Progressed -= SetAmount;
        }

        private void Show()
        {
            gameObject.SetActive(true);
            _canvasGroup.alpha = 1;
        }

        private void Hide()
        {
            DoFadeIn().Forget();
        }

        private void SetAmount(float value)
        {
            _loadingBar.fillAmount = value;
        }

        private async UniTask DoFadeIn()
        {
            while (_canvasGroup.alpha > 0)
            {
                _canvasGroup.alpha -= _fadeSpeed;
                await UniTask.DelayFrame(_delayFrame);
            }

            gameObject.SetActive(false);
        }
    }
}