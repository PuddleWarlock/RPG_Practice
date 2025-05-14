using System;
using Controllers.Entities;
using Controllers.Entities.HealthController;
using Enemy;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private Camera _camera;
    private object _playerHealthSystem;
    
    

    private void Awake()
    {
        var player = Instantiate(_playerPrefab,transform.position, Quaternion.identity);
        _playerHealthSystem = player.GetComponent<HealthSystem>();
        // healthBarView.Init(_playerHealthSystem.onHealthChanged);
        /*_playerHealthSystem.onHealthChanged.AddListener(healthBarView.ChangeHp);
        _playerHealthSystem.Init(1);*/
        player.GetComponent<MovementController>().Init(_camera);

        var boss = FindFirstObjectByType<BossController>();
        boss.GetComponent<SkillsController>().Init(_camera);
    }
}
