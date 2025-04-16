using System;
using System.Collections.Generic;
using Controllers.Entities.HealthController.Interfaces;
using UnityEngine;
using Weapons.Base;
using Weapons.ScriptableObjects;

namespace Controllers.Entities
{
    public class SkillsController : MonoBehaviour
    {
        [SerializeField] private SkillsArray _skillsArray;
        [SerializeField] private Transform _castPoint;
        [SerializeField] private Transform _caster;
        [SerializeField] public GameObject _sword;

        private Camera _camera;
        public Dictionary<SkillType,ISkill> Skills = new ();

        public void Awake()
        {
            /*var spell = new SpellSkill(_skillsArray.skillEntries[1],_castPoint, Camera.main.transform);
            var melee = new MeleeSkill(_skillsArray.skillEntries[0]);
            Skills.Add(spell.SkillType,spell);
            Skills.Add(melee.SkillType,melee);*/

            
        }

        public void Init(Camera camera)
        {
            if (camera)
            {
                _camera = camera;
                _caster = _camera.transform;
            }
            foreach (var skillEntry in _skillsArray.skillEntries)
            {
                var skill = CreateSkill(skillEntry.SkillClass, skillEntry.SkillData,_castPoint,_caster, _sword, gameObject.GetComponent<IDamageable>());
                Skills.Add(skillEntry.SkillData.skillType,skill);
            }
        }

        private ISkill CreateSkill(Type skillType, SkillData skillData, Transform castPoint, Transform caster, GameObject sword, IDamageable damageable)
        {
            if (!typeof(ISkill).IsAssignableFrom(skillType) || !typeof(Skill).IsAssignableFrom(skillType))
            {
                throw new ArgumentException($"Type {skillType.Name} must inherit from Skill and implement ISkill");
            }

            // Создаём экземпляр через Activator
            return (ISkill)Activator.CreateInstance(skillType, skillData, castPoint, caster, sword, damageable);
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