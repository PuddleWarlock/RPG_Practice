using Base;
using StateMachines;

namespace Move
{
    public abstract class BasePlayerState : IPlayerState
    {
        protected PlayerController PlayerController;
        
        protected BasePlayerState(PlayerController playerController)
        {
            PlayerController = playerController;
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