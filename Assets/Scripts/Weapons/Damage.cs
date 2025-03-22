namespace Weapons
{
    public struct Damage
    {
        public float Value { get;}
        public DamageType Type { get; }


        public Damage(DamageType type, float value)
        {
            Type = type;
            Value = value;
        }
    }

    public enum DamageType
    {
        Physic,
        Magic
    }
}