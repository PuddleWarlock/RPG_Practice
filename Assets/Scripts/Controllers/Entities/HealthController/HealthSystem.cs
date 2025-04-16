using Controllers.Entities.HealthController.Interfaces;
using UnityEngine;
using UnityEngine.Events;
using Weapons;
using Weapons.Base;

namespace Controllers.Entities.HealthController
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
        [SerializeField] private float _health;

        public void Init(float healthMultiplier)
        {
            MaxHealth *= healthMultiplier;
            SetHealthToMax();
        }

        private void SetHealthToMax()
        {
            Health = MaxHealth;
        }
        
        public void SetHealth(float health)
        {
            Health = health;
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
