using Base;
using UI;
using UnityEngine;

namespace GlobalStateMachine
{
    public class PauseState : GlobalState
    {
        private GameManager _gameManager;
        private ViewManager _viewManager;


        public PauseState(GameManager gameManager, ViewManager viewManager) : base(gameManager, viewManager)
        {
            _gameManager = gameManager;
            _viewManager = viewManager;
        }

        public override void Enter()
        {
            Debug.Log("Entering PAUSE STATE");
            Time.timeScale = 0f;
            _viewManager.GetView<PauseView>().Show();
        }

        public override void Execute()
        {
            // Handle pause logic here
        }

        public override void Exit()
        {
            _viewManager.GetView<PauseView>().Hide();
            Debug.Log("Exiting PAUSE STATE");
            Time.timeScale = 1f;
        }
    }
}