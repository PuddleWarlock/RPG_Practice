using UnityEngine;
using UnityEngine.AI;
namespace Enemy
{
    public class DeathState : StatesEnemyConst
    {
        public DeathState(EnemyController enemyController, EnemyAnimator animator, NavMeshAgent navMeshAgent) : base(enemyController, animator, navMeshAgent)
        {
        }

        public override void Enter()
        {   
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