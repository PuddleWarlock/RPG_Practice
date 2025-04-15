using System.Collections.Generic;
using Controllers.SaveLoad.Saveables;

namespace Controllers.SaveLoad.PlayerSaves
{
    public class PlayerDataInteractor
    {
        private const string PlayerDataKey = "playerData";
        private readonly IPlayerDataRepository _playerDataRepository;
        public PlayerData CurrentSave { get; private set; }

        public PlayerDataInteractor(IPlayerDataRepository playerDataRepository)
        {
            _playerDataRepository = playerDataRepository;
        }
        
        public void StartNewGame()
        {
            CurrentSave = new PlayerData
            {
                Health = 100f,
                Position = default
            };
            _playerDataRepository.Save(PlayerDataKey, CurrentSave);
        }
        
        public void SavePlayerData(PlayerData playerData)
        {
            CurrentSave = playerData;
            _playerDataRepository.Save(PlayerDataKey, CurrentSave);
        }
        
        public PlayerData LoadLatestPlayerData()
        {
            CurrentSave = _playerDataRepository.Load(PlayerDataKey, new PlayerData());
            return CurrentSave;
        }

        public PlayerData LoadByTimestamp(string timestamp)
        {
            CurrentSave = _playerDataRepository.Load(PlayerDataKey, timestamp, new PlayerData());
            return CurrentSave;
        }

        public List<string> GetAllSaves()
        {
            return _playerDataRepository.GetAllTimestamps();
        }

        public bool HasPlayerData()
        {
            return _playerDataRepository.HasKey(PlayerDataKey);
        }

        public void DeletePlayerData()
        {
            _playerDataRepository.Delete(PlayerDataKey);
        }
    }
}