using Controllers;
using Controllers.SaveLoad;
using Controllers.Settings;
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
            var settings = new SettingsInteractor(playerPrefs);
            gamemanager.Init(settings);

            SceneManager.LoadScene("MainMenu");
        }
    }
}