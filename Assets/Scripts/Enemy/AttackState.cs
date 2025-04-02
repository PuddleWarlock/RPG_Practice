using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class AttackState : StatesEnemyConst
    {
        public AttackState(EnemyController enemyController, EnemyAnimator animator, NavMeshAgent navMeshAgent) : base(enemyController, animator, navMeshAgent)
        {
            
        }

        public override void Enter()
        {
            EnemyController.lastAttackTime = Time.time;
            EnemyController._sword.ClearEnemiesList();
            Debug.Log("Entering ENEMY ATTACK");
            EnemyAnimator.DoAttack();
            NavMeshAgent.isStopped = true;
        }

        public override void Execute()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}