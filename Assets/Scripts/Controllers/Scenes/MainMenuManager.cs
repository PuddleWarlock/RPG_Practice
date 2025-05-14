using System.Collections.Generic;
using Controllers.SaveLoad.PlayerSaves;
using Controllers.SaveLoad.Saveables;
using Controllers.SaveLoad.Settings;
using Controllers.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Views.MainMenu;

namespace Controllers.Scenes
{
    public class MainMenuManager
    {
        private readonly ViewManager _viewManager;
        private readonly SettingsInteractor _settingsInteractor;
        private readonly PlayerDataInteractor _playerDataInteractor;

        public MainMenuManager(ViewManager viewManager, SettingsInteractor settingsInteractor, PlayerDataInteractor playerDataInteractor)
        {
            _viewManager = viewManager;
            _settingsInteractor = settingsInteractor;
            _playerDataInteractor = playerDataInteractor;
            LoadingSceneManager.NextSceneName = "GameScene";
            SetListeners();
            HasSettings();
            SettingsToUI();
        }

        private void HasSettings()
        {
            if (_settingsInteractor.HasSettings()) return;
            GameSettings settings = new GameSettings();
            _settingsInteractor.SaveSettings(settings);
        }

        private void SettingsToUI()
        {
            var settings = _settingsInteractor.LoadSettings();
            var settingsView = _viewManager.GetView<SettingsView>();
            settingsView.SetSliderValue(settings.EnemiesPower);
            settingsView.SetPeaceMode(settings.PeaceMode);
        }

        private void UpdateEnemyPowerSettings(float value)
        {
            var settings = _settingsInteractor.LoadSettings();
            settings.EnemiesPower = value;
            _settingsInteractor.SaveSettings(settings);
        }
        
        private void UpdatePeaceModeSettings(bool value)
        {
            var settings = _settingsInteractor.LoadSettings();
            settings.PeaceMode = value;
            _settingsInteractor.SaveSettings(settings);
        }

        private void NewGame()
        {
            _playerDataInteractor.StartNewGame();
            SceneManager.LoadScene("LoadingScene");
        }

        private void ContinueGame()
        {
            if (_playerDataInteractor.HasPlayerData())
            {
                _playerDataInteractor.LoadLatestPlayerData();
                SceneManager.LoadScene("LoadingScene");
            }
            else
            {
                Debug.Log("No save data found. Starting new game."); 
                NewGame();
            }
        }

        private List<string> GetTimestamps() => _playerDataInteractor.GetAllSaves();

        private void LoadSelected(string timestamp)
        {
            _playerDataInteractor.LoadByTimestamp(timestamp);
            SceneManager.LoadScene("LoadingScene");
        }
        
        
        private void SetListeners()
        {
            var mainMenuView = _viewManager.GetView<MainMenuView>();
            var settingsView = _viewManager.GetView<SettingsView>();
            var loadView = _viewManager.GetView<LoadGameView>();
            
            mainMenuView.SetNewGameAction(NewGame);
            mainMenuView.SetResumeAction(ContinueGame);
            mainMenuView.SetSettingsAction(()=>_viewManager.SwitchViews(mainMenuView, settingsView));
            mainMenuView.SetLoadAction(() => loadView.ShowLoadGameMenu(GetTimestamps(),LoadSelected));
            mainMenuView.SetLoadAction(()=>_viewManager.SwitchViews(mainMenuView,loadView));
            
            settingsView.SetSliderListener(UpdateEnemyPowerSettings);
            settingsView.SetPeaceModeListener(UpdatePeaceModeSettings);
            settingsView.SetBackButtonListener(()=>_viewManager.SwitchViews(settingsView, mainMenuView));


            loadView.SetBackButtonListener(()=>_viewManager.SwitchViews(loadView,mainMenuView));
        }
        
        
    }
}