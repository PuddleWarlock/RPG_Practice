using Controllers;
using Controllers.Entities;
using Controllers.Entities.HealthController;
using Controllers.Scenes;
using Controllers.UI;
using Enemy;
using UnityEngine;
using Views.Gameplay;

namespace Bootstraps
{
    public class GameplayBootstrap : MonoBehaviour
    {
        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private Camera _camera;
        [SerializeField] private CooldownView cooldownView;
        [SerializeField] private HealthBarView healthBarView;
        private GameObject _player;
        [SerializeField] private InputManager _inputManager;
        
        [Header("Enemies")]
        [SerializeField] private GameObject[] _enemies;
        [SerializeField] private Vector2 _enemiesSpawnAreaExtents;
        [SerializeField] private int _enemiesCount;
        [SerializeField] private Transform _enemiesSpawnPoint;
        private void Awake()
        {
            var settngsInteractor = GameManager.Instance.GetSettingsInteractor();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            var gameManager = gameObject.AddComponent<GameplayManager>();
            var viewManager = FindAnyObjectByType<ViewManager>();
            _player = Instantiate(_playerPrefab, _playerSpawnPoint.position, Quaternion.identity);
            var playerHealthSystem = _player.GetComponent<HealthSystem>();
            playerHealthSystem.Init(1);
            gameManager.Init(_inputManager,playerHealthSystem,viewManager);
            _player.GetComponent<MovementController>().Init(_camera);
            cooldownView.Init(_player.GetComponent<SkillsController>());
            healthBarView.Init(playerHealthSystem.onHealthChanged);

            var enemyManager = new EnemyManager(settngsInteractor,
                _enemiesSpawnAreaExtents,
                _enemies,
                _enemiesSpawnPoint.position,
                _enemiesCount);
        }
    }
}