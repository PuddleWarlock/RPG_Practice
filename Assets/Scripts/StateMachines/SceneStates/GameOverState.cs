using System.Collections;
using Controllers.Scenes;
using Controllers.UI;
using UnityEngine;
using Views.Gameplay;

namespace StateMachines.SceneStates
{
    public class GameOverState : GlobalState
    {
        private GameplayManager _gameplayManager;
        private ViewManager _viewManager;
        public GameOverState(GameplayManager gameplayManager, ViewManager viewManager) : base(gameplayManager, viewManager)
        {
            _gameplayManager = gameplayManager;
            _viewManager = viewManager;
        }

        public override void Enter()
        {
            _gameplayManager.InputManagerDisable();
            _gameplayManager.StartCoroutine(EndGameOver());
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