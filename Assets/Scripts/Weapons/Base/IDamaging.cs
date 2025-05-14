using Controllers.Entities.HealthController.Interfaces;

namespace Weapons.Base
{
    public interface IDamaging
    {
        void DoDamage(IDamageable damageable);
    }
}