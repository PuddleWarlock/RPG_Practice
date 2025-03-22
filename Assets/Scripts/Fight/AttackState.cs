using Base;
using Move;
using StateMachines;
using UnityEngine;

namespace Fight
{
    public class AttackState : FightPlayerState
    {

        public AttackState(FightController fightController, CooldownSystem cooldownSystem, PlayerAnimator animator) : base(fightController, cooldownSystem, animator)
        {
        }

        public override void Enter()
        {
            FightController.SwordCollider.enabled = true;
            Debug.Log("Entering Melee");
            PlayerAnimator.DoAttack();
            CooldownSystem.MeleeReady = false;

        }

        public override void Execute()
        {
        }

        public override void Exit()
        {
            FightController.SwordCollider.enabled = false;
            Debug.Log("Exiting Melee");
        }
    }
}