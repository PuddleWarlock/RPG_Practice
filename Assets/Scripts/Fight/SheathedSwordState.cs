using System.Collections;
using Base;
using StateMachines;
using UnityEngine;

namespace Fight
{
    public class SheathedSwordState : FightPlayerState
    {
        public SheathedSwordState(FightController fightController, SkillsController skillsController, PlayerAnimator animator) : base(fightController, skillsController, animator)
        {
        }
        
        public override void Enter()
        {
            Debug.Log("Entering Sheathed Sword");
            if (FightController.IsSheathed) return;
            PlayerAnimator.DoSheath();
            PlayerAnimator.StartCoroutine(Sheath());
        }

        public override void Exit()
        {
            Debug.Log("Exiting Sheathed Sword");
            //PlayerAnimator.DoWithdraw();
        }
        
        private IEnumerator Sheath()
        {
            yield return new WaitUntil(()=>PlayerAnimator.CheckAnimationState((int)LayerNames.Fight, 0.8f, "Sheath"));
            FightController.swordGameObject.SetActive(false);
            FightController.hipSwordGameObject.SetActive(true);
            yield return new WaitUntil(()=>PlayerAnimator.CheckAnimationState((int)LayerNames.Fight, 0.99f, "Sheath"));
            FightController.IsSheathed = true;
        }
    }
}