using UnityEngine;
using Weapons.Base;
using Weapons.Scriptable_Objects;

namespace Weapons
{
    public class MeleeSkill : Skill
    {
        public MeleeSkill(SkillData skillData, Transform a, Transform b) : base(skillData)
        {
        }
    }
}