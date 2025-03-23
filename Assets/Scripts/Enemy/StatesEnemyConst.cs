using StateMachines;

namespace Enemy
{
    public abstract class StatesEnemyConst : IPlayerState
    {
        protected EnemyController EnemyController;
        protected EnemyAnimator EnemyAnimator;
        
        protected StatesEnemyConst(EnemyController enemyController, EnemyAnimator animator)
        {
            EnemyController = enemyController;
            EnemyAnimator = animator;
        }
        
        public virtual void Enter()
        {
        }

        public virtual void Execute()
        {
        }

        public virtual void Exit()
        {
        }
    }
}