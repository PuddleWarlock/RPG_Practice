using System.Collections.Generic;
using Controllers.Entities;
using Controllers.Entities.HealthController;
using Controllers.SaveLoad.PlayerSaves;
using Controllers.SaveLoad.Saveables;
using Controllers.UI;
using StateMachines;
using StateMachines.SceneStates;
using UnityEngine;
using UnityEngine.SceneManagement;
using Views.Gameplay;
using Views.MainMenu;
using Weapons.Base;

namespace Controllers.Scenes
{
    public class GameplayManager : MonoBehaviour
    {
        private StateMachine _sceneStateMachine;
        private InputManager _inputManager;
        private HealthSystem _healthSystem;
        private ViewManager _viewManager;
        private PlayerDataInteractor _playerDataInteractor;
        private bool _isGameOver;
        
        private void Awake()
        {
            _sceneStateMachine = new StateMachine();
        }
        public void Init(InputManager inputManager, HealthSystem playerHealthSystem, ViewManager viewManager, PlayerDataInteractor playerDataInteractor)
        { 
            _inputManager = inputManager;
            _healthSystem = playerHealthSystem;
            _viewManager = viewManager;
            _playerDataInteractor = playerDataInteractor;
            
            SetListeners();
            
            _healthSystem.onDeath.AddListener((value) => _isGameOver =  value);
            
            GameStatesInit();
        }
        private void Update()
        {
            _sceneStateMachine.Tick();
            if(Input.GetKeyDown(KeyCode.K)) _healthSystem.TakeDamage(new Damage(DamageType.Physic,20f));
        }
        
        private void SetListeners()
        {
            if (!_viewManager)
            {
                print("ya yeblan");
            }

            var pauseView = _viewManager.GetView<PauseView>();
            var loadView = _viewManager.GetView<LoadGameView>();
            pauseView.SetToLoadChooseButtonListener(() => _viewManager.SwitchViews(pauseView,loadView));
            pauseView.SetToLoadChooseButtonListener(() => loadView.ShowLoadGameMenu(GetTimestamps(),LoadSelected));
            pauseView.SetSaveButtonListener(SavePlayerData);
            pauseView.SetMainMenuButtonListener(() =>
            {
                LoadingSceneManager.NextSceneName = "MainMenu";
                SceneManager.LoadScene("LoadingScene");
            });
            pauseView.SetLoadLastButtonListener(LoadLast);
            
            loadView.SetBackButtonListener(()=>_viewManager.SwitchViews(loadView,pauseView));
            _viewManager.GetView<EndGameView>().AddRestartButtonListener(RestartGame);
        }
        
        private List<string> GetTimestamps() => _playerDataInteractor.GetAllSaves();

        private void LoadSelected(string timestamp)
        {
            _playerDataInteractor.LoadByTimestamp(timestamp);
            LoadingSceneManager.NextSceneName = "GameScene";
            SceneManager.LoadScene("LoadingScene");
        }

        private void LoadLast()
        {
            _playerDataInteractor.LoadLatestPlayerData();
            SceneManager.LoadScene("LoadingScene");
        }

        

        private void SavePlayerData()
        {
            var playerData = new PlayerData()
            {
                Health = _healthSystem.Health,
                Position = _healthSystem.transform.position
            };
            _playerDataInteractor.SavePlayerData(playerData);
            Debug.Log("wwwwwww");
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
            _playerDataInteractor.LoadLatestPlayerData();
            LoadingSceneManager.NextSceneName = "GameScene";
            SceneManager.LoadScene("LoadingScene");
        }
        
        
        
        public void InputManagerDisable()
        {
            _inputManager.gameObject.SetActive(false);
        }
        
    }
}