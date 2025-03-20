using Base;
using Move;
using StateMachines;
using UnityEngine;
using Weapons;
using Weapons.Base;

namespace Fight
{
    public class SpellState : FightPlayerState
    {
        private bool _isCasted;
        public SpellState(FightController fightController, SkillsController skillsController, PlayerAnimator animator) : base(fightController, skillsController, animator)
        {
        }

        public override void Enter()
        {
            _isCasted = false;
            Debug.Log("Entering Spell");
            PlayerAnimator.DoSpell();
            FightController.SwordGameObject.SetActive(false);

        }

        public override void Execute()
        {
            if (PlayerAnimator._animator.GetCurrentAnimatorStateInfo(1).IsName("Spell") && 
                PlayerAnimator._animator.GetCurrentAnimatorStateInfo(1).normalizedTime >= 0.425f && !_isCasted)
            {
                SkillsController.Skills[SkillType.Fireball].Cast();
                _isCasted = true;
            }
        }

        public override void Exit()
        {
            FightController.SwordGameObject.SetActive(true);
            Debug.Log("Exiting Spell");
        }
    }
}