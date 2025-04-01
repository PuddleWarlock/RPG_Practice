using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class IdleState : StatesEnemyConst
    {
        public IdleState(EnemyController enemyController, EnemyAnimator animator, NavMeshAgent navMeshAgent) : base(enemyController, animator, navMeshAgent)
        {
        }

        public override void Enter()
        {
            EnemyAnimator.IdleEvent();
            Debug.Log("Entering ENEMY Idle");
            NavMeshAgent.isStopped = false;
        }

        public override void Execute()
        {
        }

        public override void Exit()
        {
            
        }
    }
}