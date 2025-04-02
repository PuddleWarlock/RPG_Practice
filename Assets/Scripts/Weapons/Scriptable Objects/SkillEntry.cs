using System;
using UnityEditor;
using UnityEngine;
using Weapons.Base;

namespace Weapons.Scriptable_Objects
{
    [Serializable]
    public class SkillEntry
    {
        [SerializeField] private MonoScript _skillClass;
        [SerializeField] private SkillData _skillData;
        
        public SkillData SkillData => _skillData;
        public Type SkillClass
        {
            get
            {
                if (_skillClass != null && typeof(ISkill).IsAssignableFrom(_skillClass.GetClass()))
                {
                    return _skillClass.GetClass();
                }
                throw new ArgumentException("Invalid skill script");
            }
        }
    }
}