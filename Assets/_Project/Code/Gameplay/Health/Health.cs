using System;

namespace _Project.Code.Gameplay.Health
{
    public sealed class Health
    {
        private float _maxHealth;
        private bool _depleted;
        private float _health;

        public Health(float health = 0f)
        {
            _maxHealth = _health = health;
        }
        
        public event Action Depleted;
        public event Action<float> HealthChanged;
        
        public void ApplyDamage(float damage)
        {
            if(_depleted)
                return;
            
            _health -= damage;
            HealthChanged?.Invoke(_health);
            if (_health <= 0)
            {
                _health = 0;
                _depleted = true;
                Depleted?.Invoke();
            }
        }

        public void ApplyHealth(float health)
        {
            if (health < 0)
                throw new Exception("health must be positive");
            
            _health += health;
            if (_health > _maxHealth)
                _health = _maxHealth;
            
            HealthChanged?.Invoke(_health);
        }

        public void SetMaxHealth(float maxHealth)
        {
            if (maxHealth < 0)
                throw new Exception("maxhealth must be positive");
            
            _maxHealth = maxHealth;
            
            if (_health > maxHealth)
                _health = maxHealth;
        }

        public float GetHealth() => _health;
    }
}