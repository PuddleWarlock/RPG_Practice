using System.Collections.Generic;
using Fight;
using UnityEngine;

namespace Weapons.Colliding
{
    public class Sword : MonoBehaviour, IDamaging
    {
        private Damage _damage;
        private IDamageable _self;
        private List<IDamageable> _enemies = new();

        public void Init(IDamageable self, Damage damage)
        {
            _self = self;
            _damage = damage;
        }

        public void DoDamage(IDamageable damageable)
        {
            damageable.TakeDamage(_damage);
        }

        private void OnTriggerEnter(Collider other)
        {
            IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
            if (damageable == null) return;
            if (damageable == _self) return;
            if (_enemies.Contains(damageable)) return;
            DoDamage(damageable);
            _enemies.Add(damageable);
        }

        public void ClearEnemiesList()
        {
            _enemies.Clear();
        }
    }
}