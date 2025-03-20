using Base;
using Enemy;
using Move;
using StateMachines;
using UnityEngine;

namespace Enemy
{
    public class WalkState : StatesEnemyConst
    {

        public WalkState(EnemyController enemyController, EnemyAnimator animator): base(enemyController, animator)
        {
        }

        public override void Enter()
        {
            Debug.Log("Entering ENEMY WALK");
        }

        public override void Execute()
        {
        }

        public override void Exit()
        {
            
        }
    }
}