using UnityEngine;

namespace Weapons.ScriptableObjects
{
    [CreateAssetMenu(fileName = "SkillData", menuName = "Skills/SpellSkillData")]
    public class SpellSkillData : SkillData
    {
        public GameObject _projectilePrefab;
    }
}