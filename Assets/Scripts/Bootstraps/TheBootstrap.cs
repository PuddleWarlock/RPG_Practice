using Controllers;
using Controllers.SaveLoad;
using Controllers.SaveLoad.PlayerSaves;
using Controllers.SaveLoad.Settings;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Bootstraps
{
    public class TheBootstrap : MonoBehaviour
    {
        private void Awake()
        {
            var gamemanager = new GameObject("GameManager").AddComponent<GameManager>();
            var playerPrefs = new PlayerPrefsRepository();
            var jsonRepository = new JsonRepository("PlayerData");
            var playerDataInteractor = new PlayerDataInteractor(jsonRepository);
            var settings = new SettingsInteractor(playerPrefs);
            gamemanager.Init(settings, playerDataInteractor);

            SceneManager.LoadScene("MainMenu");
        }
    }
}