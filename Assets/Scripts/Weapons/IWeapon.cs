using Fight;

namespace Weapons
{
    public interface IWeapon
    {
        void DoDamage(IDamageable damageable);
    }
}