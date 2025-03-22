using System.Collections.Generic;
using UnityEngine;
using Weapons;
using Weapons.Base;

namespace Fight
{
    public class SkillsController : MonoBehaviour
    {
        [SerializeField] private SkillsArray _skillsArray;
        [SerializeField] private GameObject _projectilePrefab;
        [SerializeField] private Transform _castPoint;
        [SerializeField] private Transform _caster;
        public Dictionary<SkillType,Skill> Skills = new ();

        public void Awake()
        {
            var spell = new SpellSkill(_skillsArray.skillData[1],_projectilePrefab,_castPoint,_caster);
            var melee = new MeleeSkill(_skillsArray.skillData[0]);
            Skills.Add(spell.SkillType,spell);
            Skills.Add(melee.SkillType,melee);
        }

        private void Update()
        {
            foreach (var skill in Skills)
            {
                skill.Value.Tick();
            }
        }
    }
}