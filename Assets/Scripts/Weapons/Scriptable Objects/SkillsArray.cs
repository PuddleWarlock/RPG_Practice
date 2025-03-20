using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Weapons
{
    [CreateAssetMenu(menuName = "Skills/SkillsArray", fileName = "SkillsArray")]
    public class SkillsArray : ScriptableObject
    {
        public SkillData[] skillData;
    }
}