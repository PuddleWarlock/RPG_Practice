using System.Collections.Generic;
using Controllers.Entities;
using Controllers.Entities.HealthController;
using Controllers.SaveLoad.Saveables;
using Controllers.SaveLoad.Settings;
using UnityEngine;
using Views.Gameplay;

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
                int prefabIndex = Random.Range(0, _enemyPrefabs.Length); // 0 или 1
                var enemyPrefab = _enemyPrefabs[prefabIndex];
                var enemy = Object.Instantiate(enemyPrefab, GetRandomPosition(), Quaternion.identity).GetComponent<EnemyController>();
                
                var healthSystem = enemy.GetComponent<HealthSystem>();
                healthSystem.onHealthChanged.AddListener(enemy.GetComponentInChildren<HealthBarView>().ChangeHp);
                healthSystem.Init(enemiesPower);
                enemy.GetComponent<SkillsController>().Init(null);
                enemy.UniqueId = System.Guid.NewGuid().ToString(); // Уникальный ID
                enemy.PrefabIndex = prefabIndex; // Сохраняем индекс префаба
                _enemies.Add(enemy);
            }
        }

        public List<EnemyData> GetEnemyData()
        {
            List<EnemyData> enemyDataList = new List<EnemyData>();
            foreach (var enemy in _enemies)
            {
                if (enemy != null && !enemy.isDead) // Сохраняем только живых врагов
                {
                    enemyDataList.Add(new EnemyData
                    {
                        Id = enemy.UniqueId,
                        Position = enemy.transform.position,
                        Health = enemy.GetComponent<HealthSystem>().Health, // Предполагается, что HealthSystem имеет CurrentHealth
                        PrefabIndex = enemy.PrefabIndex
                    });
                }
            }
            return enemyDataList;
        }

        public void LoadEnemies(List<EnemyData> enemyDataList)
        {   
            if (enemyDataList.Count == 0) return;
            // Очищаем существующих врагов
            foreach (var enemy in _enemies)
            {
                if (enemy != null)
                {
                    Object.Destroy(enemy.gameObject);
                }
            }
            _enemies.Clear();
            
            // Создаём врагов из сохранённых данных

            var enemiesPower = _settingsInteractor.LoadSettings().EnemiesPower;
            foreach (var enemyData in enemyDataList)
            {   
                if (enemyData.PrefabIndex >= 0 && enemyData.PrefabIndex < _enemyPrefabs.Length)
                {
                    var enemyPrefab = _enemyPrefabs[enemyData.PrefabIndex];
                    var enemy = Object.Instantiate(enemyPrefab, enemyData.Position, Quaternion.identity)
                        .GetComponent<EnemyController>();
                    enemy.UniqueId = enemyData.Id;
                    enemy.PrefabIndex = enemyData.PrefabIndex;
                    
                    var healthSystem = enemy.GetComponent<HealthSystem>();

                    healthSystem.onHealthChanged.AddListener(enemy.GetComponentInChildren<HealthBarView>().ChangeHp);
                    healthSystem.Init(enemiesPower);
                    healthSystem.SetHealth(enemyData.Health); // Предполагается метод SetHealth
                    enemy.GetComponent<SkillsController>().Init(null);
                    _enemies.Add(enemy);
                }
                else
                {
                    Debug.LogWarning($"Недопустимый PrefabIndex: {enemyData.PrefabIndex}");
                }
            }
        }

        private Vector3 GetRandomPosition()
        {
            return new Vector3(
                Random.Range(_enemiesSpawnAreaCenter.x - _enemiesSpawnAreaExtents.x, _enemiesSpawnAreaCenter.x + _enemiesSpawnAreaExtents.x),
                _enemiesSpawnAreaCenter.y,
                Random.Range(_enemiesSpawnAreaCenter.z - _enemiesSpawnAreaExtents.y, _enemiesSpawnAreaCenter.z + _enemiesSpawnAreaExtents.y));
        }
    }
}