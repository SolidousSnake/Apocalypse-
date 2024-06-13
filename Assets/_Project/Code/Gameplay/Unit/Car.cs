using _Project.Code.Config;
using _Project.Code.Gameplay.Mover;
using _Project.Code.Gameplay.Unit.Behaviour;
using UnityEngine;
using VContainer;

namespace _Project.Code.Gameplay.Unit
{
    [RequireComponent(typeof(CarMover))]
    public abstract class Car : MonoBehaviour
    {
        [SerializeField] private CarConfig _carConfig;
        [SerializeField] private CarMover _carMover;
        [SerializeField] protected BeingAttackedBehaviour _beingAttackedBehaviour;

        [Inject] private Player _player;
        
        protected Health.Health _health;
        
        private void OnValidate()
        {
            _carMover ??= GetComponent<CarMover>();
            _beingAttackedBehaviour ??= GetComponent<BeingAttackedBehaviour>();
        }

        private void Start()
        {
            _health = new Health.Health(_carConfig.Health);
            _health.Depleted += GiveLoot;
            InitializeBehaviour();
        }

        protected abstract void InitializeBehaviour();
        private void Update() => _carMover.Move();
        private void OnMouseDown() => _beingAttackedBehaviour.OnClick();
        private void OnDestroy() => _health.Depleted -= GiveLoot;

        private void GiveLoot()
        {
            int medkitValue = Random.Range(_carConfig.MinResources, _carConfig.MaxResources);
            int waterValue = Random.Range(_carConfig.MinResources, _carConfig.MaxResources);
            int foodValue = Random.Range(_carConfig.MinResources, _carConfig.MaxResources);

            _player.AddResources(medkitValue, waterValue, foodValue);
        }
    }
}