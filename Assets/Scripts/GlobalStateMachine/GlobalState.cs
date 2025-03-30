using Base;
using StateMachines;
using UI;

namespace GlobalStateMachine
{
    public abstract class GlobalState : IState
    {
        private GameManager _gameManager;
        private ViewManager _viewManager;

        protected GlobalState(GameManager gameManager, ViewManager viewManager)
        {
            _gameManager = gameManager;
            _viewManager = viewManager;
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