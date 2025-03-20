using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
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
        private float _health;

        private void Start()
        {
            Health = MaxHealth;
        }

        public void TakeDamage(Damage damage)
        {   
            Health -= damage.Value;
            // if (Health <= 0)
            // {  
            //     Health = MaxHealth;               
            // }
        }
 
    }
}
