using UnityEngine;
using UnityEngine.Events;
using Weapons;

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
                onHealthChanged?.Invoke(_health,MaxHealth);
            }
        }

        public float MaxHealth { get; private set; } = 100f;
        
        public UnityEvent<float,float> onHealthChanged;
        public UnityEvent onDeath;
        private float _health;

        private void Start()
        {
            Health = MaxHealth;
        }

        public void TakeDamage(Damage damage)
        {   
            Health -= damage.Value;
            if (Health - damage.Value <= 0)
            {
                Health = 0;
                onDeath?.Invoke();
            }
        }
 
    }
}
