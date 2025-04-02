using UI;
using UnityEngine;
using UnityEngine.Events;
using Weapons;

namespace Fight
{
    public class HealthSystem : MonoBehaviour, IDamageable, IHealthChange, IHittable, IKillable
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
        public UnityEvent<bool> onDeath { get; } = new();
        public UnityEvent onHit { get; } = new();
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
                onDeath?.Invoke(true);
            }
            else
            {
                Health -= damage.Value;
                onHit?.Invoke();
            }
        }
 
    }

    public interface IKillable
    {
        public UnityEvent<bool> onDeath { get; }
    }
}
