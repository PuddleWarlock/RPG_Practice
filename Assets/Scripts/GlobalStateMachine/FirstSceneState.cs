using Base;
using UI;
using UnityEngine;

namespace GlobalStateMachine
{
    public class FirstSceneState : GlobalState
    {
        public FirstSceneState(GameManager gameManager, ViewManager viewManager) : base(gameManager, viewManager)
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