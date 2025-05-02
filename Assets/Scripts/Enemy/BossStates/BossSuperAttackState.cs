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
        public BossSuperAttackState(BossController bossController, BossAnimator animator, NavMeshAgent navMeshAgent, SkillsController skillsController) : base(bossController, animator, navMeshAgent)
        {
            _skillsController = skillsController;
        }

        public override void Enter()
        {
            _skillsController.Skills[SkillType.Heavy].Cast();
            BossAnimator.DoSuperAttack();
            NavMeshAgent.isStopped = true;
            Debug.Log("Entering BOSS SUPER ATTACK");
        }

        public override void Execute()
        {
            BossController.RotateToPlayer();
        }

        public override void Exit()
        {
            Debug.Log("exit");
        }
    }
}