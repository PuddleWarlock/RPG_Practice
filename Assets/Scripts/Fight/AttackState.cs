using System.Collections;
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
            Debug.Log("Entering Melee");
            PlayerAnimator.StartCoroutine(SwordColliderSwitch());
            PlayerAnimator.DoAttack();
            SkillsController.Skills[SkillType.Melee].Cast();

        }

        public override void Execute()
        {
        }

        public override void Exit()
        {
            Debug.Log("Exiting Melee");
        }

        private IEnumerator SwordColliderSwitch()
        {
            yield return new WaitUntil(()=>PlayerAnimator.CheckAnimationState((int)LayerNames.Fight, 0.4f, "Attack"));
            FightController.SwordCollider.enabled = true;
            yield return new WaitUntil(()=>PlayerAnimator.CheckAnimationState((int)LayerNames.Fight, 0.53f, "Attack"));
            FightController.SwordCollider.enabled = false;
        }
    }
}