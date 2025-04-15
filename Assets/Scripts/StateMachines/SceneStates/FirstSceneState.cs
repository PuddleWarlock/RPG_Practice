using Controllers.Scenes;
using Controllers.UI;
using UnityEngine;

namespace StateMachines.SceneStates
{
    public class FirstSceneState : GlobalState
    {
        public FirstSceneState(GameplayManager gameplayManager, ViewManager viewManager) : base(gameplayManager, viewManager)
        {
        }

        public override void Enter()
        {
            Time.timeScale = 1f;
            Debug.Log("Entering FIRST SCENE STATE");
        }

        public override void Execute()
        {
            // Logic for the first scene state
        }

        public override void Exit()
        {
            Debug.Log("Exiting FIRST SCENE STATE");
        }
        
    }
}