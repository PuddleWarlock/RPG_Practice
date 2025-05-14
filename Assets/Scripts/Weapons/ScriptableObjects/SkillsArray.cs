using UnityEngine;

namespace Weapons.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Skills/SkillsArray", fileName = "SkillsArray")]
    public class SkillsArray : ScriptableObject
    {
        public SkillEntry[] skillEntries;
    }
}