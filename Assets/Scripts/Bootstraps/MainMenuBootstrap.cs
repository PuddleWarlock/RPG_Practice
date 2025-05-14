using Controllers;
using Controllers.Scenes;
using Controllers.UI;
using UnityEngine;

namespace Bootstraps
{
    public class MainMenuBootstrap : MonoBehaviour
    {
        private void Awake()
        {
            var viewManager = GetComponent<ViewManager>();
            MainMenuManager menuManager = new(viewManager, GameManager.Instance.GetSettingsInteractor(),
                GameManager.Instance.GetPlayerDataInteractor());
           
            InvokeRepeating(nameof(Do),0f,1f);
        }

        private void Do() => print(GameManager.Instance.GetSettingsInteractor().LoadSettings().EnemiesPower);
        private void Update()
        {
            
        }
    }
}