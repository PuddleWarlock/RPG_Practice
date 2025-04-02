using System;

namespace Weapons
{
    [Serializable] public struct Damage
    {
        public float Value;
        public DamageType Type;


        public Damage(DamageType type, float value)
        {
            Type = type;
            Value = value;
        }
    }
    
    [Serializable] public enum DamageType
    {
        Physic,
        Magic
    }
}