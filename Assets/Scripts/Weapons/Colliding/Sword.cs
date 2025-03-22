using System;
using Fight;
using UnityEngine;

namespace Weapons
{
    public class Sword : MonoBehaviour, IDamaging
    {
        private Damage _damage;

        private void Start()
        {
            _damage = new Damage(DamageType.Physic, 10f);
        }

        public void DoDamage(IDamageable damageable)
        {
            damageable.TakeDamage(_damage);
        }

        private void OnTriggerEnter(Collider other)
        {
            IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
            if (damageable != null)
            {
                DoDamage(damageable);
            }
        }
    }
}