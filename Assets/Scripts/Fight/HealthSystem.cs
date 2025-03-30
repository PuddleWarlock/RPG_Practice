using UI;
using UnityEngine;
using UnityEngine.Events;
using Weapons;

namespace Fight
{
    public class HealthSystem : MonoBehaviour, IDamageable, IHealthChange
    {
        
        public float Health
        {
            get => _health;
            set
            {
                _health = value;
                onHealthChanged?.Invoke(_health,MaxHealth);
            }
        }

        public float MaxHealth { get; private set; } = 100f;

        public UnityEvent<float, float> onHealthChanged { get; } = new();
        public UnityEvent onDeath;
        private float _health;

        private void Start()
        {
            Health = MaxHealth;
        }

        public void TakeDamage(Damage damage)
        {   
            if (Health - damage.Value <= 0)
            {
                Health = 0;
                onDeath?.Invoke();
            }
            else
            {
                Health -= damage.Value;
            }
        }
 
    }
}
