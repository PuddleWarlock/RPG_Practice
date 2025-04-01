using UI;
using UnityEngine;

namespace GlobalStateMachine
{
    public class GameOverState : GlobalState
    {
        private GameManager _gameManager;
        private ViewManager _viewManager;
        public GameOverState(GameManager gameManager, ViewManager viewManager) : base(gameManager, viewManager)
        {
            _gameManager = gameManager;
            _viewManager = viewManager;
        }

        public override void Enter()
        {
            Debug.Log("Entering GAME OVER");
            Time.timeScale = 0f;
            _viewManager.GetView<EndGameView>().Show();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        public override void Execute()
        {
            // Logic for the game over state can be added here
        }

        public override void Exit()
        {
            Debug.Log("Exiting GAME OVER");
        }
    }
}