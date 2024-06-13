using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Code.UI.Label
{
    public sealed class CircleSpawnerLabel : MonoBehaviour
    {
        [SerializeField] private List<Image> _circles;

        [SerializeField] private Sprite _stockSprite;
        [SerializeField] private Sprite _missedSprite;
        [SerializeField] private Sprite _poppedSprite;


        public void ChangeColor(int index, bool isPopped) => _circles[index].sprite = isPopped ? _poppedSprite : _missedSprite;

        public void Reset()
        {
            for (int i = 0; i < _circles.Count; i++)
            {
                _circles[i].sprite = _stockSprite;
            }
        }
    }
}