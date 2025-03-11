using UnityEngine;
using UnityEngine.Events;

namespace Fight
{
    public class HealthSystem : MonoBehaviour, IDamageable
    {
        public float Health
        {
            get => _health;
            set
            {
                _health = value;
                OnHealthChanged?.Invoke(_health);
            }
        }

        public UnityEvent<float> OnHealthChanged;
        private float _health;
    
        public void TakeDamage(float damage)
        {
            _health -= damage;
        }
    }
}
