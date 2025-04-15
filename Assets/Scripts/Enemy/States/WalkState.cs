using UnityEngine;
using UnityEngine.AI;

namespace Enemy.States
{
    public class WalkState : StatesEnemyConst
    {
        public WalkState(EnemyController enemyController, EnemyAnimator animator, NavMeshAgent navMeshAgent) : base(enemyController, animator, navMeshAgent)
        {
        }

        public override void Enter()
        {
            Debug.Log("Entering ENEMY WALK");
            EnemyAnimator.WalkEvent();
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