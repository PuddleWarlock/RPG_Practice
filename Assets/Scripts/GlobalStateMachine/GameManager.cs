using Base;
using Fight;
using StateMachines;
using UnityEngine;

namespace GlobalStateMachine
{
    public class GameManager : MonoBehaviour
    {
        private StateMachine _globalStateMachine;
        private InputManager _inputManager;
        private HealthSystem _healthSystem;
        private bool _isGameOver;
        private void Awake()
        {
            _globalStateMachine = new StateMachine();
        }
        public void Init(InputManager inputManager)
        {
            _inputManager = inputManager;
        }
        private void Start()
        {
            _healthSystem = FindAnyObjectByType<PlayerAnimator>().GetComponent<HealthSystem>();
            _healthSystem.onDeath.AddListener(() => _isGameOver = true);
            GameStatesInit();
        }
        private void Update()
        {
            _globalStateMachine.Tick();
        }

        private void GameStatesInit()
        {
            var firstSceneState = new FirstSceneState();
            var pauseState = new PauseState();
            var gameOverState = new GameOverState();
            
            _globalStateMachine.AddTransition(pauseState, firstSceneState, () => !_inputManager.MenuInput);
            _globalStateMachine.AddAnyTransition(pauseState, () => _inputManager.MenuInput);
            _globalStateMachine.AddAnyTransition(gameOverState, () => _isGameOver);
            
            _globalStateMachine.SetState(firstSceneState);
        }
    }
}