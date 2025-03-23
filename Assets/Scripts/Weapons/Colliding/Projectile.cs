using System.Collections;
using Fight;
using UnityEngine;

namespace Weapons.Colliding
{
    public class Projectile : MonoBehaviour, IDamaging
    {
        private Damage _damage;

        public void Init(Damage damage)
        {
            _damage = damage;
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
                Destroy(gameObject);
            }
        }

        public IEnumerator Ttl()
        {
            yield return new WaitForSeconds(10f);
            Destroy(gameObject);
        }
        
    }
}