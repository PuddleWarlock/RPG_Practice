using Controllers.Entities.HealthController.Interfaces;
using UnityEngine;
using Weapons.Base;
using Weapons.ScriptableObjects;

namespace Weapons.Skills
{
    public class PunchSkill : Skill
    {
        public PunchSkill(SkillData skillData, Transform a, Transform b, GameObject sword, IDamageable self) :
            base(skillData)
        {

        }
    }
}