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
using Enemy;

namespace Controllers.Scenes
{
    public class GameplayManager : MonoBehaviour
    {
        private StateMachine _sceneStateMachine;
        private InputManager _inputManager;
        private HealthSystem _healthSystem;
        private ViewManager _viewManager;
        private PlayerDataInteractor _playerDataInteractor;
        private EnemyManager _enemyManager; // Добавляем EnemyManager
        private bool _isGameOver;

        private void Awake()
        {
            _sceneStateMachine = new StateMachine();
        }

        public void Init(InputManager inputManager, HealthSystem playerHealthSystem, ViewManager viewManager, PlayerDataInteractor playerDataInteractor, EnemyManager enemyManager)
        {
            _inputManager = inputManager;
            _healthSystem = playerHealthSystem;
            _viewManager = viewManager;
            _playerDataInteractor = playerDataInteractor;
            _enemyManager = enemyManager; // Инициализируем EnemyManager

            SetListeners();

            _healthSystem.onDeath.AddListener((value) => _isGameOver = value);

            GameStatesInit();
        }

        private void Update()
        {
            _sceneStateMachine.Tick();
            if (Input.GetKeyDown(KeyCode.K)) _healthSystem.TakeDamage(new Damage(DamageType.Physic, 20f));
        }

        private void SetListeners()
        {
            if (!_viewManager)
            {
                print("ya yeblan");
            }

            var pauseView = _viewManager.GetView<PauseView>();
            var loadView = _viewManager.GetView<LoadGameView>();
            pauseView.SetToLoadChooseButtonListener(() => _viewManager.SwitchViews(pauseView, loadView));
            pauseView.SetToLoadChooseButtonListener(() => loadView.ShowLoadGameMenu(GetTimestamps(), LoadSelected));
            pauseView.SetSaveButtonListener(SavePlayerData);
            pauseView.SetMainMenuButtonListener(() =>
            {
                LoadingSceneManager.NextSceneName = "MainMenu";
                SceneManager.LoadScene("LoadingScene");
            });
            pauseView.SetLoadLastButtonListener(LoadLast);

            loadView.SetBackButtonListener(() => _viewManager.SwitchViews(loadView, pauseView));
            _viewManager.GetView<EndGameView>().AddRestartButtonListener(RestartGame);
        }

        private List<string> GetTimestamps() => _playerDataInteractor.GetAllSaves();

        private void LoadSelected(string timestamp)
        {
            PlayerData data = _playerDataInteractor.LoadByTimestamp(timestamp);
            // ApplyPlayerData(data);
            LoadingSceneManager.NextSceneName = "GameScene";
            SceneManager.LoadScene("LoadingScene");
        }

        private void LoadLast()
        {
            PlayerData data = _playerDataInteractor.LoadLatestPlayerData();
            // ApplyPlayerData(data);
            SceneManager.LoadScene("LoadingScene");
        }

        private void SavePlayerData()
        {
            var playerData = new PlayerData()
            {
                Health = _healthSystem.Health,
                Position = _healthSystem.transform.position,
                Enemies = _enemyManager.GetEnemyData() // Получаем данные о врагах
            };
            _playerDataInteractor.SavePlayerData(playerData);
            Debug.Log("Game saved with enemies");
        }

        private void GameStatesInit()
        {
            var firstSceneState = new FirstSceneState(this, _viewManager);
            var pauseState = new PauseState(this, _viewManager);
            var gameOverState = new GameOverState(this, _viewManager);

            _sceneStateMachine.AddTransition(pauseState, firstSceneState, () => !_inputManager.MenuInput);
            _sceneStateMachine.AddAnyTransition(pauseState, () => _inputManager.MenuInput);
            _sceneStateMachine.AddAnyTransition(gameOverState, () => _isGameOver);

            _sceneStateMachine.SetState(firstSceneState);
        }

        private void RestartGame()
        {
            PlayerData data = _playerDataInteractor.LoadLatestPlayerData();
            // ApplyPlayerData(data);
            LoadingSceneManager.NextSceneName = "GameScene";
            SceneManager.LoadScene("LoadingScene");
        }

        // private void ApplyPlayerData(PlayerData data)
        // {
        //     if (data != null)
        //     {
        //         _healthSystem.SetHealth(data.Health); // Предполагается метод SetHealth
        //         _healthSystem.transform.position = data.Position;
        //         _enemyManager.LoadEnemies(data.Enemies); // Восстанавливаем врагов
        //     }
        // }

        public void InputManagerDisable()
        {
            _inputManager.gameObject.SetActive(false);
        }
    }
}