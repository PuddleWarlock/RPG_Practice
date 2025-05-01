using System.Collections;
using Controllers.Entities;
using UnityEngine;
using UnityEngine.AI;
using Weapons.Base;

namespace Enemy.States
{
    public class BossSuperAttackState : StatesBossConst
    {
        private SkillsController _skillsController;
        public BossSuperAttackState(BossController bossController, BossAnimator animator, NavMeshAgent navMeshAgent) : base(bossController, animator, navMeshAgent)
        {
            // _skillsController = skillsController;
        }

        public override void Enter()
        {
            // _skillsController.Skills[SkillType.Fist].Cast();
            // EnemyAnimator.StartCoroutine(SwordColliderSwitch());
            Debug.Log("Entering BOSS SUPER ATTACK");
            BossAnimator.DoSuperAttack();
            NavMeshAgent.isStopped = true;
        }

        public override void Execute()
        {
            BossController.RotateToPlayer();
        }

        public override void Exit()
        {
            
        }
        
        // private IEnumerator SwordColliderSwitch()
        // {
            // yield return new WaitUntil(()=>EnemyAnimator.CheckAnimationState(0, 0.3f, "attackTest"));
            // EnemyController.SwordCollider.enabled = true;
            // yield return new WaitUntil(()=>EnemyAnimator.CheckAnimationState(0, 0.53f, "attackTest"));
            // EnemyController.SwordCollider.enabled = false;
        // }
    }
}