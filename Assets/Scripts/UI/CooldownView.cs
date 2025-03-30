using Fight;
using UnityEngine;
using UnityEngine.UI;
using Weapons.Base;

namespace UI
{
    public class CooldownView : MonoBehaviour
    {
        private SkillsController _skillsController;
        [SerializeField] private Image MeleeMask;
        [SerializeField] private Image MeleeStatus;
        [SerializeField] private Image SpellMask;
        [SerializeField] private Image SpellStatus;

        private void Update()
        {
            MeleeStatus.fillAmount = _skillsController.Skills[SkillType.Melee].GetReadyPercent();
            SpellStatus.fillAmount = _skillsController.Skills[SkillType.Fireball].GetReadyPercent();
            MeleeMask.enabled = MeleeStatus.fillAmount > 0;
            SpellMask.enabled = SpellStatus.fillAmount > 0;
        }

        public void Init(SkillsController skillsController)
        {
            _skillsController = skillsController;
        }
    }
}