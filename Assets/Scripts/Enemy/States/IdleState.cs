﻿using UnityEngine;
using UnityEngine.AI;

namespace Enemy.States
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