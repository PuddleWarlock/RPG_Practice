using Weapons;
using Weapons.Base;

namespace Controllers.Entities.HealthController.Interfaces
{
    public interface IDamageable
    {
        void TakeDamage(Damage damage);
    }
}