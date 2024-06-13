using System;
using DG.Tweening;
using UnityEngine;

namespace _Project.Code.Gameplay.Unit
{
    [RequireComponent(typeof(AudioSource))]
    public sealed class Circle : MonoBehaviour
    {
        [SerializeField] private Vector3 _targetScale;
        [SerializeField] private AudioSource _source;

        public event Action Popped;
        public event Action Shrank;

        public void Initialize(float duration)
        {
            Shrink(duration);
        }

        private void Shrink(float duration)
        {
            transform.DOScale(_targetScale, duration).SetLink(gameObject).OnComplete(OnShrank);
        }

        private void OnShrank()
        {
            DOTween.Kill(transform);
            Shrank?.Invoke();
        }

        private void OnMouseDown()
        {
            _source.Play();
            DOTween.Kill(transform);
            Popped?.Invoke();
            Destroy(gameObject);
        }
    }
}