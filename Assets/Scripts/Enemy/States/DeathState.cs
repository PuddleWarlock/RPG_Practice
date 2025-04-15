using UnityEngine;
using UnityEngine.AI;

namespace Enemy.States

{
    public class DeathState : StatesEnemyConst
    {   
        private readonly Canvas hpCanvas;
        public DeathState(EnemyController enemyController, EnemyAnimator animator, NavMeshAgent navMeshAgent, Canvas hpCanvas) : base(enemyController, animator, navMeshAgent)
        {
            this.hpCanvas = hpCanvas;
        }

        public override void Enter()
        {   
            hpCanvas.enabled = false;
            EnemyController.GetComponent<Collider>().enabled = false;
            EnemyAnimator.DeathEvent();
            NavMeshAgent.ResetPath();
            NavMeshAgent.isStopped = true;
            NavMeshAgent.angularSpeed = 0f;
        }

        public override void Execute()
        {
        }

        public override void Exit()
        {
        }
    }
}