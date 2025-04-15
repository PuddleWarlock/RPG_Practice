﻿using Controllers.SaveLoad.Saveables;

namespace Controllers.SaveLoad.Settings
{
    public class SettingsInteractor
    {
        private const string SettingsKey = "gameSettings";
        private readonly IDataRepository _playerPrefsRepository;

        public SettingsInteractor(IDataRepository playerPrefsRepository)
        {
            _playerPrefsRepository = playerPrefsRepository;
        }

        public void SaveSettings(GameSettings settings)
        {
            _playerPrefsRepository.Save(SettingsKey, settings);
        }

        public GameSettings LoadSettings()
        {
            return _playerPrefsRepository.Load(SettingsKey,new GameSettings());
        }

        public bool HasSettings()
        {
            return _playerPrefsRepository.HasKey(SettingsKey);
        }

        public void DeleteSettings()
        {
            _playerPrefsRepository.Delete(SettingsKey);
        }
        
    }
}