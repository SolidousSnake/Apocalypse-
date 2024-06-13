using System;
using UnityEngine;

namespace _Project.Code.Gameplay.Unit.Behaviour
{
    public class BeingAttackedBehaviour : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

        public event Action BeingAttacked; 
        
        private void OnValidate()
        {
            _audioSource ??= GetComponent<AudioSource>();
        }

        public virtual void OnClick()
        {
            _audioSource.Play();
            BeingAttacked?.Invoke();
        }
    }
}