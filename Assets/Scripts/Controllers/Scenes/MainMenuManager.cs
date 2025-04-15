using Controllers.SaveLoad.Saveables;
using Controllers.Settings;
using Controllers.UI;
using UnityEngine.SceneManagement;
using Views.MainMenu;

namespace Controllers.Scenes
{
    public class MainMenuManager
    {
        private readonly ViewManager _viewManager;
        private readonly SettingsInteractor _settingsInteractor;

        public MainMenuManager(ViewManager viewManager, SettingsInteractor settingsInteractor)
        {
            _viewManager = viewManager;
            _settingsInteractor = settingsInteractor;
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
            _viewManager.GetView<SettingsView>().SetSliderValue(settings.EnemiesPower);
        }

        private void UpdateSettings(float value)
        {
            var settings = _settingsInteractor.LoadSettings();
            settings.EnemiesPower = value;
            _settingsInteractor.SaveSettings(settings);
        }
        private void SetListeners()
        {
            var mainMenuView = _viewManager.GetView<MainMenuView>();
            mainMenuView.SetStartAction(() => SceneManager.LoadScene("LoadingScene"));
            var settingsView = _viewManager.GetView<SettingsView>();
            mainMenuView.SetSettingsAction(()=>_viewManager.SwitchViews(mainMenuView, settingsView));
            settingsView.SetSliderListener(UpdateSettings);
            settingsView.SetBackButtonListener(()=>_viewManager.SwitchViews(settingsView, mainMenuView));
            
        }
    }
}