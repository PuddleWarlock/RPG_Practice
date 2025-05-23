﻿using System.Collections.Generic;
using Controllers.Entities.HealthController.Interfaces;
using UnityEngine;
using Weapons.Base;

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
            print($"Hit made by {_self}");
            IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
            if (damageable == null) return;
            if (damageable == _self) return;
            print($"Hit Happened on {damageable}");
            if (_enemies.Contains(damageable)) return;
            print("Does Damage");
            DoDamage(damageable);
            _enemies.Add(damageable);
        }

        public void ClearEnemiesList()
        {
            _enemies.Clear();
        }
    }
}