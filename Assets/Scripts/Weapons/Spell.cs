using Fight;
using UnityEngine;

namespace Weapons
{
    public class Spell : MonoBehaviour, IWeapon
    {
        private Damage _damage;

        private void Start()
        {
            _damage = new Damage(DamageType.Magic, 20f);
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
    }
}