using Base;
using StateMachines;

namespace Move
{
    public abstract class BasePlayerState : IPlayerState
    {
        protected MovementController MovementController;
        
        protected BasePlayerState(MovementController movementController)
        {
            MovementController = movementController;
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