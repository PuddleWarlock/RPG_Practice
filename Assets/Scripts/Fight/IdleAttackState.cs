﻿using System.Collections;
using Base;
using Move;
using StateMachines;
using UnityEngine;

namespace Fight
{
    public class IdleAttackState : FightPlayerState
    {
        public IdleAttackState(FightController fightController, SkillsController skillsController, PlayerAnimator animator) : base(fightController, skillsController, animator)
        {
        }

        public override void Enter()
        {
            Debug.Log("Entering IdleAttack");
            if(!FightController.IsSheathed) return;
            PlayerAnimator.DoWithdraw();
            FightController.IsSheathed = false;
            PlayerAnimator.StartCoroutine(Withdraw());
        }

        public override void Execute()
        {
        }

        public override void Exit()
        {
            Debug.Log("Exiting IdleAttack");
        }
        
        private IEnumerator Withdraw()
        {
            yield return new WaitUntil(()=>PlayerAnimator.CheckAnimationState((int)LayerNames.Fight, 0.374f, "Withdraw"));
            FightController.swordGameObject.SetActive(true);
            FightController.hipSwordGameObject.SetActive(false);
        }
    }
}