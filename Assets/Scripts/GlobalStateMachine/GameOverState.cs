using System.Collections;
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
            _gameManager.InputManagerDisable();
            _gameManager.StartCoroutine(EndGameOver());
            Debug.Log("Entering GAME OVER");
            
        }

        public override void Execute()
        {
            // Logic for the game over state can be added here
        }

        public override void Exit()
        {
            Debug.Log("Exiting GAME OVER");
        }

        private IEnumerator EndGameOver()
        {
            yield return new WaitForSecondsRealtime(3.6f);
            Time.timeScale = 0f;
            _viewManager.GetView<EndGameView>().Show();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}