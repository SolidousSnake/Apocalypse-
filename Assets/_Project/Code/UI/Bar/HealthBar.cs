using _Project.Code.Gameplay.Unit;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace _Project.Code.UI.Bar
{
    public sealed class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [Inject] private Player _player;

        private void OnEnable() => _player.Health.HealthChanged += SetAmount;
        private void OnDisable() => _player.Health.HealthChanged -= SetAmount;
        private void SetAmount(float value) => _image.fillAmount = value / 100f;
    }
}