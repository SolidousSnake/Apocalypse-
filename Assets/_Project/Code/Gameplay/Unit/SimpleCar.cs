using UnityEngine;

namespace _Project.Code.Gameplay.Unit
{
    public sealed class SimpleCar : Car
    {
        protected override void InitializeBehaviour()
        {
            _beingAttackedBehaviour.BeingAttacked += () => _health.ApplyDamage(1f);
        }
    }
}