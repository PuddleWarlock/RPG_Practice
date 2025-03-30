using Base;
using Fight;
using StateMachines;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Weapons;

namespace GlobalStateMachine
{
    public class GameManager : MonoBehaviour
    {
        private StateMachine _globalStateMachine;
        private InputManager _inputManager;
        private HealthSystem _healthSystem;
        private ViewManager _viewManager;
        private bool _isGameOver;
        private void Awake()
        {
            _globalStateMachine = new StateMachine();
        }
        public void Init(InputManager inputManager, HealthSystem playerHealthSystem, ViewManager viewManager)
        {
            _inputManager = inputManager;
            _healthSystem = playerHealthSystem;
            _viewManager = viewManager;
            
            _viewManager.GetView<EndGameView>().AddRestartButtonListener(RestartGame);
            
            _healthSystem.onDeath.AddListener(() => _isGameOver = true);
            GameStatesInit();
        }
        private void Update()
        {
            _globalStateMachine.Tick();
            if(Input.GetKeyDown(KeyCode.K)) _healthSystem.TakeDamage(new Damage(DamageType.Physic,20f));
        }

        private void GameStatesInit()
        {
            var firstSceneState = new FirstSceneState(this,_viewManager);
            var pauseState = new PauseState(this,_viewManager);
            var gameOverState = new GameOverState(this,_viewManager);
            
            _globalStateMachine.AddTransition(pauseState, firstSceneState, () => !_inputManager.MenuInput);
            _globalStateMachine.AddAnyTransition(pauseState, () => _inputManager.MenuInput);
            _globalStateMachine.AddAnyTransition(gameOverState, () => _isGameOver);
            
            _globalStateMachine.SetState(firstSceneState);
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}