using UnityEngine;

namespace GlobalStateMachine
{
    public class GameOverState : GlobalState
    {
        public override void Enter()
        {
            Debug.Log("Entering GAME OVER");
        }

        public override void Execute()
        {
            // Logic for the game over state can be added here
        }

        public override void Exit()
        {
            Debug.Log("Exiting GAME OVER");
        }
    }
}