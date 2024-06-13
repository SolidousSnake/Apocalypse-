using _Project.Code.Gameplay.Unit;
using DG.Tweening;
using TMPro;
using UnityEngine;
using VContainer;

namespace _Project.Code.UI.Label
{
    [RequireComponent(typeof(AudioSource))]
    public sealed class LootLabel : MonoBehaviour
    {
        [Header("appearance")] 
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Vector2 _originalPosition;
        [SerializeField] private Vector2 _targetPosition;
        [SerializeField] private float _appearDuration;
        [SerializeField] private float _disappearDuration;
        [SerializeField] private float _disappearDelay;
        [SerializeField] private Ease _ease;
        [SerializeField] private AudioSource _audioSource;
        
        [Header("UI")] 
        [SerializeField] private TextMeshProUGUI _medkitLabel;
        [SerializeField] private TextMeshProUGUI _waterLabel;
        [SerializeField] private TextMeshProUGUI _foodLabel;

        [Inject] private Player _player;

        private void OnValidate()
        {
            _rectTransform ??= GetComponent<RectTransform>();
            _audioSource ??= GetComponent<AudioSource>();
        }

        private void OnEnable() => _player.TookLoot += SetAmount;
        private void OnDisable() => _player.TookLoot += SetAmount;

        private void Show()
        {
            _audioSource.Play();
            var sequence = DOTween.Sequence();
            sequence
                .Append(_rectTransform.DOAnchorPos(_targetPosition, _appearDuration))
                    .SetEase(_ease)
                .AppendInterval(_disappearDelay)
                .Append(_rectTransform.DOAnchorPos(_originalPosition, _disappearDuration));
        }

        private void SetAmount(int medkit, int water, int food)
        {
            Show();
            _medkitLabel.text = $"{medkit}";
            _waterLabel.text = $"{water}";
            _foodLabel.text = $"{food}";
        }
    }
}