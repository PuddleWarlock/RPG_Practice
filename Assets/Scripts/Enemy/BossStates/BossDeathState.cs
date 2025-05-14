using System.Collections;
using Controllers.Entities;
using UnityEngine;
using UnityEngine.AI;
using Weapons.Base;

namespace Enemy.States
{
    public class BossDeathState : StatesBossConst
    {
        private SkillsController _skillsController;
        private readonly Canvas hpCanvas;
 
        public BossDeathState(BossController bossController, BossAnimator animator, NavMeshAgent navMeshAgent, Canvas hpCanvas) : base(bossController, animator, navMeshAgent)
        {
            this.hpCanvas = hpCanvas;
        }

        public override void Enter()
        {
            
            hpCanvas.enabled = false;
            BossController.GetComponent<Collider>().enabled = false;
            BossAnimator.DeathEvent();
            NavMeshAgent.ResetPath();
            NavMeshAgent.isStopped = true;
            NavMeshAgent.angularSpeed = 0f;
            BossController.StartCoroutine(Destroy());
        }

        public override void Execute()
        {
            BossController.RotateToPlayer();
        }

        public override void Exit()
        {
            
        }
        
        public IEnumerator Destroy()
        {
            yield return new WaitUntil(()=>BossAnimator.CheckAnimationState(0, 0.99f, "BossDeath"));
            Object.Destroy(BossController.gameObject);
        }
    }
}