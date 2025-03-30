using Base;
using UnityEngine;

namespace GlobalStateMachine
{
    public class PauseState : GlobalState
    {

        public override void Enter()
        {
            Debug.Log("Entering PAUSE STATE");
            Time.timeScale = 0f;
        }

        public override void Execute()
        {
            // Handle pause logic here
        }

        public override void Exit()
        {
            Debug.Log("Exiting PAUSE STATE");
            Time.timeScale = 1f;
        }
    }
}