using System;
using Controllers.Settings;
using UnityEngine;

namespace Controllers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance
        {
            get
            {
                if (_instance != null) return _instance;
                _instance = FindAnyObjectByType<GameManager>();
                if (_instance != null) return _instance;
                var go = new GameObject("InputManager");
                _instance = go.AddComponent<GameManager>();

                return _instance;
            }
        }

        private static GameManager _instance;


        private SettingsInteractor _settingsInteractor;

        public SettingsInteractor GetSettingsInteractor() => _settingsInteractor;

        public void Init(SettingsInteractor settingsInteractor)
        {
            _settingsInteractor = settingsInteractor;
        }
        

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            
        }
        
    }
}