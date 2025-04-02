using Fight;
using UnityEngine;
using Weapons.Base;
using Weapons.Colliding;
using Weapons.Scriptable_Objects;

namespace Weapons
{
    public class MeleeSkill : Skill
    {
        private Sword _sword;
        public MeleeSkill(SkillData skillData, Transform a, Transform b, GameObject sword, IDamageable self) : base(skillData)
        {
            _sword = sword.AddComponent<Sword>();
            _sword.Init(self,skillData.damage);
        }

        public override void Cast()
        {
            base.Cast();
            _sword.ClearEnemiesList();
        }
    }
}