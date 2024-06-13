using System;
using _Project.Code.Gameplay.Stopwatch;
using TMPro;
using UnityEngine;
using VContainer;

namespace _Project.Code.UI.Label
{
    public sealed class StopwatchLabel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _label;
        [SerializeField] private string _format = "m\\:ss";

        [Inject] private Stopwatch _stopwatch;
        
        private void SetValue(TimeSpan value) => _label.text = value.ToString(@_format);
        public void OnEnable() => _stopwatch.Ticked += SetValue;
        public void OnDisable() => _stopwatch.Ticked -= SetValue;
    }
}