using Base;
using Move;
using StateMachines;
using UnityEngine;

namespace Fight
{
    public class SpellState : FightPlayerState
    {
        private bool _isCasted;
        public SpellState(FightController fightController, CooldownSystem cooldownSystem, PlayerAnimator animator) : base(fightController, cooldownSystem, animator)
        {
        }

        public override void Enter()
        {
            _isCasted = false;
            Debug.Log("Entering Spell");
            PlayerAnimator.DoSpell();
            CooldownSystem.SpellReady = false;
            FightController.SwordGameObject.SetActive(false);

        }

        public override void Execute()
        {
            if (PlayerAnimator._animator.GetCurrentAnimatorStateInfo(1).IsName("Spell") && 
                PlayerAnimator._animator.GetCurrentAnimatorStateInfo(1).normalizedTime >= 0.425f && !_isCasted)
            {
                FightController.CastSpell();
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