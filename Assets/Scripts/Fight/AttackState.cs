using Base;
using Move;
using StateMachines;
using UnityEngine;
using Weapons;
using Weapons.Base;
using Weapons.Colliding;

namespace Fight
{
    public class AttackState : FightPlayerState
    {

        public AttackState(FightController fightController, SkillsController skillsController, PlayerAnimator animator) : base(fightController, skillsController, animator)
        {
        }

        public override void Enter()
        {
            FightController.Sword.ClearEnemiesList();
            FightController.SwordCollider.enabled = true;
            Debug.Log("Entering Melee");
            PlayerAnimator.DoAttack();
            //CooldownSystem.MeleeReady = false;
            SkillsController.Skills[SkillType.Melee].Cast();

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