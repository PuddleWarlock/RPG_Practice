using Controllers.Scenes;
using Controllers.UI;
using UnityEngine;
using Views.Gameplay;

namespace StateMachines.SceneStates
{
    public class PauseState : GlobalState
    {
        private GameplayManager _gameplayManager;
        private ViewManager _viewManager;


        public PauseState(GameplayManager gameplayManager, ViewManager viewManager) : base(gameplayManager, viewManager)
        {
            _gameplayManager = gameplayManager;
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