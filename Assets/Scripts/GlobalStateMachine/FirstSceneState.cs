using Base;
using UnityEngine;

namespace GlobalStateMachine
{
    public class FirstSceneState : GlobalState
    {

        public override void Enter()
        {
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