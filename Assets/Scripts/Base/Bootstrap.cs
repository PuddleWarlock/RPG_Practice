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
        [SerializeField] private CooldownView cooldownView;
        [SerializeField] private HealthBarView healthBarView;
        private GameObject _player;
        [SerializeField] private InputManager _inputManager;
        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            //_inputManager = GetComponent<InputManager>();
            var gameManager = gameObject.AddComponent<GameManager>();
            var viewManager = FindAnyObjectByType<ViewManager>();
            _player = Instantiate(_playerPrefab, _playerSpawnPoint.position, Quaternion.identity);
            gameManager.Init(_inputManager,_player.GetComponent<HealthSystem>(),viewManager);
            _player.GetComponent<MovementController>().Init(_camera);
            cooldownView.Init(_player.GetComponent<SkillsController>());
            healthBarView.Init(_player.GetComponent<HealthSystem>().onHealthChanged);
        }
    }
}