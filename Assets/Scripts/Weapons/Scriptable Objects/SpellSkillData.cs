using UnityEngine;

namespace Weapons.Scriptable_Objects
{
    [CreateAssetMenu(fileName = "SkillData", menuName = "Skills/SpellSkillData")]
    public class SpellSkillData : SkillData
    {
        public GameObject _projectilePrefab;
    }
}