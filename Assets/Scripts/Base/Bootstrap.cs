using Fight;
using GlobalStateMachine;
using UI;
using UnityEngine;


namespace Base
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private Camera _camera;
        [SerializeField] private CooldownUI _cooldownUI;
        [SerializeField] private HealthBarUI _healthBarUI;
        private GameObject _player;
        private InputManager _inputManager;
        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            _inputManager = GetComponent<InputManager>();
            var gameManager = gameObject.AddComponent<GameManager>();
            gameManager.Init(_inputManager);
            _player = Instantiate(_playerPrefab, _playerSpawnPoint.position, Quaternion.identity);
            _player.GetComponent<MovementController>().Init(_camera);
            _cooldownUI.Init(_player.GetComponent<SkillsController>());
            _healthBarUI.Init(_player.GetComponent<HealthSystem>());
        }
    }
}