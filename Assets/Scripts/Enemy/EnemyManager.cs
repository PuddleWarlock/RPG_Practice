using System.Collections.Generic;
using Controllers.Entities.HealthController;
using Controllers.Settings;
using UnityEngine;

namespace Enemy
{
    public class EnemyManager
    {
        private SettingsInteractor _settingsInteractor;
        private GameObject[] _enemyPrefabs;
        
        private Vector2 _enemiesSpawnAreaExtents;
        private Vector3 _enemiesSpawnAreaCenter;
        
        private int _enemiesCount;
        
        private List<EnemyController> _enemies = new();
        
        public EnemyManager(SettingsInteractor settingsInteractor, Vector2 enemiesSpawnAreaSize, GameObject[] enemyPrefabs, Vector3 enemiesSpawnAreaCenter, int enemiesCount)
        {
            _settingsInteractor = settingsInteractor;
            _enemiesSpawnAreaExtents = enemiesSpawnAreaSize;
            _enemyPrefabs = enemyPrefabs;
            _enemiesSpawnAreaCenter = enemiesSpawnAreaCenter;
            _enemiesCount = enemiesCount;
            SpawnEnemies(_enemiesCount);
        }
        
        public void SpawnEnemies(int enemiesCount)
        {
            var enemiesPower = _settingsInteractor.LoadSettings().EnemiesPower;
            for (int i = 0; i < enemiesCount; i++)
            {
                var enemyPrefab = _enemyPrefabs[Random.Range(0, _enemyPrefabs.Length)];
                var enemy = Object.Instantiate(enemyPrefab, GetRandomPosition(), Quaternion.identity).GetComponent<EnemyController>();
                enemy.GetComponent<HealthSystem>().Init(enemiesPower);
                _enemies.Add(enemy);
            }
        }

        private Vector3 GetRandomPosition()
        {
            return new Vector3(Random.Range(_enemiesSpawnAreaCenter.x-_enemiesSpawnAreaExtents.x, _enemiesSpawnAreaCenter.x+_enemiesSpawnAreaExtents.x),
                _enemiesSpawnAreaCenter.y,
                Random.Range(_enemiesSpawnAreaCenter.z-_enemiesSpawnAreaExtents.y, _enemiesSpawnAreaCenter.z+_enemiesSpawnAreaExtents.y));
        }
    }
}