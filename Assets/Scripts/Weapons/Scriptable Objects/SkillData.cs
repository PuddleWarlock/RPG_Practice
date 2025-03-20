using System;
using UnityEngine;
using Weapons.Base;

namespace Weapons
{
    [CreateAssetMenu(fileName = "SkillData", menuName = "Skills/SkillData")]
    public class SkillData : ScriptableObject
    {
        public SkillType skillType;
        public string skillName;
        public float cooldownTime;
        public Sprite sprite;
    }
}