using UnityEngine;

namespace _Project.Code.Gameplay.Mover
{
    public sealed class CarMover : MonoBehaviour
    {
        [SerializeField] private Vector2 _direction;
        [SerializeField] private float _movementSpeed;
        
        public void Move()
        {
            transform.Translate(_direction * (_movementSpeed * Time.deltaTime));
        }
    }
}