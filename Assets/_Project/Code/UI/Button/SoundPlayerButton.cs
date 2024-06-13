using _Project.Code.Services.SoundService;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace _Project.Code.UI.Button
{
    public sealed class SoundPlayerButton : MonoBehaviour
    {
        [SerializeField] private UnityEngine.UI.Button _button;
        [SerializeField] private Image _image;
        [SerializeField] private Sprite _regularSprite;
        [SerializeField] private Sprite _mutedSprite;
        
        [Inject] private SoundService _soundService;
        
        private void Awake() => _button.onClick.AddListener(ToggleMute);
        private void OnDestroy() => _button.onClick.RemoveAllListeners();

        private void ToggleMute()
        {
            _soundService.MuteSfx();
            UpdateButtonSprite();
        }
        
        private void UpdateButtonSprite() => _image.sprite = _soundService.IsSfxMuted ? _mutedSprite : _regularSprite;
    }
}