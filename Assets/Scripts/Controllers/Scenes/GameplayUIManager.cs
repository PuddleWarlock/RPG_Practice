using Controllers.SaveLoad.PlayerSaves;
using Controllers.UI;
using Views.Gameplay;

namespace Controllers.Scenes
{
    public class GameplayUIManager
    {
        private PlayerDataInteractor _playerDataInteractor;
        private ViewManager _viewManager;

        public GameplayUIManager(PlayerDataInteractor playerDataInteractor, ViewManager viewManager)
        {
            _playerDataInteractor = playerDataInteractor;
            _viewManager = viewManager;
            
        }

        
    }
}