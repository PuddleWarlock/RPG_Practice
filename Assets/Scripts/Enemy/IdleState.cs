using UnityEngine;

namespace Enemy
{
    public class IdleState : StatesEnemyConst
    {

        public IdleState(EnemyController enemyController, EnemyAnimator animator): base(enemyController, animator)
        {
           
        }

        public override void Enter()
        {
            Debug.Log("Entering ENEMY Idle");
        }

        public override void Execute()
        {
        }

        public override void Exit()
        {
            
        }
    }
}