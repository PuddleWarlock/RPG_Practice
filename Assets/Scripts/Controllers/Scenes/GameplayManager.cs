using Controllers.Entities;
using Controllers.Entities.HealthController;
using Controllers.UI;
using StateMachines;
using StateMachines.SceneStates;
using UnityEngine;
using UnityEngine.SceneManagement;
using Views.Gameplay;
using Weapons.Base;

namespace Controllers.Scenes
{
    public class GameplayManager : MonoBehaviour
    {
        private StateMachine _sceneStateMachine;
        private InputManager _inputManager;
        private HealthSystem _healthSystem;
        private ViewManager _viewManager;
        private bool _isGameOver;
        private void Awake()
        {
            _sceneStateMachine = new StateMachine();
        }
        public void Init(InputManager inputManager, HealthSystem playerHealthSystem, ViewManager viewManager)
        { 
            _inputManager = inputManager;
            _healthSystem = playerHealthSystem;
            _viewManager = viewManager;
            
            _viewManager.GetView<EndGameView>().AddRestartButtonListener(RestartGame);
            
            _healthSystem.onDeath.AddListener((value) => _isGameOver =  value);
            
            GameStatesInit();
        }
        private void Update()
        {
            _sceneStateMachine.Tick();
            if(Input.GetKeyDown(KeyCode.K)) _healthSystem.TakeDamage(new Damage(DamageType.Physic,20f));
        }

        private void GameStatesInit()
        {
            var firstSceneState = new FirstSceneState(this,_viewManager);
            var pauseState = new PauseState(this,_viewManager);
            var gameOverState = new GameOverState(this,_viewManager);

            
            
            _sceneStateMachine.AddTransition(pauseState, firstSceneState, () => !_inputManager.MenuInput);
            _sceneStateMachine.AddAnyTransition(pauseState, () => _inputManager.MenuInput);
            _sceneStateMachine.AddAnyTransition(gameOverState, () => _isGameOver);
            
            _sceneStateMachine.SetState(firstSceneState);
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void InputManagerDisable()
        {
            _inputManager.gameObject.SetActive(false);
        }
    }
}