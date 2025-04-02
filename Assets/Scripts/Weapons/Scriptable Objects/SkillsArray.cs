using UnityEngine;
using UnityEngine.Serialization;

namespace Weapons.Scriptable_Objects
{
    [CreateAssetMenu(menuName = "Skills/SkillsArray", fileName = "SkillsArray")]
    public class SkillsArray : ScriptableObject
    {
        public SkillEntry[] skillEntries;
    }
}