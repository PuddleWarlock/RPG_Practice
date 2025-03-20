using Base;
using Enemy;
using Move;
using StateMachines;
using UnityEngine;

namespace Enemy
{
    public class DeathState : StatesEnemyConst
    {

        public DeathState(EnemyController enemyController, EnemyAnimator animator): base(enemyController, animator)
        {
        }

        public override void Enter()
        {   
            EnemyAnimator.DeathEvent();
            Debug.Log("Entering ENEMY DEATH");
        }

        public override void Execute()
        {
        }

        public override void Exit()
        {
        }
    }
}