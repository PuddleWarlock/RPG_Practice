using Controllers;
using Controllers.Entities;
using Controllers.Entities.HealthController;
using Controllers.SaveLoad.PlayerSaves;
using Controllers.SaveLoad.Saveables;
using Controllers.Scenes;
using Controllers.UI;
using Enemy;
using UnityEngine;
using Views.Gameplay;
using Weapons.Base;

namespace Bootstraps
{
    public class GameplayBootstrap : MonoBehaviour
    {
        [Header("Player")]
        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private Camera _camera;
        [SerializeField] private CooldownView cooldownView;
        [SerializeField] private HealthBarView healthBarView;
        [SerializeField] private InputManager _inputManager;
        private GameObject _player;
        private HealthSystem _playerHealthSystem;
        private PlayerDataInteractor _playerDataInteractor;


        [Header("Enemies")]
        [SerializeField] private GameObject[] _enemies;
        [SerializeField] private Vector2 _enemiesSpawnAreaExtents;
        [SerializeField] private int _enemiesCount;
        [SerializeField] private Transform _enemiesSpawnPoint;

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            var settngsInteractor = GameManager.Instance.GetSettingsInteractor();
            var gameplayManager = gameObject.AddComponent<GameplayManager>();
            var viewManager = GetComponent<ViewManager>();
            _playerDataInteractor = GameManager.Instance.GetPlayerDataInteractor();
            //var uiManager = new GameplayUIManager(_playerDataInteractor, viewManager);
            SetUpPlayer();
            var skillsController = _player.GetComponent<SkillsController>();
            cooldownView.SetMeleeListener(()=>cooldownView.SetMeleeFillAmount(skillsController.Skills[SkillType.Melee].GetReadyPercent()));
            cooldownView.SetSpellListener(()=>cooldownView.SetSpellFillAmount(skillsController.Skills[SkillType.Fireball].GetReadyPercent()));
            gameplayManager.Init(_inputManager,_playerHealthSystem, viewManager, _playerDataInteractor);
            healthBarView.Init(_playerHealthSystem.onHealthChanged);

            var enemyManager = new EnemyManager(settngsInteractor,
                _enemiesSpawnAreaExtents,
                _enemies,
                _enemiesSpawnPoint.position,
                _enemiesCount);
        }

        private void SetUpPlayer()
        {
            _player = Instantiate(_playerPrefab, _playerSpawnPoint.position, Quaternion.identity);
            _playerHealthSystem = _player.GetComponent<HealthSystem>();
            _playerHealthSystem.SetHealth(_playerDataInteractor.CurrentSave.Health);
            _playerHealthSystem.Init(1);
            _player.GetComponent<MovementController>().Init(_camera);
            if (_playerDataInteractor.CurrentSave.Position == default) return;
            _player.transform.position = _playerDataInteractor.CurrentSave.Position;
        }
    }
}